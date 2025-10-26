using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the object we are touching is the statue
        if (other.CompareTag("StoneStatue"))
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                StoneScript statue = other.GetComponent<StoneScript>();
                if (statue != null)
                {
                    statue.TakeDamage(damage);
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
