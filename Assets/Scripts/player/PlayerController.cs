using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int hp = 100;
    public GameObject aim;
    public GameObject sword, bow;
    public GameObject arrow;
    public GameObject attackEffect;
    public float speed = 100.0f;

    float attackCool = 0.6f;
    Animator animator;
    bool isAttacked, isAttackCool, weaponType;
    GameObject weapon;
    GameObject hpBar;
    Text hpText;
    Rigidbody2D rigidbody_;
    PlayerData data;
    public GameObject startPoint;
    Vector3 localScale;

    void Start()
    {
        hp = 100;
        //transform.position = startPoint.transform.position;
        hpBar = GameObject.FindGameObjectWithTag("Bar");
        hpText = GameObject.FindGameObjectWithTag("HP").GetComponent<Text>();
        animator = GetComponent<Animator>();
        rigidbody_ = gameObject.GetComponent<Rigidbody2D>();
        isAttackCool = false;
        weaponType = true;
        localScale = hpBar.transform.localScale;

        if (weaponType)
        {
            sword.SetActive(true);
            weapon = sword;
        }
        else
        {
            bow.SetActive(true);
            weapon = bow;
        }
    }

    void Update()
    {
        Move();
        Rotat();        //방향 전환
        Attack();        //공격
        hpText.text = hp + " / 100";
        hpBar.transform.localScale = new Vector3(localScale.x * hp / 100, localScale.y, localScale.z);
        
        if(hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }

    IEnumerator CheckAttackCoolTime(float cooltime) //공격 쿨타임
    {
        if (weaponType)
        {
            isAttackCool = true;
            yield return new WaitForSeconds(0.2f); //0.4f : 이펙트 애니메이션 시간
            attackEffect.SetActive(false);
            yield return new WaitForSeconds(cooltime - 0.2f);
            isAttackCool = false;
        }
        else
        {
            float time = 0;
            Debug.Log(Input.GetMouseButton(0));
            while (Input.GetMouseButton(0) || time < 0.6f)
            {
                //Debug.Log(time);
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
            weapon.GetComponent<Animator>().SetBool("isPull", false);
            float angle = GetDegree(new Vector2(transform.position.x, transform.position.y), new Vector2(aim.transform.position.x, aim.transform.position.y));
            GameObject b = Instantiate(arrow, this.transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        }
        
        yield break;
    }

    private float GetDegree(Vector2 from, Vector2 to)
    {
        return Mathf.Atan2(to.y - from.y, to.x - from.x) * 180 / Mathf.PI;
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        /*
        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.up * v);
        */

        Vector3 movement;
        movement = new Vector3(h, v, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            rigidbody_.velocity = Vector3.Lerp(rigidbody_.velocity, new Vector3(0, 0, 0), 0.1f);
            animator.SetBool("isMove", false);
        }
        else
        {
            rigidbody_.velocity = movement;
            animator.SetBool("isMove", true);
        }
    }

    void Rotat()        //방향 전환
    {
        if (aim.transform.position.x > transform.position.x)
            animator.SetBool("IsLeft", false);
        else
            animator.SetBool("IsLeft", true);
    }

    void Attack()        //공격
    {
        float angle = GetDegree(new Vector2(transform.position.x, transform.position.y), new Vector2(aim.transform.position.x, aim.transform.position.y));
        if (isAttacked)
            weapon.transform.rotation = Quaternion.Euler(new Vector3(0, weapon.transform.rotation.y, angle - 195));
        else
            weapon.transform.rotation = Quaternion.Euler(new Vector3(0, weapon.transform.rotation.y, angle + 15));

        if (Input.GetMouseButton(0) && !isAttackCool)
        {
            if (weaponType) //true 는 칼 false 는 활
            {
                attackEffect.transform.rotation = Quaternion.Euler(new Vector3(0, weapon.transform.rotation.y, angle));
                attackEffect.transform.position = transform.position;
                attackEffect.SetActive(true);
                StartCoroutine(CheckAttackCoolTime(attackCool));
                if (isAttacked)
                    isAttacked = false;
                else
                    isAttacked = true;
            }
            else if (!weapon.GetComponent<Animator>().GetBool("isPull"))//활
            {
                StartCoroutine(CheckAttackCoolTime(attackCool));
                weapon.GetComponent<Animator>().SetBool("isPull", true);
            }
        }
    }
}
