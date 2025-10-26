using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 2f;
    public int enemiesPerSpawn = 2;
    public float minSpawnRadius = 5f;


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

            // Pick a random point on a circle, scaled by a safe radius
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float distance = Random.Range(minSpawnRadius, spawnRadius); // ensures distance >= min

            Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * distance;
            Vector3 spawnPos = transform.position + offset;

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }


    
}
