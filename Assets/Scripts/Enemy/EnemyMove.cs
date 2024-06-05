using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{

    // Update is called once per frame
    Transform target = null;
    Vector3 randomTarget;
    private bool arrive = false;
    float enemyMoveSpeed = 2f;
    GameObject enemy;
    bool chasing = false;//현재상태
    float obstacleTimer = 0f;
    Vector3 attackRebound;
    bool chased = false;//플레이어 쫓았는지 기록

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = transform.GetComponentInParent<Transform>().gameObject;
    }

    void Update()
    {
            if (target != null && chasing)
            {
                Vector3 dir = target.position - enemy.transform.position;
                enemy.transform.Translate(dir.normalized * enemyMoveSpeed * Time.deltaTime);
            }
            else
            {
                if (arrive)
                {
                    arrive = false;
                    randomTarget = new Vector2(enemy.transform.position.x + Random.Range(-4.0f, 4.0f), enemy.transform.position.y + Random.Range(-4.0f, 4.0f));
                }
                else if (enemy != null)
                {

                    Vector3 dir = randomTarget - enemy.transform.position;
                    enemy.transform.Translate(dir.normalized * enemyMoveSpeed * Time.deltaTime);
                    if (Vector2.Distance(enemy.transform.position, randomTarget) <= 0.5f)
                    {
                        arrive = true;
                        if (chased) chasing = true;
                    }
                }
            }
    }
    public void setRebound(Vector3 vector)
    {
        attackRebound = vector;
        chasing = false;
        arrive = false;
        randomTarget = vector;
    }
    public void setArrive()
    {
        arrive = true;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            chasing = true;
            chased = true;

        }
        if(col.tag== "obstacle")
        {
            obstacleTimer += Time.deltaTime;
            if (obstacleTimer >= 1f)
            {
                arrive = true;
                obstacleTimer = 0f;
            }
        }
       // Debug.Log("p");

        
    }

        void OnTriggerExit2D(Collider2D col)
        {

        //if (col.tag == "Player")
            //chasing = false;
    }
}