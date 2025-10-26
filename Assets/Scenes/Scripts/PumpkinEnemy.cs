using UnityEngine;

public class PumpkinEnemy : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    private Rigidbody2D rb;
    public float moveSpeed = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Prevent falling
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        Vector2 targetPosition = Vector2.zero; // Center of the world
        Vector2 direction = (targetPosition - rb.position).normalized;

        // Move using Rigidbody2D
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

        // Rotate to face movement direction
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
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
                scoreScript.AddPoints(1);
            }
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }
}
