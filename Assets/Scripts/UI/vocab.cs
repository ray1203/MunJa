using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vocab : MonoBehaviour
{
    string[] text_ = { "붉", "은", "푸", "른", "검", "화", "염", "가", "시", "활", "방", "패" };
    List<string> letter=new List<string>();
    public List<List<int>> need = new List<List<int>>();
    List<bool> able = new List<bool>();
    public GameObject Item;
    public GameObject content;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        letter.Add("활"); letter.Add("검"); letter.Add("방패"); letter.Add("은활"); letter.Add("은검"); letter.Add("은방패"); letter.Add("화염활"); letter.Add("화염검"); letter.Add("화염방패"); letter.Add("가시활"); letter.Add("가시검"); letter.Add("가시방패"); letter.Add("붉은활"); letter.Add("붉은검"); letter.Add("붉은방패"); letter.Add("푸른활"); letter.Add("푸른검"); letter.Add("푸른방패"); letter.Add("검은활"); letter.Add("검은검"); letter.Add("검은방패"); letter.Add("붉은화염활"); letter.Add("붉은화염검"); letter.Add("붉은화염방패"); letter.Add("푸른화염활"); letter.Add("푸른화염검"); letter.Add("푸른화염방패"); letter.Add("검은화염활"); letter.Add("검은화염검"); letter.Add("검은화염방패"); letter.Add("붉은가시활"); letter.Add("붉은가시검"); letter.Add("붉은가시방패"); letter.Add("푸른가시활"); letter.Add("푸른가시검"); letter.Add("푸른가시방패"); letter.Add("검은가시활"); letter.Add("검은가시검"); letter.Add("검은가시방패");
        for(int i = 0; i < letter.Count; i++)
        {
            List<int> list = new List<int>();
            for(int j = 0; j < letter[i].Length; j++)
            {
                for(int k = 0; k < 12; k++)
                {
                    if (string.Compare(text_[k], letter[i].Substring(j, 1)) == 0)
                    {
                        list.Add(k);
                        break;
                    }
                }
            }
            list.Sort();
            need.Add(list);
            GameObject newObject = Instantiate(Item);
            newObject.GetComponent<makeWord>().num = i;
            newObject.transform.Find("Text").GetComponent<Text>().text = letter[i];
            newObject.transform.SetParent(content.transform);
        }
        Check();


    }
    public void Check()
    {
        able.Clear();
        for(int i = 0; i < need.Count; i++)
        {
            bool a = true;
            for(int j = 0; j < need[i].Count; j++)
            {
                if (player.GetComponent<TextList>().TextList_[need[i][j]] == 0) a = false;
            }
            if (a)
            {
                //for (int j = 0; j < need[i].Count; j++)player.GetComponent<TextList>().TextList_[need[i][j]]--;
                able.Add(true);

            }
            else
            {
                able.Add(false);
            }
        }
        for(int i = 0; i < content.transform.childCount; i++)
        {
            if (able[i])
                content.transform.GetChild(i).Find("Button").GetComponent<Image>().color = Color.green;
            else
                content.transform.GetChild(i).Find("Button").GetComponent<Image>().color = Color.red;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
