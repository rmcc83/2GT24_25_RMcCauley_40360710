using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bacteriaPrefabs; // array of bacteria prefabs
    public GameObject[] bacteriaPrefabsEndless; // array of bacteria prefabs used for endless game
    public GameObject[] asteroidPrefabs; //array of asteroid prefabs
    public GameObject[] powerUpPrefabs; //array of powerup prefabs
    public GameObject[] virusPrefabs; //array of virus prefabs
    public GameObject player;
    private float spawnRangeY = 8; // items spawn +8/-8 in Y direction
    private float spawnPosX = -35; // items spawn at -35 on x-axis
    private float bactSpawnPosZ = -2; // bacteria spawn at -2 on z-axis
    private float virusSpawnZ = -0.5f; // viruses spawn at -0.5 on z-axis
    private float powerSpawnZ = -0.5f; // powerups spawn at -0.5 on z-axis
    private GameManager gameManager;
    private float bacteriaStartDelay = 1; // delay before bacteria start to spawn is 1 sec
    private float asteroidStartDelay = 2; // delay before asteroids start to spawn is 2 sec
    private float powerUpStartDelay = 4; // delay before powerups start to spawn is 4 sec
    private float virusStartDelay = 3; // delay before viruses start to spawn is 3 sec
    private float bacteriaSpawnInterval = 1; // bacteria spawn every 1 second
    private float asteroidSpawnInterval = 1; // asteroids spawn every 1 second
    private float powerUpSpawnInterval = 2; // bacteria spawn every 2 seconds
    private float virusSpawnInterval = 2; // bacteria spawn every 2 seconds


    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawns a random bacterium at a random position on the Y axis as long as game has started & is not over.  Different array for endless game to
    // ensure there are fewer of the higher value ones spawned
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

    // Spawns a random asteroid at a random position on the Y axis as long as game has started & is not over
    void SpawnAsteroids() 
    {
        if (gameManager.gameOver == false && gameManager.gameStarted == true)
        {
            int asteroidindex = Random.Range(0, asteroidPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), bactSpawnPosZ);


            Instantiate(asteroidPrefabs[asteroidindex], spawnPos, asteroidPrefabs[asteroidindex].transform.rotation);
        }

    }

    // Spawns a random powerup at a random position on the Y axis as long as game has started & is not over
    void SpawnPowerUps()
    {
        if (gameManager.gameOver == false && gameManager.gameStarted == true)
            {
            int powerUpindex = Random.Range(0, powerUpPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), powerSpawnZ);


            Instantiate(powerUpPrefabs[powerUpindex], spawnPos, powerUpPrefabs[powerUpindex].transform.rotation);
        }

    }

    // spawns viruses at a random position on the Y axis as long as game has started & is not over
    void SpawnVirus() 
    {
        if (gameManager.gameOver == false && gameManager.gameStarted == true)
            {
            int virusindex = Random.Range(0, virusPrefabs.Length);
            Vector3 spawnPos = new(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), virusSpawnZ);


            Instantiate(virusPrefabs[virusindex], spawnPos, virusPrefabs[virusindex].transform.rotation);
        }

    }

    // Method which is called from gamemanager to spawn the objects.  Items are spawned after a delay, at particular intervals.
    public void StartSpawn()

    {
                
            InvokeRepeating("SpawnBacteria", bacteriaStartDelay, bacteriaSpawnInterval);
            InvokeRepeating("SpawnAsteroids", asteroidStartDelay, asteroidSpawnInterval);
            InvokeRepeating("SpawnPowerUps", powerUpStartDelay, powerUpSpawnInterval);
            InvokeRepeating("SpawnVirus", virusStartDelay, virusSpawnInterval);        
    }

 
}
