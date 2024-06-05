using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public bool open;
    public Sprite opendoor;
    public LevelGenerator level;
    public EnemyMaker enemy;
    public StepMana stepmana;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        level = GameObject.FindGameObjectWithTag("MapMaker").GetComponent<LevelGenerator>();
        enemy = GameObject.FindGameObjectWithTag("MapMaker").GetComponent<EnemyMaker>();
        stepmana = GameObject.FindGameObjectWithTag("Maker").GetComponent<StepMana>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.realNum == 0) 
        {
            open = true;
        }
        if (open)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = opendoor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (open && collision.gameObject.tag =="Player")
        {
            //level.step++;
            //level.Start_();
            stepmana.makeMaker();
        }
    }
}
