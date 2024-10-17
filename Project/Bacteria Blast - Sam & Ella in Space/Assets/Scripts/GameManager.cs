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
    public GameObject highscoreCongrats;
    public GameObject highscoreDisplay;
    public GameObject lastscoreDisplay;
    public GameObject highscoreScreen;
    public TextMeshProUGUI highscoreCongratsText;
    public TextMeshProUGUI winText;
    public GameObject player;
    public GameObject loseScreen;
    public TextMeshProUGUI loseText;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverText;
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
    public TextMeshProUGUI endlessDifficultyText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI lastscoreText;
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
    public bool newHighscore;
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

        CheckHighScore();
        UpdateHighScoreDisplay();
        UpdateLastScoreDisplay();
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
        highscoreDisplay.SetActive(false);
        lastscoreDisplay.SetActive(false);
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
            endlessDifficultyText.text = "Difficulty: Easy";
        }

        if (level == 98)
        {
            currentLevel = 98;
            lives = 4;
            fuel = 80;
            endlessDifficultyText.text = "Difficulty: Medium";
        }

        if (level == 97)
        {
            currentLevel = 97;
            lives = 2;
            fuel = 50;
            endlessDifficultyText.text = "Difficulty: Hard";
        }


        gameEndless = true;
        redCollected = 0;
        blueCollected = 0;
        purpleCollected = 0;
        ResetGravity();
        gameScreen.SetActive(false);
        gameScreenEndless.SetActive(true);
        highscoreDisplay.SetActive(false);
        lastscoreDisplay.SetActive(false);
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

            if (gameEndless != true) 
            {
                GameLose();

            }

            if (gameEndless == true) 
            {

                GameOverLives();
            
            }
            

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
        StopMusic();
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

    public void GameOverCrash() 
    {
        StopMusic();
        gameOver = true;
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.SetText("SORRY, " + playerName.text + " - YOU CRASHED!  DON'T WORRY, RESCUE IS ON THE WAY!");
        CheckHighScore();
        SaveLastScore();
        UpdateHighScoreDisplay();
        UpdateLastScoreDisplay();
    }

    public void GameOverLives() 
    {

        StopMusic();
        gameOver = true;
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.SetText("SORRY, " + playerName.text + " - YOU COLLECTED TOO MANY VIRUSES!  BETTER LUCK NEXT TIME!");
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        CheckHighScore();
        SaveLastScore();
        UpdateHighScoreDisplay();
        UpdateLastScoreDisplay();
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

    public void CheckHighScore()
    {

        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            newHighscore = true;
            DisplayHighScoreNotification();
            PlayerPrefs.SetInt("Highscore", score);
            PlayerPrefs.SetString("Playername", playerName.text);
            PlayerPrefs.SetInt("Red", redCollected);
            PlayerPrefs.SetInt("Blue", blueCollected);
            PlayerPrefs.SetInt("Purple", purpleCollected);
            PlayerPrefs.SetString("Level", endlessDifficultyText.text);
        }

        // Easy Highscore

        if (currentLevel == 99)
        {
            if (score > PlayerPrefs.GetInt("EasyHighscore"))
            {
                newHighscore = true;
                DisplayHighScoreNotification();
                PlayerPrefs.SetInt("EasyHighscore", score);
                PlayerPrefs.SetString("EasyPlayername", playerName.text);
                PlayerPrefs.SetInt("EasyRed", redCollected);
                PlayerPrefs.SetInt("EasyBlue", blueCollected);
                PlayerPrefs.SetInt("EasyPurple", purpleCollected);
                PlayerPrefs.SetString("EasyDifficulty", endlessDifficultyText.text);
            }

        }

        //Medium Highscore

        if (currentLevel == 98)
        {
            if (score > PlayerPrefs.GetInt("MediumHighscore"))
            {             
                    newHighscore = true;
                    DisplayHighScoreNotification();
                    PlayerPrefs.SetInt("MediumHighscore", score);
                    PlayerPrefs.SetString("MediumPlayername", playerName.text);
                    PlayerPrefs.SetInt("MediumRed", redCollected);
                    PlayerPrefs.SetInt("MediumBlue", blueCollected);
                    PlayerPrefs.SetInt("MediumPurple", purpleCollected);
                    PlayerPrefs.SetString("MediumDifficulty", endlessDifficultyText.text);
                
            }

        }

        //Hard Highscore

        if (currentLevel == 97)
        {
            if (score > PlayerPrefs.GetInt("HardHighscore"))
            {
                newHighscore = true;
                DisplayHighScoreNotification();
                PlayerPrefs.SetInt("HardHighscore", score);
                PlayerPrefs.SetString("HardPlayername", playerName.text);
                PlayerPrefs.SetInt("HardRed", redCollected);
                PlayerPrefs.SetInt("HardBlue", blueCollected);
                PlayerPrefs.SetInt("HardPurple", purpleCollected);
                PlayerPrefs.SetString("HardDifficulty", endlessDifficultyText.text);
            }


        }
    }


    public void SaveLastScore()
    {
        PlayerPrefs.SetInt("LastGamescore", score);
        PlayerPrefs.SetString("LastGamePlayername", playerName.text);
        PlayerPrefs.SetInt("LastGameRed", redCollected);
        PlayerPrefs.SetInt("LastGameBlue", blueCollected);
        PlayerPrefs.SetInt("LastGamePurple", purpleCollected);
        PlayerPrefs.SetString("LastGameLevel", endlessDifficultyText.text);

    }

    public void UpdateHighScoreDisplay() => highscoreText.text = $" Endless Highscore: {PlayerPrefs.GetInt("Highscore")}" + $" Red: {PlayerPrefs.GetInt("Red")}" + $" Blue: {PlayerPrefs.GetInt("Blue")}" + $" Purple: {PlayerPrefs.GetInt("Purple")}" + $" by {PlayerPrefs.GetString("Playername")}" + $" on {PlayerPrefs.GetString("Level")}";

    public void UpdateLastScoreDisplay() => lastscoreText.text = $"Endless Last Game: {PlayerPrefs.GetInt("LastGamescore")}" + $" Red: {PlayerPrefs.GetInt("LastGameRed")}" + $" Blue: {PlayerPrefs.GetInt("LastGameBlue")}" + $" Purple: {PlayerPrefs.GetInt("LastGamePurple")}" + $" by {PlayerPrefs.GetString("LastGamePlayername")}" + $" on {PlayerPrefs.GetString("LastGameLevel")}";

    public void DisplayHighScoreNotification()
    {
        if (gameOver == true && newHighscore == true)
        {

            highscoreCongrats.gameObject.SetActive(true);
            highscoreCongratsText.SetText("YOU GOT A NEW HIGH SCORE, " + playerName.text + "!");
        }

    }

    public void ScoresOn()
    {
        highscoreScreen.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(false);
        lastscoreText.gameObject.SetActive(false);
    }

    // For hiding highscores
    public void ScoresOff()
    {
        highscoreScreen.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(true);
        lastscoreText.gameObject.SetActive(true);
    }


}
