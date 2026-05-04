using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array for multiple enemies

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

        // Pick a random enemy from the array
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject chosenEnemy = enemyPrefabs[index];

        Instantiate(chosenEnemy, spawnPos, Quaternion.identity);
    }

    void IncreaseDifficulty()
    {
        spawnRate -= difficultyIncrease;

        if (spawnRate < minSpawnRate)
            spawnRate = minSpawnRate;

        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0.5f, spawnRate);
    }
}
