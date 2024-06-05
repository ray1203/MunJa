using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NDetectCol : MonoBehaviour
{
    public bool isDetected = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            isDetected = true;

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            isDetected = false;

    }

}
