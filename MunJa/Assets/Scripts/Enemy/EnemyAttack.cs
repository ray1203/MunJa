using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemy;
    public GameObject moveCol;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("ss");
        Debug.Log(col.name);
        if (col.tag == "Player")
        {
            //enemy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //enemy.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            Vector3 dir = player.transform.position - enemy.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg+180f-70f;
            float angle2 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector2 dir2 = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.one);
            Vector2 dir3 = (Vector2)(Quaternion.Euler(0, 0, angle2) * Vector2.one);
            //enemy.GetComponent<Rigidbody2D>().AddForce(dir2 * 170f,ForceMode2D.Force);
            // moveCol.GetComponent<EnemyMove>().setRebound(dir2*0.7f);
            enemy.GetComponent<Rigidbody2D>().AddForce(dir2*20f);
            col.GetComponent<Rigidbody2D>().AddForce(dir3 * 70f);
            Debug.Log("enemy attacks player");


        }


    }
}
