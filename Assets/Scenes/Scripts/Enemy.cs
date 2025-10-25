using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Rigidbody rb;
    public float moveSpeed = 2f;

    private void Update()
    {
        Vector3 targetPosition = Vector3.zero; // Center of the world
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("osuu");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject); // Or play death animation, disable AI, etc.
    }

}
