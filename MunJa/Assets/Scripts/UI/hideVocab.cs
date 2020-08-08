using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideVocab : MonoBehaviour
{
    public GameObject vocab;
    public bool isFighting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    public void Click()
    {
        if (!isFighting)
        {
            if (vocab.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
        
    }
    public void Hide()
    {
        Debug.Log("Hide");
        vocab.SetActive(false);
        this.transform.localPosition = new Vector3(910, 350, 0);
    }
    public void Show()
    {
        Debug.Log("Show");
        vocab.SetActive(true);
        this.transform.localPosition = new Vector3(553, 350, 0);
    }
}
