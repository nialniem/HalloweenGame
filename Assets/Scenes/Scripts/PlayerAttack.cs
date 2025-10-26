using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public float attackDuration = 0.3f;
    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            Invoke(nameof(ResetAttack), attackDuration);
        }
    }

    void ResetAttack()
    {
        isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isAttacking) return;

        if (other.CompareTag("Enemy"))
        {
            PumpkinEnemy enemy = other.GetComponent<PumpkinEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Hit enemy: " + other.name);
                isAttacking = false; // Optional: stop hitting until next swing
            }
        }
    }
}
