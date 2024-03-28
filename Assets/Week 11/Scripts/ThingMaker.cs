using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingMaker : MonoBehaviour
{
    public GameObject ThingMakerPrefab;
    //public float whatIsTheStatic;
    List<Thing> thingList = new List<Thing>();

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(ThingMakerPrefab);
            thingList.Add(go.GetComponent<Thing>());
        }

        foreach (Thing thing in thingList)
        {
            Debug.Log(thing.ToString() + " " + Thing.staticNumber);
        }

        Thing.staticNumber = 0;
    }
}
