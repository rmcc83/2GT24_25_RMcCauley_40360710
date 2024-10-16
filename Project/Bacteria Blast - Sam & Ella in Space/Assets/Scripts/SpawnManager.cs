using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bacteriaPrefabs;
    public GameObject[] bacteriaPrefabsEndless;
    public GameObject[] asteroidPrefabs;
    public GameObject[] powerUpPrefabs;
    public GameObject[] virusPrefabs;
    public GameObject player;
    private float spawnRangeY = 8;
    private float spawnPosX = -35;
    private float bactSpawnPosZ = -2;
    private float virusSpawnZ = -0.5f;
    private float powerSpawnZ = -0.5f;
    private GameManager gameManager;
    private float bacteriaStartDelay = 1;
    private float asteroidStartDelay = 2;
    private float powerUpStartDelay = 4;
    private float virusStartDelay = 3;
    private float bacteriaSpawnInterval = 1;
    private float asteroidSpawnInterval = 1;
    private float powerUpSpawnInterval = 2;
    private float virusSpawnInterval = 2;


    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawns a random bacterium at a random position on the Y axis as long as game has started & is not over
    void SpawnBacteria()

    {

        if (gameManager.gameOver == false && gameManager.gameStarted == true)
        {
            int bacteriumindex = Random.Range(0, bacteriaPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), bactSpawnPosZ);


            Instantiate(bacteriaPrefabs[bacteriumindex], spawnPos, bacteriaPrefabs[bacteriumindex].transform.rotation);
        }

        else if (gameManager.gameOver == false && gameManager.gameStarted == true && gameManager.gameEndless == true) 
        {
            int bacteriumEndlessindex = Random.Range(0, bacteriaPrefabsEndless.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), bactSpawnPosZ);


            Instantiate(bacteriaPrefabsEndless[bacteriumEndlessindex], spawnPos, bacteriaPrefabsEndless[bacteriumEndlessindex].transform.rotation);
        }

    } 

    // Spawns a random asteroid at a random position on the Y axis as long as game is not over
    void SpawnAsteroids() 
    {
        if (gameManager.gameOver == false && gameManager.gameStarted == true)
        {
            int asteroidindex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), bactSpawnPosZ);


            Instantiate(asteroidPrefabs[asteroidindex], spawnPos, asteroidPrefabs[asteroidindex].transform.rotation);
        }

    }

    // Spawns a random powerup at a random position on the Y axis as long as game is not over
    void SpawnPowerUps()
    {
        if (gameManager.gameOver == false && gameManager.gameStarted == true)
            {
            int powerUpindex = Random.Range(0, powerUpPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), powerSpawnZ);


            Instantiate(powerUpPrefabs[powerUpindex], spawnPos, powerUpPrefabs[powerUpindex].transform.rotation);
        }

    }

    void SpawnVirus() 
    {
        if (gameManager.gameOver == false && gameManager.gameStarted == true)
            {
            int virusindex = Random.Range(0, virusPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), virusSpawnZ);


            Instantiate(virusPrefabs[virusindex], spawnPos, virusPrefabs[virusindex].transform.rotation);
        }

    }
    public void StartSpawn()

    {
                
            InvokeRepeating("SpawnBacteria", bacteriaStartDelay, bacteriaSpawnInterval);
            InvokeRepeating("SpawnAsteroids", asteroidStartDelay, asteroidSpawnInterval);
            InvokeRepeating("SpawnPowerUps", powerUpStartDelay, powerUpSpawnInterval);
            InvokeRepeating("SpawnVirus", virusStartDelay, virusSpawnInterval);        
    }

 
}
