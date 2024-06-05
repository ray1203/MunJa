using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    public GameObject money;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "swordEffect")
        {
            if(int.Parse(money.GetComponent<Text>().text.Substring(1)) >= 2){
                int r = Random.Range(0, 13);
                player.GetComponent<TextList>().TextList_[r]++;
                money.GetComponent<Text>().text = ":"+(int.Parse(money.GetComponent<Text>().text.Substring(1)) - 2).ToString();
            }
        }
    }
}
