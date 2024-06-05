using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeWord : MonoBehaviour
{
    public GameObject player;
    public GameObject vocab;
    public int num;
    void Start()
    {
        player = GameObject.Find("Player").transform.Find("player").gameObject;
        vocab = GameObject.Find("Canvas").transform.Find("vocabBtn").GetComponent<hideVocab>().vocab;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void make()
    {
        if (this.gameObject.transform.Find("Button").GetComponent<Image>().color == Color.green)
        {
            for(int i = 0; i < vocab.GetComponent<vocab>().need[num].Count; i++)
            {
                player.GetComponent<TextList>().TextList_[vocab.GetComponent<vocab>().need[num][i]]--;


            }
            player.transform.Find("effect").GetComponent<SwordEffect>().damage = (20 + num / 2);
        }
        vocab.GetComponent<vocab>().Check();
    }
}
