using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
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
            Vector2 randomPoint = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;

            
            Vector3 spawnPos = transform.position + new Vector3(randomPoint.x, 0f, randomPoint.y);

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
