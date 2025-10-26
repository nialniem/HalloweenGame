using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Sword hit: " + other.name); // ? See this in console?

        if (other.CompareTag("Enemy"))
        {
            PumpkinEnemy enemy = other.GetComponent<PumpkinEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
