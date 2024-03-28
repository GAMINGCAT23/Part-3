using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Enemy
{
    public float damage = 5f;
    public float dashSpeed = 10f;

    private bool isReady = false;
    private bool isDashing = false;

    protected override void Update()
    {
        base.Update();

        if (!isReady && !isDashing)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer < 5f)
            {
                StartCoroutine(DashReady());
            }
        }
    }

    IEnumerator DashReady()
    {
        isReady = true;
        yield return new WaitForSeconds(1f);
        isReady = false;
        StartCoroutine(Dash());
    }

    IEnumerator DashCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            isDashing = false;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;

        Debug.Log("dashing");

        Vector2 direction = (player.position - transform.position).normalized;

        while (Vector2.Distance(transform.position, player.position) > 0.1f)
        {
            transform.Translate(direction * dashSpeed * Time.deltaTime);
            yield return null;
        }

        if (Vector2.Distance(transform.position, player.position) <= 0.1f)
        {
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
        }

        StartCoroutine(DashCooldown());
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D (other);

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
