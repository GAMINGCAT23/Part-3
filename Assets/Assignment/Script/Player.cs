using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    private Vector2 destination;
    Vector2 movement;

    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;

    public GameObject bulletSpawn;
    public float speed = 5f;
    public float shootForce = 10f;
    bool B1 = true;
    bool B2 = false;
    bool B3 = false;

    public float damage = 10;

    public float maxHealth = 100f;
    private float currentHealth;

    public Slider healthSlider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;

        currentHealth = maxHealth;
        UpdateHealthUI();
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
            speed = 4;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
        GameCon.SetPosition(transform.position);
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            B1 = true;
            B2 = false;
            B3 = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            B1 = false;
            B2 = true;
            B3 = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            B1 = false;
            B2 = false;
            B3 = true;
        }

        Debug.Log("player" + currentHealth);
    }

    private void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 shootdirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(shootdirection.y, shootdirection.x) * Mathf.Rad2Deg - 90f;
        bulletSpawn.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Vector3 shootDirection = (mousePosition - transform.position).normalized;
        
        if (B1)
        {
            Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }

        if (B2)
        {
            Instantiate(bulletPrefab2, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }

        if (B3)
        {
            Instantiate(bulletPrefab3, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }

        //Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(shootdirection * shootForce, ForceMode2D.Impulse);
        }
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("take damaged");
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0f)
        {
            animator.SetTrigger("Death");
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}

