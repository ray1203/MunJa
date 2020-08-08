using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObstacle : MonoBehaviour
{
    float obstacleTimer = 0f;
    public GameObject moveCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "obstacle")
        {
            obstacleTimer += Time.deltaTime;
            if (obstacleTimer >= 1f)
            {
                moveCol.GetComponent<EnemyMove>().setArrive();
                obstacleTimer = 0f;
            }
        }


    }
}
