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
        float radius = 1.2f;
        Vector3 center = transform.position + transform.forward * 0.6f;

        Collider[] hits = Physics.OverlapSphere(center, radius);
        HashSet<GameObject> damagedEnemies = new HashSet<GameObject>();

        foreach (Collider hit in hits)
        {
            GameObject target = hit.gameObject;

            if (target.CompareTag("Enemy") && !damagedEnemies.Contains(target))
            {
                target.GetComponent<Enemy>()?.TakeDamage(30);
                damagedEnemies.Add(target);
            }
        }
    }


}
