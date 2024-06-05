using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyController : MonoBehaviour
{
    public float enemyMoveSpeed;

    public int hp;
    Vector3 randomTarget;
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
        //if (dCol.isDetected)
        //{
        Vector3 dir = target.transform.position - transform.position;
        if (dir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(new Vector3(dir.normalized.x * -1, dir.normalized.y, dir.normalized.z) * enemyMoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(dir.normalized * enemyMoveSpeed * Time.deltaTime);
        }

        if (hp <= 0)
        {
            if(Random.Range(0,2)==1)
            {
                Instantiate(text, transform.position, Quaternion.identity);
                Debug.Log("Item");
            }
            Debug.Log("Dead");
            enemyMaker.realNum -= 1;
            Destroy(gameObject);
        } 
    }

        //}
        //else
        //{
            //if (isArrive)
            //{
            //    isArrive = false;
            //    randomTarget = new Vector2(transform.position.x + Random.Range(-4.0f, 4.0f), transform.position.y + Random.Range(-4.0f, 4.0f));
            //}
            //else
            //{
            //    Vector3 dir = randomTarget - transform.position;
            //    if (dir.x > 0)
            //    {
            //        transform.rotation = Quaternion.Euler(0, 180, 0);
            //        transform.Translate(new Vector3(dir.normalized.x * -1, dir.normalized.y, dir.normalized.z) * enemyMoveSpeed * Time.deltaTime);
            //    }
            //    else
            //    {
            //        transform.rotation = Quaternion.Euler(0, 0, 0);
            //        transform.Translate(dir.normalized * enemyMoveSpeed * Time.deltaTime);
            //    }
            //    if (Vector2.Distance(transform.position, randomTarget) <= 0.5f)
            //    {
            //        isArrive = true;
            //    }
            //}

    //    }
    //}

    private float GetDegree(Vector2 from, Vector2 to)
    {
        return Mathf.Atan2(to.y - from.y, to.x - from.x) * 180 / Mathf.PI;
    }

}
