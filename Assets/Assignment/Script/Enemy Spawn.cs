using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 10f;
    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemies();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemies()
    {
        int enemyIndex1 = Random.Range(0, enemyPrefabs.Length);
        int enemyIndex2 = Random.Range(0, enemyPrefabs.Length);

        int spawnIndex1 = Random.Range(0, spawnPoints.Length);
        int spawnIndex2 = Random.Range(0, spawnPoints.Length);

        GameObject enemy1 = Instantiate(enemyPrefabs[enemyIndex1], spawnPoints[spawnIndex1].position, Quaternion.identity);
        GameObject enemy2 = Instantiate(enemyPrefabs[enemyIndex2], spawnPoints[spawnIndex2].position, Quaternion.identity);
    }
}
