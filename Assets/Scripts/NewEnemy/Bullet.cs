using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 10;
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
        transform.Translate(Vector2.right * 5 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerController>().hp -= damage;
            Vector3 dir = col.transform.position - transform.position;
            float angle2 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector2 dir3 = (Vector2)(Quaternion.Euler(0, 0, angle2) * Vector2.one);
            col.GetComponent<Rigidbody2D>().AddForce(dir3 * 100f);
            Destroy(this.gameObject);
        }
        if (col.CompareTag("Wall") && timer > 0.1f)
        {
            Destroy(this.gameObject);
        }
    }
}
