using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public float minSpawnRadius = 5f;
    public float spawnInterval = 2f;
    public int enemiesPerSpawn = 2;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemiesPerSpawn; i++)
        {
            if (enemyPrefab == null)
            {
                Debug.LogWarning("Enemy prefab is missing!");
                return;
            }

            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float distance = Random.Range(minSpawnRadius, spawnRadius);
            Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;
            Vector2 spawnPos = (Vector2)transform.position + offset;

            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            Vector2 direction = ((Vector2)Vector2.zero - spawnPos).normalized;

            // Keep upright
            enemy.transform.rotation = Quaternion.identity;

            // Flip sprite based on X direction
            SpriteRenderer sr = enemy.GetComponentInChildren<SpriteRenderer>();
            if (sr != null)
            {
                sr.flipX = (direction.x < 0);
            }

            // Optionally, set movement direction in enemy script
            PumpkinEnemy enemyScript = enemy.GetComponent<PumpkinEnemy>();
            if (enemyScript != null)
            {
                enemyScript.SetMovementDirection(direction);
            }
        }
    }

}
