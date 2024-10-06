using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    public int score;
    public int fuel;
    public int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI livesText;
    public bool gameStarted;
    public bool gameOver;
    private SpawnManager spawnManager;
    public GameObject player;

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
        scoreText.text = "SCORE:" + score;

    }

    public void StartGame()
    { 
            gameStarted = true;
            fuel = 100;
            lives = 3;
            score = 0;
            scoreText.text = "SCORE: " + score;
            livesText.text = "LIVES: " + lives;
            spawnManager.StartSpawn();        
                 
    }

    public void IncreaseFuel(int value)
    { 
        fuel += value;

        if (fuel > 100)
        {
            fuel = 100;

        }
        fuelText.text = "FUEL:" + fuel + " %";
        
    }

    public void AddLives(int value)
    {
        lives += value;

        // When lives are 0, game is over, you lose
        if (lives <= 0)
        {
            livesText.text = "LIVES: " + lives;
            lives = 0;
            gameOver = true;
            
        }
        else

        {
            livesText.text = "LIVES: "+ lives;
        }

    }

}
