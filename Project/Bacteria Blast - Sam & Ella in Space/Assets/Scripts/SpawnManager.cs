using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bacteriaPrefabs;
    public GameObject[] asteroidPrefabs;
    public GameObject[] powerUpPrefabs;
    private float spawnRangeY = 9;
    private float spawnPosX = -35;
    private float spawnPosZ = -2;
    private GameManager gameManager;
    private float bacteriaStartDelay = 1;
    private float asteroidStartDelay = 2;
    private float powerUpStartDelay = 3;
    private float bacteriaSpawnInterval = 1;
    private float asteroidSpawnInterval = 3;
    private float powerUpSpawnInterval = 4;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBacteria()

    {

        if (gameManager.gameOver == false)
        {
            int bacteriumindex = Random.Range(0, bacteriaPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), spawnPosZ);


            Instantiate(bacteriaPrefabs[bacteriumindex], spawnPos, bacteriaPrefabs[bacteriumindex].transform.rotation);
        }

    }

    void SpawnAsteroids() 
    {
        if (gameManager.gameOver == false)
        {
            int asteroidindex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), spawnPosZ);


            Instantiate(asteroidPrefabs[asteroidindex], spawnPos, bacteriaPrefabs[asteroidindex].transform.rotation);
        }

    }

    void SpawnPowerUps()
    {
        if (gameManager.gameOver == false)
        {
            int powerUpindex = Random.Range(0, powerUpPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), spawnPosZ);


            Instantiate(powerUpPrefabs[powerUpindex], spawnPos, powerUpPrefabs[powerUpindex].transform.rotation);
        }

    }
    public void StartSpawn()

    {
            InvokeRepeating("SpawnBacteria", bacteriaStartDelay, bacteriaSpawnInterval);
            InvokeRepeating("SpawnAsteroids", asteroidStartDelay, asteroidSpawnInterval);
            InvokeRepeating("SpawnPowerUps", powerUpStartDelay, powerUpSpawnInterval);
    }
}
