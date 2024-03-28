using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    public static float staticNumber;
    public float notStaticNumber;

    void Start()
    {
        staticNumber = Random.Range(0, 10);
        notStaticNumber = Random.Range(0, 10);

        Debug.Log(this.ToString() + " static: " + staticNumber + " non-static" + notStaticNumber);
    }

    void Update()
    {
        
    }
}
