using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    float targetX;
    public GameObject player_;
    public bool isMove;

    private Vector3 beforePos;

    void Start()
    {
        beforePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            targetX = player_.transform.position.x;
            Limmit();
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        }
    }

    void Limmit()
    {
        if (targetX < 0)
        {
            targetX = 0;
        }
        else if (targetX > 12.8)
        {
            targetX = 12.8f;
        }
    }

    public void ShakeStart(float power, float duration)
    {
        StartCoroutine(Shake(power, duration));
    }

    private IEnumerator Shake(float power, float duration)
    {
        float timer = 0;
        while (timer <= duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * power + beforePos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = beforePos;

    }
}
