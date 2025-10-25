using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    private int hitRange = 1;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        float radius = 2f;
        Vector3 attackOrigin = transform.position + transform.forward * 0.6f;

        Collider[] hits = Physics.OverlapSphere(attackOrigin, radius);
        HashSet<GameObject> damagedEnemies = new HashSet<GameObject>();

        foreach (Collider hit in hits)
        {
            GameObject target = hit.gameObject;

            if (target != null && target.CompareTag("Enemy") && !damagedEnemies.Contains(target))
            {
                Enemy enemy = target.GetComponent<Enemy>();

                if (enemy != null)
                {
                    damagedEnemies.Add(target);
                    enemy.TakeDamage(999);
                }
            }
        }
    }




}
