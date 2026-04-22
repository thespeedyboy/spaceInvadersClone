using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnRate = 2f;
    public float minSpawnRate = 0.5f;
    public float difficultyIncrease = 0.1f;
    public float difficultyInterval = 5f;

    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 6f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
        InvokeRepeating("IncreaseDifficulty", difficultyInterval, difficultyInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    void IncreaseDifficulty()
    {
        // Make spawn faster
        spawnRate -= difficultyIncrease;

        if (spawnRate < minSpawnRate)
            spawnRate = minSpawnRate;

        // Restart spawning with new rate
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0.5f, spawnRate);
    }
}
