using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    PlayerController player_;

    // Start is called before the first frame update
    void Start()
    {
        player_ = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player_.gameObject.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
