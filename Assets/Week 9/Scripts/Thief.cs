using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Thief : Villager
{
    public GameObject DaggerPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        if (transform.localScale.x > 0)
        {
            transform.Translate(Vector3.left);
        }
        else if (transform.localScale.x < 0)
        {
            transform.Translate(Vector3.right);
        }
        destination = transform.position;
        Instantiate(DaggerPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(DaggerPrefab, spawnPoint2.position, spawnPoint2.rotation);
        base.Attack();
    }
}
