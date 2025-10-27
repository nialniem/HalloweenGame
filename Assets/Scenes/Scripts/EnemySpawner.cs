using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public float minSpawnRadius = 5f;
    public float spawnInterval = 2f;
    public int enemiesPerSpawn = 2;
    public float intervalIncrement = 1f; // How much to increase interval each time

    private int currentLevel = 1; // Starts from 1 (15 points)
    private Score scoreScript;

    void Start()
    {
        scoreScript = FindObjectOfType<Score>();

        if (scoreScript == null)
        {
            Debug.LogError("Score script not found in the scene.");
            return;
        }

        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void Update()
    {
        int score = scoreScript.GetScore();

        if (score >= currentLevel * 15)
        {
            spawnInterval += intervalIncrement;
            CancelInvoke(nameof(SpawnEnemy));
            InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
            currentLevel++;

            Debug.Log($"Spawn interval increased to {spawnInterval} after reaching {score} points.");
        }
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

            enemy.transform.rotation = Quaternion.identity;

            SpriteRenderer sr = enemy.GetComponentInChildren<SpriteRenderer>();
            if (sr != null)
            {
                sr.flipX = (direction.x < 0);
            }

            PumpkinEnemy enemyScript = enemy.GetComponent<PumpkinEnemy>();
            if (enemyScript != null)
            {
                enemyScript.SetMovementDirection(direction);
            }
        }
    }
}
