using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;
    private Rigidbody rb;
    public float moveSpeed = 2f;

    private void Update()
    {
        Vector3 targetPosition = Vector3.zero; // Center of the world
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        Vector3 direction = (Vector3.zero - transform.position).normalized;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage. Current HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
            Score scoreScript = FindObjectOfType<Score>();
            if (scoreScript != null)
            {
                scoreScript.AddPoints(1); // Or however many points
            }
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject); // Or play death animation, disable AI, etc.
    }

}
