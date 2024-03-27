using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    private Vector2 destination;
    Vector2 movement;

    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float speed = 5f;
    public float shootForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if (movement.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
            speed = 3;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        animator.SetFloat("Movement", movement.magnitude);

        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
            Attack();
        }
    }

    private void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        GameObject projectile = Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}

