using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openShop : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    // Start is called before the first frame update
    void Start()
    {
        open();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open()
    {
        List<string> letter = new List<string>();
        letter.Add("붉");
        letter.Add("은");
        letter.Add("푸");
        letter.Add("른");
        letter.Add("검");
        letter.Add("화");
        letter.Add("염");
        letter.Add("가");
        letter.Add("시");
        letter.Add("활");
        letter.Add("방");
        letter.Add("패");
        int r = Random.Range(0, 13);
        item1.GetComponent<TextMesh>().text = letter[r];
        r = Random.Range(0, 13);
        item2.GetComponent<TextMesh>().text = letter[r];
        r = Random.Range(0, 13);
        item3.GetComponent<TextMesh>().text = letter[r];
    }
}
