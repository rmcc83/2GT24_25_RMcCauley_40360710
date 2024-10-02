using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int fuel;
    public bool gameStarted;
    public bool gameOver;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log(score);

    }

    public void StartGame()
    { 
            gameStarted = true;
            fuel = 100;
            spawnManager.StartSpawn();
          
                 
    }
}
