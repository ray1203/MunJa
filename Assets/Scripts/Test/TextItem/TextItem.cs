using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextItem : MonoBehaviour
{
    public int step, rotat_z, player;
    public float moveSpeed;
    string[] text_ = { "붉", "은", "푸", "른", "검", "화", "염", "가", "시", "활", "방", "패" };
    GameObject player_;
    public TextMesh textMesh_;
    int textType;

    // Start is called before the first frame update
    void Start()
    {
        player_ = GameObject.FindGameObjectWithTag("Player");
        textType = Random.Range(0, 12);
        textMesh_.text = text_[textType];
        Debug.Log(text_[textType]);
    }

    // Update is called once per frame
    void Update()
    {
        switch(step)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                EatenPlayer();
                StartCoroutine("DestroyText");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            step = 2;
            Debug.Log("step ch");
        }
        //Debug.Log("Enter");
    }

    void EatenPlayer()
    {
        transform.localScale *= 0.95f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotat_z -= 12));
        //Debug.Log(transform.rotation.z);
        transform.position = Vector3.Lerp(transform.position, player_.transform.position, Time.deltaTime * moveSpeed);
    }

    IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(1.5f);
        player_.GetComponent<TextList>().TextList_[textType] += 1;
        Destroy(gameObject);
    }
}
