using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector2.right * 15 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall") && timer > 0.1f)
        {
            this.gameObject.tag = "dieArrow";
            Destroy(this);
        }
    }
}
