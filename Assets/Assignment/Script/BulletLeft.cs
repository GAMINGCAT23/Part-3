using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLeft : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
