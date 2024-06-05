using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSAttackCol : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!this.CompareTag("monster")) return;
        if (col.CompareTag("Player"))
        {
            Vector3 dir = col.transform.position - transform.parent.transform.position;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180f - 70f;
            float angle2 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //Vector2 dir2 = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.one);
            Vector2 dir3 = (Vector2)(Quaternion.Euler(0, 0, angle2) * Vector2.one);
            //transform.parent.GetComponent<Rigidbody2D>().AddForce(dir2 * 10f);
            col.GetComponent<Rigidbody2D>().AddForce(dir3 * 100f);
        }
        else if (col.CompareTag("arrow"))
        {
            Vector3 dir = col.transform.position - transform.parent.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180f - 70f;
            Vector2 dir2 = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.one);
            transform.parent.GetComponent<Rigidbody2D>().AddForce(dir2 * 1f);

            transform.parent.GetComponent<LSEnemyController>().hp -= col.GetComponent<Arrow>().damage;
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("swordEffect"))
        {
            Vector3 dir = col.transform.position - transform.parent.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180f - 70f;
            Vector2 dir2 = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.one);
            transform.parent.GetComponent<Rigidbody2D>().AddForce(dir2 * 1f);

            transform.parent.GetComponent<LSEnemyController>().hp -= col.GetComponent<SwordEffect>().damage;
        }
    }

    private float GetDegree(Vector2 from, Vector2 to)
    {
        return Mathf.Atan2(to.y - from.y, to.x - from.x) * 180 / Mathf.PI;
    }
}
