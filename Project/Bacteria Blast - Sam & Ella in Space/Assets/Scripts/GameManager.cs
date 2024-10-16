using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public int score;
    public int fuel;
    public int lives;
    public int redRemaining;
    public int blueRemaining;
    public int purpleRemaining;
    public int redCollected;
    public int blueCollected;
    public int purpleCollected;
    public int music;
    public TMP_InputField playerName;
    public GameObject winScreen;
    public GameObject gameScreen;
    public GameObject gameScreenEndless;
    public TextMeshProUGUI winText;
    public GameObject player;
    public GameObject loseScreen;
    public TextMeshProUGUI loseText;
    public GameObject titleScreen;
    public TextMeshProUGUI redRemainText;
    public TextMeshProUGUI blueRemainText;
    public TextMeshProUGUI purpleRemainText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI redCollectText;
    public TextMeshProUGUI blueCollectText;
    public TextMeshProUGUI purpleCollectText;
    public TextMeshProUGUI fuelEndlessText;
    public TextMeshProUGUI livesEndlessText;
    public TextMeshProUGUI scoreText;
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;
    public AudioSource track4;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public bool player1;
    public bool player2;
    public bool player3;
    public bool gameStarted;
    public bool gameOver;
    public bool gameWin;
    public bool gameLose;
    public bool gameEndless;
    public int currentLevel;
    private SpawnManager spawnManager;
    public PlayerController playerController;
    private Rigidbody playerRb;
    public float gravityModifier;
    public Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();


    }

    public void Load()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();


        LoadVolume();
        LoadName();

        if (sceneName == "Sam & Ella in Space")
        {
            LoadMusic();

        }


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


        ResetGravity();
        gameScreen.SetActive(true);
        gameScreenEndless.SetActive(false);
        gameStarted = true;
        gameOver = false;
        gameWin = false;
        gameLose = false;
        redRemainText.text = "RED:" + redRemaining;
        blueRemainText.text = "BLUE:" + blueRemaining;
        purpleRemainText.text = "PURPLE:" + purpleRemaining;
        livesText.text = "LIVES: " + lives;
        fuelText.text = "FUEL: " + fuel;
        spawnManager.StartSpawn();

    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = playerName.text + "'s Score : " + score;
    }
   
    public void StartGameEndless(int level) 
    {

        if (level == 99)
        {
            currentLevel = 99;
            lives = 6;
            fuel = 100;

        }

        if (level == 98)
        {
            currentLevel = 98;
            lives = 4;
            fuel = 80;

        }

        if (level == 97)
        {
            currentLevel = 97;
            lives = 2;
            fuel = 50;

        }


        gameEndless = true;
        redCollected = 0;
        blueCollected = 0;
        purpleCollected = 0;
        ResetGravity();
        gameScreen.SetActive(false);
        gameScreenEndless.SetActive(true);
        gameStarted = true;
        gameOver = false;
        gameWin = false;
        gameLose = false;
        redCollectText.text = "RED:" + redCollected;
        blueCollectText.text = "BLUE:" + blueCollected;
        purpleCollectText.text = "PURPLE:" + purpleCollected;
        livesEndlessText.text = "LIVES: " + lives;
        fuelEndlessText.text = "FUEL: " + fuel;
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
        fuelEndlessText.text = "FUEL:" + fuel + " %";

    }

    public void AddLives(int value)
    {
        lives += value;

        // When lives are 0, game is over, you lose
        if (lives <= 0)
        {
            livesText.text = "LIVES: " + lives;
            livesEndlessText.text = "LIVES: " + lives;
            lives = 0;
            GameLose();

        }
        else

        {
            livesText.text = "LIVES: " + lives;
            livesEndlessText.text = "LIVES: " + lives;
        }
    }

    public void UpdateBacteriaBlasted()
    {

        if (gameEndless !=true) 
        {
            redRemainText.text = "RED:" + redRemaining;
            blueRemainText.text = "BLUE:" + blueRemaining;
            purpleRemainText.text = "PURPLE:" + purpleRemaining;

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
    

        if (gameEndless == true) 
        {
            redCollectText.text = "RED:" + redCollected;
            blueCollectText.text = "BLUE:" + blueCollected;
            purpleCollectText.text = "PURPLE:" + purpleCollected;

        }

    }

    public void GameWin()
    {

        winScreen.gameObject.SetActive(true);
        winText.SetText("CONGRATULATIONS, " + playerName.text + " - YOU HAVE COLLECTED ALL THE REQUIRED BACTERIAL SAMPLES!!!");


    }

    public void GameLose() 
    {
        StopMusic();
        gameOver = true;
        gameLose = true;
        loseScreen.gameObject.SetActive(true);
        loseText.SetText("SORRY," + playerName.text + " - THIS TIME YOU DIDN'T COLLECT ENOUGH BACTERIAL SAMPLES.");

    }

    
    public void ReloadScene() 
    {
        
        SceneManager.LoadScene("Sam & Ella in Space");

    }

    public void ResetGravity()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Physics.gravity *= gravityModifier;
    }

    public void StopMusic() 
    {
            track1.Stop();
            track2.Stop();
            track3.Stop();
            track4.Stop();
    }

    public void SaveName()
    {
        if (player1 == true)
        {
            PlayerPrefs.SetString("Player1Name", playerName.text);

        }

        if (player2 == true)
        {
            PlayerPrefs.SetString("Player2Name", playerName.text);

        }

        if (player3 == true)
        {
            PlayerPrefs.SetString("Player3Name", playerName.text);

        }
    }

    public void LoadName()
    {

        if (player1 == true)
        {
            playerName.text = PlayerPrefs.GetString("Player1Name", "A Biotic");

        }

        if (player2 == true)
        {
            playerName.text = PlayerPrefs.GetString("Player2Name", "A Biotic");

        }

        if (player3 == true)
        {
            playerName.text = PlayerPrefs.GetString("Player3Name", "A Biotic");

        }

    }

    public void SaveVolume()
    {
        if (player1 == true)
        {
            PlayerPrefs.SetFloat("MusicVolume1", musicSlider.value);
            PlayerPrefs.Save();
        }

        if (player2 == true)
        {
            PlayerPrefs.SetFloat("MusicVolume2", musicSlider.value);
            PlayerPrefs.Save();
        }

        if (player3 == true)
        {
            PlayerPrefs.SetFloat("MusicVolume3", musicSlider.value);
            PlayerPrefs.Save();
        }

    }

    public void LoadVolume()
    {
        if (player1 == true)
        {
            if (PlayerPrefs.HasKey("MusicVolume1"))
            {
                musicSlider.value = PlayerPrefs.GetFloat("MusicVolume1");
            }

            else musicSlider.value = 0.5f;

        }

        if (player2 == true)
        {
            if (PlayerPrefs.HasKey("MusicVolume2"))
            {
                musicSlider.value = PlayerPrefs.GetFloat("MusicVolume2");
            }

            else musicSlider.value = 0.5f;

        }

        if (player3 == true)
        {
            if (PlayerPrefs.HasKey("MusicVolume3"))
            {
                musicSlider.value = PlayerPrefs.GetFloat("MusicVolume3");
            }

            else musicSlider.value = 0.5f;

        }

    }

    public void SetMusic(int value)
    {
        music = value;


    }

    public void SaveMusic()
    {
        if (player1 == true)
        {
            PlayerPrefs.SetInt("Music1", music);
            PlayerPrefs.Save();
        }

        if (player2 == true)
        {
            PlayerPrefs.SetInt("Music2", music);
            PlayerPrefs.Save();
        }

        if (player3 == true)
        {
            PlayerPrefs.SetInt("Music3", music);
            PlayerPrefs.Save();
        }

    }

    public void LoadMusic()
    {

        if (player1 == true)
        {
            music = PlayerPrefs.GetInt("Music1");
        }

        if (player2 == true)
        {
            music = PlayerPrefs.GetInt("Music2");
        }

        if (player3 == true)
        {
            music = PlayerPrefs.GetInt("Music3");
        }

        if (music == 0)
        {
            track1.Play();
            track2.Stop();
            track3.Stop();
            track4.Stop();
            screen1.gameObject.SetActive(true);
            screen2.gameObject.SetActive(false);
            screen3.gameObject.SetActive(false);
            screen4.gameObject.SetActive(false);
        }


        if (music == 1)
        {
            track1.Play();
            track2.Stop();
            track3.Stop();
            track4.Stop();
            screen1.gameObject.SetActive(true);
            screen2.gameObject.SetActive(false);
            screen3.gameObject.SetActive(false);
            screen4.gameObject.SetActive(false);
        }

        if (music == 2)
        {
            track1.Stop();
            track2.Play();
            track3.Stop();
            track4.Stop();
            screen1.gameObject.SetActive(false);
            screen2.gameObject.SetActive(true);
            screen3.gameObject.SetActive(false);
            screen4.gameObject.SetActive(false);
        }


        if (music == 3)
        {
            track1.Stop();
            track2.Stop();
            track3.Play();
            track4.Stop();
            screen1.gameObject.SetActive(false);
            screen2.gameObject.SetActive(false);
            screen3.gameObject.SetActive(true);
            screen4.gameObject.SetActive(false);
        }

        if (music == 4)
        {
            track1.Stop();
            track2.Stop();
            track3.Stop();
            track4.Play();
            screen1.gameObject.SetActive(false);
            screen2.gameObject.SetActive(false);
            screen3.gameObject.SetActive(false);
            screen4.gameObject.SetActive(true);
        }

    }


}
