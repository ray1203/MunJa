using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextList : MonoBehaviour
{
    public int[] TextList_ = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    inventory inventory_;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++) TextList_[i]+=2;
        inventory_ = GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        inventory_.UpdateInven(TextList_);
    }
}
