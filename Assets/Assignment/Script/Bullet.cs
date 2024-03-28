using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public virtual float Speed { get { return 6f; } }
    public virtual float damage { get { return 75f; } }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }
}
