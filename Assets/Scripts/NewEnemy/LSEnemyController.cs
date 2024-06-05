using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSEnemyController : MonoBehaviour
{
    public GameObject bullet;

    public int hp;
    bool isCool;
    GameObject target;
    public GameObject text;
    EnemyMaker enemyMaker;
    // Start is called before the first frame update
    void Start()
    {
        enemyMaker = GameObject.FindGameObjectWithTag("MapMaker").GetComponent<EnemyMaker>();
        target = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCool)
        {
            StartCoroutine(Shot());
        }

        if (hp <= 0)
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(text, transform.position, Quaternion.identity);
                Debug.Log("Item");
            }
            Debug.Log("Dead");
            enemyMaker.realNum -= 1;
            Destroy(gameObject);
        }
    }

    IEnumerator Shot()
    {
        isCool = true;
        yield return new WaitForSeconds(2.0f);
        float angle = GetDegree(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x, target.transform.position.y));
        GameObject b = Instantiate(bullet, this.transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        yield return new WaitForSeconds(2.0f);
        isCool = false;
        yield break;
    }

    private float GetDegree(Vector2 from, Vector2 to)
    {
        return Mathf.Atan2(to.y - from.y, to.x - from.x) * 180 / Mathf.PI;
    }
}
