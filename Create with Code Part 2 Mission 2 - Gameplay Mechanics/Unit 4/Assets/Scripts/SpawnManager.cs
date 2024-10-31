using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) 
        {
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            waveNumber ++;
            SpawnEnemyWave(waveNumber);

        }
    }

    private Vector3 GenerateSpawnPosition() 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnposZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnposZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn) 
    { 
        for (int i = 0; i < enemiesToSpawn; i++) 
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
          
    }
}
