using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepMana : MonoBehaviour
{
    public int step;

    public GameObject maker;
    public LevelGenerator level;
    public EnemyMaker enemy;
    public GameObject _maker;
    public GameObject Obj;
    public GameObject camera_;

    // Start is called before the first frame update
    void Start()
    {
        step = 1;
        //maker = GameObject.FindGameObjectWithTag("MapMaker");
        //level = GameObject.FindGameObjectWithTag("MapMaker").GetComponent<LevelGenerator>();
        //enemy = GameObject.FindGameObjectWithTag("MapMaker").GetComponent<EnemyMaker>();

        camera_ = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject newObject = Instantiate(maker, transform.position, Quaternion.identity);
        newObject.transform.SetParent(Obj.transform);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Obj.transform.childCount -1; i++)
        {
            Destroy(Obj.transform.GetChild(i).gameObject);
        }
    }

    public void makeMaker()
    {
        GameObject[] _maker = GameObject.FindGameObjectsWithTag("MapMaker");
        //Destroy(_maker);

        camera_.transform.position = new Vector3(0, 0, -10);

        GameObject newObject = Instantiate(maker, transform.position, Quaternion.identity);
        newObject.transform.SetParent(Obj.transform);
    }
}
