using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    Animator animator;
    public float moveSpeed = 3f;
    public float maxHealth = 100f;
    private float currentHealth;


    protected virtual void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        Debug.Log("Enemy" + currentHealth.ToString());
        animator.SetFloat("Speed", moveSpeed);
    }

    protected virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                float damage = bullet.damage;
                TakeDamage(damage);
                Destroy(other.gameObject);
            }
        }
    }
}
