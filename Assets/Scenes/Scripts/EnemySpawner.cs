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

            // Pick a random point on a ring (min to max radius)
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float distance = Random.Range(minSpawnRadius, spawnRadius);
            Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;
            Vector2 spawnPos = (Vector2)transform.position + offset;

            // Spawn the enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // Make it face toward the center (0, 0) or your statue
            Vector2 direction = (Vector2.zero - spawnPos).normalized;
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemy.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            // Optional: flip sprite if facing left by default
            SpriteRenderer sr = enemy.GetComponentInChildren<SpriteRenderer>();
            if (sr != null)
            {
                sr.flipX = direction.x > 0;
            }
        }
    }
}
