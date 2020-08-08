using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventory : MonoBehaviour
{
    public Text itemCount;

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateInven(int[] arr)
    {
        string str="\n\n";
        for(int i = 0; i < 12; i++)
        {
            
            str += arr[i].ToString();
            str += "\n";
        }
        itemCount.text = str;
    }
}
