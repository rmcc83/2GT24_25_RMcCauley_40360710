using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int score;
    public int fuel;
    public int lives;
    public int redRemaining;
    public int blueRemaining;
    public int purpleRemaining;
    public GameObject winScreen;
    public GameObject player;
    public GameObject loseScreen;
    public GameObject titleScreen;
    public TextMeshProUGUI redText;
    public TextMeshProUGUI blueText;
    public TextMeshProUGUI purpleText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI livesText;
    public bool gameStarted;
    public bool gameOver;
    public bool gameWin;
    public bool gameLose;
    public int currentLevel;
    private SpawnManager spawnManager;
    public PlayerController playerController;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
       

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBacteriaBlasted();


    }


    public void StartGame(int level)

    {
       
        if (level == 1)
        {
            currentLevel = 1;
            lives = 6;
            fuel = 100;
            redRemaining = 3;
            blueRemaining = 3;
            purpleRemaining = 3;

        }

        if (level == 2)
        {
            currentLevel = 2;
            lives = 5;
            fuel = 100;
            redRemaining = 5;
            blueRemaining = 5;
            purpleRemaining = 5;

        }

        if (level == 3)
        {
            currentLevel = 3;
            lives = 4;
            fuel = 100;
            redRemaining = 7;
            blueRemaining = 7;
            purpleRemaining = 7;

        }

        if (level == 4)
        {
            currentLevel = 4;
            lives = 3;
            fuel = 100;
            redRemaining = 9;
            blueRemaining = 9;
            purpleRemaining = 9;

        }

        if (level == 5)
        {
            currentLevel = 5;
            lives = 3;
            fuel = 75;
            redRemaining = 10;
            blueRemaining = 10;
            purpleRemaining = 10;

        }

        //   playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        Time.timeScale = 1;
        gameStarted = true;
        gameOver = false;
        gameWin = false;
        gameLose = false;
        redText.text = "RED:" + redRemaining;
        blueText.text = "BLUE:" + blueRemaining;
        purpleText.text = "PURPLE:" + purpleRemaining;
        livesText.text = "LIVES: " + lives;
        fuelText.text = "FUEL: " + fuel;
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
            gameLose = true;

        }
        else

        {
            livesText.text = "LIVES: " + lives;
        }
    }

    public void UpdateBacteriaBlasted()
    {
        redText.text = "RED:" + redRemaining;
        blueText.text = "BLUE:" + blueRemaining;
        purpleText.text = "PURPLE:" + purpleRemaining;

        if (redRemaining <= 0)
        {
            redRemaining = 0;

        }

        if (blueRemaining <= 0)
        {
            blueRemaining = 0;

        }

        if (purpleRemaining <= 0)
        {
            purpleRemaining = 0;

        }

        if (gameStarted == true && redRemaining == 0 && blueRemaining == 0 && purpleRemaining == 0)
        {
            gameOver = true;
            gameWin = true;
            GameWin();
        }

    }

    public void GameWin()
    {
        Time.timeScale = 0;
        winScreen.gameObject.SetActive(true);

    }

    public void GameLose() 
    {

        loseScreen.gameObject.SetActive(true);
    
    }

    public void NextLevel() 
    {
        Vector3 playerPos = new(-68.3f, 1.28f, -1);
        player.transform.position = playerPos;
        player.gameObject.SetActive(true);
        playerRb.constraints = RigidbodyConstraints.FreezeAll;

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Red Bacterium"))
        {
            Destroy(gameObj);

        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Blue Bacterium"))
        {
            Destroy(gameObj);

        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Purple Bacterium"))
        {
            Destroy(gameObj);

        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Virus"))
        {
            Destroy(gameObj);

        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            Destroy(gameObj);

        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Sonic Blaster PowerUp"))
        {
            Destroy(gameObj);

        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Fuel Large"))
        {
            Destroy(gameObj);

        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Fuel Small"))
        {
            Destroy(gameObj);

        }


        StartGame(currentLevel + 1);
    
    }

    public void RetryLevel() 
    {        
            Vector3 playerPos = new(-68.3f, 1.28f, -1);
            player.transform.position = playerPos;
            player.gameObject.SetActive(true);
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
       
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Red Bacterium"))
            {
                Destroy(gameObj);

            }

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Blue Bacterium"))
            {
            Destroy(gameObj);

            }

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Purple Bacterium"))
            {
            Destroy(gameObj);

            }

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Virus"))
            {
                Destroy(gameObj);

            }

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Asteroid"))
            {
            Destroy(gameObj);

            }

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Sonic Blaster PowerUp"))
            {
            Destroy(gameObj);

            }

             foreach (var gameObj in GameObject.FindGameObjectsWithTag("Fuel Large"))
             {
            Destroy(gameObj);

             }

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Fuel Small"))
            {
            Destroy(gameObj);

            }

            StartGame(currentLevel);

           
    }

    

}
