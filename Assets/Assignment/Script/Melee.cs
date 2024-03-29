using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Enemy
{
    public float damage = 10f;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
                GameCon.SetMonsterNum(GameCon.MonsterNumber - 1);
            }
        }
    }
}
