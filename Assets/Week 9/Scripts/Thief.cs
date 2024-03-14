using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject DaggerPrefab;
    public Transform spawnPoint;
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        destination = transform.position;
        Instantiate(DaggerPrefab, spawnPoint.position, spawnPoint.rotation);
        base.Attack();
    }
}
