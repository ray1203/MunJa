using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyItem : MonoBehaviour
{
    private bool b = true;
    public GameObject inventory;
    public GameObject money;
    public GameObject player;
    string[] text_ = { "붉", "은", "푸", "른", "검", "화", "염", "가", "시", "활", "방", "패" };
    public int[] TextList_ = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
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
        if (other.tag == "Player"&&b)
        {
            b = false;
            if (int.Parse(money.GetComponent<Text>().text.Substring(1)) >= 3)
            {

                money.GetComponent<Text>().text = ":" + (int.Parse(money.GetComponent<Text>().text.Substring(1)) - 3).ToString();
                string str = inventory.transform.Find("ItemCount").GetComponent<Text>().text.Substring(2);
                string[] split_str = str.Split('\n');
                //Debug.Log(split_str.Length);
               // for (int i = 0; i < 13; i++)Debug.Log(split_str[i]);
                for (int i = 0; i < 12; i++)
                {
                    if (string.Compare(text_[i], gameObject.transform.Find("GameObject").GetComponent<TextMesh>().text) == 0)
                    {
                        //split_str[i]=(int.Parse(split_str[i]) + 1).ToString();
                        player.GetComponent<TextList>().TextList_[i]++;
                        break;
                    }
                }
                /*for(int i = 0; i < 12; i++)
                {
                    player.GetComponent<TextList>().TextList_[i]= int.Parse(split_str[i]);
                    //Debug.Log(split_str[i]+","+TextList_[i]);
                }
                */

                gameObject.SetActive(false);
            }
            else
            {
                b = true;
            }
        }
    }
}
