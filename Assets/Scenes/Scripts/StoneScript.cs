using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage. Current HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} (StoneStatue) died.");
        Destroy(gameObject); // Or play animation, etc.
    }

    private void OnTriggerEnter(Collider other)
    {
        // If an enemy hits the statue, take damage
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(5); // Example damage amount from enemy
        }
    }
}
