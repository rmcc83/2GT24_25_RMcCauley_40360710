using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



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
    public GameObject bestTimeCongrats;
    public GameObject highscoreDisplay;
    public GameObject lastscoreDisplay;
    public GameObject highscoreScreen;
    public GameObject timesScreen;
    public GameObject helpScreen;
    public TextMeshProUGUI highscoreCongratsText;
    public TextMeshProUGUI bestTimeCongratsText;
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
    public GameObject pauseButtonEndless;
    public GameObject pauseButton;
    public GameObject quitButtonEndless;
    public GameObject quitButton;
    public GameObject pauseScreen;
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
    public bool newBestTime;
    public bool paused;
    public int currentLevel;
    private SpawnManager spawnManager;
    public PlayerController playerController;
    private Rigidbody playerRb;
    public float gravityModifier;
    public Slider musicSlider;
    private AudioSource gameAudio;
    public AudioClip buttonSound;
    public float timeElapsed = 0;
    public TextMeshProUGUI timerText; // endless levels
    public TextMeshProUGUI timerText2; // 'normal' levels
    public float currentLevel1BestTime;
    public float currentLevel2BestTime;
    public float currentLevel3BestTime;
    public float currentLevel4BestTime;
    public float currentLevel5BestTime;

    // Start is called before the first frame update
    void Start()
    {

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
        gameAudio = GetComponent<AudioSource>();


    }

    public void Load()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        CheckHighScore(); // run check highscore method
        UpdateHighScoreDisplay(); // run update highscore display method
        UpdateLastScoreDisplay(); // run update last score display method
        LoadVolume(); // run load voulme method
        LoadName(); // run load name method

        // if main scene, music load method is run
        if (sceneName == "Sam & Ella in Space")
        {
            LoadMusic();

        }

        playerController.LoadSkin();


    }

    // Update is called once per frame
    void Update()
    {

        UpdateBacteriaBlasted(); // runs the bacteria blasted method

        // Run the timer when the game starts in endless mode & stop it when game is over
        if (gameStarted == true && !gameOver)
        {
            RunTimer();

        }

        //Check if the user has pressed the P key - only works in main scene if game has started, so won't show pause screen when names being entered
        if (Input.GetKeyDown(KeyCode.P) && gameStarted == true)
        {
            CheckForPause();
        }


    }


    public void StartGame(int level) // level number is passed in from level select button.  Starting lives, starting fuel, amount of bacteria which
                                     // must be collected to win are set depending on the level selected.

    {

        if (level == 1)
        {
            currentLevel = 1;
            lives = 6;
            fuel = 100;
            redRemaining = 1;
            blueRemaining = 0;
            purpleRemaining = 0;

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

        // The below happens for all the levels which call this method
        ResetGravity(); // run reset gravity method - necessary to ensure gravity does not increase each time game is played, as gravity modifier is being utilised
        gameScreen.SetActive(true); // sets gamescreen (with score, fuel etc) active
        gameScreenEndless.SetActive(false); // sets endless game screen inactive
        highscoreDisplay.SetActive(false); // sets highscore display inactive
        lastscoreDisplay.SetActive(false); // sets last score display inactive
        gameStarted = true; // flags that game has started
        gameOver = false; // flags that game is not over
        gameWin = false; //sets game win flag flase
        gameLose = false; //sets game lose flag false
        redRemainText.text = "RED:" + redRemaining; // displays red bacteria remaining
        blueRemainText.text = "BLUE:" + blueRemaining; // displays blue bacteria remaining
        purpleRemainText.text = "PURPLE:" + purpleRemaining; // displays purple bacteria remaining
        livesText.text = "LIVES: " + lives; //displays lives remaining
        fuelText.text = "FUEL: " + fuel + "%"; //displays fuel remaining
        spawnManager.StartSpawn(); // runs start spawn method from spawnmanager
        SaveName(); // runs savename method

    }

    // Adds appropriate value to score when bacteria collected, and updates score display
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = playerName.text.ToUpper() + "'S Score : " + score;
    }


    public void StartGameEndless(int level) // level number is passed in from level select button.  Starting lives,
                                            // starting fuel, difficulty in words is set depending on (endless) level selected.
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


        gameEndless = true; // flags endless game is selected
        redCollected = 0; //sets red collected to 0
        blueCollected = 0; //sets blue collected to 0
        purpleCollected = 0; //sets purple collected to 0
        ResetGravity(); // run reset gravity method - necessary to ensure gravity does not increase each time game is played, as gravity modifier is being utilised
        gameScreen.SetActive(false); // sets normal game screen off
        gameScreenEndless.SetActive(true); // sets endless game screen on
        highscoreDisplay.SetActive(false); // turns highscore display off
        lastscoreDisplay.SetActive(false); //turns lastscore display off
        gameStarted = true; //flags game started
        gameOver = false; //game over set to false
        gameWin = false; //gamewin set to false
        gameLose = false; //gamelose set to false
        scoreText.text = playerName.text.ToUpper() + "'S SCORE : " + score; //displays score along with player name
        redCollectText.text = "RED:" + redCollected; //displays red bacteria collected
        blueCollectText.text = "BLUE:" + blueCollected; //displays blue bacteria collected
        purpleCollectText.text = "PURPLE:" + purpleCollected; //displays purple bacteria collected
        livesEndlessText.text = "LIVES: " + lives; //displays lives remaining
        fuelEndlessText.text = "FUEL: " + fuel + "%"; //displays fuel remaining
        spawnManager.StartSpawn(); //calls startspawn method from spawnmanager
        SaveName(); //runs savename method




    }

    // increases fuel by appropriate amount when powerup is collected, and displays it.  Fuel cannot go above 100%.
    public void IncreaseFuel(int value)
    {

        fuel += value;

        if (fuel > 100)
        {
            fuel = 100;

        }
        fuelText.text = "FUEL:" + fuel + "%";
        fuelEndlessText.text = "FUEL:" + fuel + "%";

    }

    // Adjusts lives & displays current amount
    public void AddLives(int value)
    {
        lives += value;

        // When lives are 0, game is over, you lose.  MEthod called will depend on game mode currently being played
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

    // updates bacteria numbers display
    public void UpdateBacteriaBlasted()
    {

        if (gameEndless != true)  //if endless game is not being played
        {
            redRemainText.text = "RED:" + redRemaining; // display remaining red
            blueRemainText.text = "BLUE:" + blueRemaining; //display remaining blue
            purpleRemainText.text = "PURPLE:" + purpleRemaining; //display remaining purple

            if (redRemaining <= 0) //ensures remaining red will not go below 0, so collecting more than required is no advantage
            {
                redRemaining = 0;

            }

            if (blueRemaining <= 0) //ensures remaining blue will not go below 0, so collecting more than required is no advantage
            {
                blueRemaining = 0;

            }

            if (purpleRemaining <= 0) //ensures remaining purple will not go below 0, so collecting more than required is no advantage
            {
                purpleRemaining = 0;

            }

            // if game has started and all remaining bacteria is 0, game is over, game is won, and gamewin method is run
            if (gameStarted == true && redRemaining == 0 && blueRemaining == 0 && purpleRemaining == 0)
            {
                gameOver = true;
                gameWin = true;
                GameWin();
            }

        }


        if (gameEndless == true) // if endless game is being played
        {
            redCollectText.text = "RED:" + redCollected; // displays number of red bacteria collected
            blueCollectText.text = "BLUE:" + blueCollected; // displays number of blue bacteria collected
            purpleCollectText.text = "PURPLE:" + purpleCollected; // displays number of purple bacteria collected

        }

    }

    public void GameWin() // at gamewin, music stops, win screen is displayed, player object motion is fully constrained so it freezes in place,
                          // & a personalised message is displayed
    {
        StopMusic();
        winScreen.gameObject.SetActive(true);
        winText.SetText("CONGRATULATIONS, " + playerName.text.ToUpper() + " - YOU HAVE COLLECTED ALL THE REQUIRED BACTERIAL SAMPLES!!!"); // player name is included in message, & forced to upper case
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        CheckBestTime(); // check if time is a new best for that level
        pauseButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

    }

    public void GameLose() // at game lose, music stops, game is over, game is lost, lose screen is displayed, personalised message is displayed
    {
        StopMusic();
        gameOver = true;
        gameLose = true;
        loseScreen.gameObject.SetActive(true);
        loseText.SetText("SORRY," + playerName.text.ToUpper() + " - THIS TIME YOU DIDN'T COLLECT ENOUGH BACTERIAL SAMPLES."); // player name is included in message, & forced to upper case
        pauseButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    public void GameOverCrash() // method used in endless game when player crashes.  Music stops, gameover screen is displayed, personalised message is displayed,
                                // score is checked against saved highscore, score is saved as last score, highscore & last score displays are updated
    {
        StopMusic();
        gameOver = true;
        pauseButtonEndless.gameObject.SetActive(false);
        quitButtonEndless.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.SetText("SORRY, " + playerName.text.ToUpper() + " - YOU CRASHED!  DON'T WORRY, RESCUE IS ON THE WAY!"); // player name is included in message, & forced to upper case
        CheckHighScore();
        SaveLastScore();
        UpdateHighScoreDisplay();
        UpdateLastScoreDisplay();
    }

    public void GameOverLives() // method used in endless game when player runs out of lives.  Music stops, gameover screen is displayed, personalised message is displayed,
                                // player object motion is fully constrained so it freezes in place, score is checked against saved highscore, score is saved as last score,
                                // highscore & last score displays are updated
    {

        StopMusic();
        gameOver = true;
        pauseButtonEndless.gameObject.SetActive(false);
        quitButtonEndless.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.SetText("SORRY, " + playerName.text.ToUpper() + " - YOU COLLECTED TOO MANY VIRUSES!  BETTER LUCK NEXT TIME!"); // player name is included in message, & forced to upper case
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        CheckHighScore();
        SaveLastScore();
        UpdateHighScoreDisplay();
        UpdateLastScoreDisplay();
    }


    //method called to reload main scene
    public void ReloadScene()
    {

        SceneManager.LoadScene("Sam & Ella in Space");

    }

    public void ResetGravity() // resets gravity to default, then multiplies it by gravity modifier.  If this is not run each time the game is played, gravity will increase each time
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Physics.gravity *= gravityModifier;
    }

    public void StopMusic() //stops music entirely
    {
        track1.Stop();
        track2.Stop();
        track3.Stop();
        track4.Stop();
    }

    public void SaveName() // saves entered player name against particular key in playerprefs
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

    public void LoadName() // allows previously saved player name in particular slot to be loaded from playerprefs
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

    public void SaveVolume() // saves current volume setting in player prefs for particular player profile
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

    public void LoadVolume() //loads previously saved volume setting for that player profile from playerprefs.  If no saved value, defaults to 50%
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

    public void SetMusic(int value) // sets music to particular track
    {
        music = value;


    }

    public void SaveMusic() //saves set music track against current player profile in playerprefs
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

    public void LoadMusic() //loads music setting for current player from playerprefs, and then plays appropriate tune & sets appropriate 'radio' screen to match
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

    public void CheckHighScore() //handles checking for highscore & saving highscores
    {

        if (score > PlayerPrefs.GetInt("Highscore")) //if current score is higher than saved highscore, new highscore flag is true, new high score notification is displayed,
                                                     //and score/playername/bacteria collected/difficulty are saved in playerprefs against overall highscore key
        {
            newHighscore = true;
            DisplayHighScoreNotification();
            PlayerPrefs.SetInt("Highscore", score);
            PlayerPrefs.SetString("Playername", playerName.text.ToUpper());
            PlayerPrefs.SetInt("Red", redCollected);
            PlayerPrefs.SetInt("Blue", blueCollected);
            PlayerPrefs.SetInt("Purple", purpleCollected);
            PlayerPrefs.SetString("Level", endlessDifficultyText.text);
            PlayerPrefs.SetString("Time", timerText.text);
        }

        // Checks/saves highscore in playerprefs for easy level

        if (currentLevel == 99)
        {
            if (score > PlayerPrefs.GetInt("EasyHighscore"))
            {
                newHighscore = true;
                DisplayHighScoreNotification();
                PlayerPrefs.SetInt("EasyHighscore", score);
                PlayerPrefs.SetString("EasyPlayername", playerName.text.ToUpper());
                PlayerPrefs.SetInt("EasyRed", redCollected);
                PlayerPrefs.SetInt("EasyBlue", blueCollected);
                PlayerPrefs.SetInt("EasyPurple", purpleCollected);
                PlayerPrefs.SetString("EasyDifficulty", endlessDifficultyText.text);
                PlayerPrefs.SetString("EasyTime", timerText.text);
            }

        }

        // Checks/saves highscore in playerprefs for medium level

        if (currentLevel == 98)
        {
            if (score > PlayerPrefs.GetInt("MediumHighscore"))
            {
                newHighscore = true;
                DisplayHighScoreNotification();
                PlayerPrefs.SetInt("MediumHighscore", score);
                PlayerPrefs.SetString("MediumPlayername", playerName.text.ToUpper());
                PlayerPrefs.SetInt("MediumRed", redCollected);
                PlayerPrefs.SetInt("MediumBlue", blueCollected);
                PlayerPrefs.SetInt("MediumPurple", purpleCollected);
                PlayerPrefs.SetString("MediumDifficulty", endlessDifficultyText.text);
                PlayerPrefs.SetString("MediumTime", timerText.text);

            }

        }

        // Checks/saves highscore in playerprefs for hard level

        if (currentLevel == 97)
        {
            if (score > PlayerPrefs.GetInt("HardHighscore"))
            {
                newHighscore = true;
                DisplayHighScoreNotification();
                PlayerPrefs.SetInt("HardHighscore", score);
                PlayerPrefs.SetString("HardPlayername", playerName.text.ToUpper());
                PlayerPrefs.SetInt("HardRed", redCollected);
                PlayerPrefs.SetInt("HardBlue", blueCollected);
                PlayerPrefs.SetInt("HardPurple", purpleCollected);
                PlayerPrefs.SetString("HardDifficulty", endlessDifficultyText.text);
                PlayerPrefs.SetString("HardTime", timerText.text);
            }


        }
    }

    public void CheckBestTime() //handles checking for best time & saving best time
    {

        // Checks/saves best time in playerprefs for level 1, if no previous time saved, will check against a default of 3599 i.e
        // 59 mins 59 seconds

        if (currentLevel == 1)
        {
            currentLevel1BestTime = (PlayerPrefs.GetFloat("Level1BestTime", 3599));

            if (timeElapsed < currentLevel1BestTime)
            {
                newBestTime = true;
                DisplayBestTimeNotification();
                PlayerPrefs.SetString("Level1Playername", playerName.text.ToUpper()); ;
                PlayerPrefs.SetFloat("Level1BestTime", timeElapsed);
            }

        }

        // Checks/saves best time in playerprefs for level 2, if no previous time saved, will check against a default of 3599

        if (currentLevel == 2)
        {
            currentLevel2BestTime = (PlayerPrefs.GetFloat("Level2BestTime", 3599));

            if (timeElapsed < currentLevel2BestTime)
            {
                newBestTime = true;
                DisplayBestTimeNotification();
                PlayerPrefs.SetString("Level2Playername", playerName.text.ToUpper()); ;
                PlayerPrefs.SetFloat("Level2BestTime", timeElapsed);
            }

        }

        // Checks/saves best time in playerprefs for level 3, if no previous time saved, will check against a default of 3599

        if (currentLevel == 3)
        {
            currentLevel3BestTime = (PlayerPrefs.GetFloat("Level3BestTime", 3599));

            if (timeElapsed < currentLevel3BestTime)
            {
                newBestTime = true;
                DisplayBestTimeNotification();
                PlayerPrefs.SetString("Level3Playername", playerName.text.ToUpper()); ;
                PlayerPrefs.SetFloat("Level3BestTime", timeElapsed);
            }

        }

        // Checks/saves best time in playerprefs for level 4, if no previous time saved, will check against a default of 3599

        if (currentLevel == 4)
        {
            currentLevel4BestTime = (PlayerPrefs.GetFloat("Level4BestTime", 3599));

            if (timeElapsed < currentLevel4BestTime)
            {
                newBestTime = true;
                DisplayBestTimeNotification();
                PlayerPrefs.SetString("Level4Playername", playerName.text.ToUpper()); ;
                PlayerPrefs.SetFloat("Level4BestTime", timeElapsed);
            }

        }

        // Checks/saves best time in playerprefs for level 5, if no previous time saved, will check against a default of 3599 

        if (currentLevel == 5)
        {
            currentLevel5BestTime = (PlayerPrefs.GetFloat("Level5BestTime", 3599));

            if (timeElapsed < currentLevel5BestTime)
            {
                newBestTime = true;
                DisplayBestTimeNotification();
                PlayerPrefs.SetString("Level5Playername", playerName.text.ToUpper()); ;
                PlayerPrefs.SetFloat("Level5BestTime", timeElapsed);
            }

        }
    }

    // saves score/player/bacteria collected/difficulty for current game in player prefs
    public void SaveLastScore()
    {
        PlayerPrefs.SetInt("LastGamescore", score);
        PlayerPrefs.SetString("LastGamePlayername", playerName.text);
        PlayerPrefs.SetInt("LastGameRed", redCollected);
        PlayerPrefs.SetInt("LastGameBlue", blueCollected);
        PlayerPrefs.SetInt("LastGamePurple", purpleCollected);
        PlayerPrefs.SetString("LastGameLevel", endlessDifficultyText.text);
        PlayerPrefs.SetString("LastTime", timerText.text);

    }

    // updates high score display with saved values from player prefs
    public void UpdateHighScoreDisplay() => highscoreText.text = $" Endless Highscore: {PlayerPrefs.GetInt("Highscore")}" + $" Red: {PlayerPrefs.GetInt("Red")}" + $" Blue: {PlayerPrefs.GetInt("Blue")}" + $" Purple: {PlayerPrefs.GetInt("Purple")}" + $" {PlayerPrefs.GetString("Time")}" + $" by {PlayerPrefs.GetString("Playername")}" + $" on {PlayerPrefs.GetString("Level")}";

    // updates last score display with saved values from player prefs
    public void UpdateLastScoreDisplay() => lastscoreText.text = $"Endless Last Game: {PlayerPrefs.GetInt("LastGamescore")}" + $" Red: {PlayerPrefs.GetInt("LastGameRed")}" + $" Blue: {PlayerPrefs.GetInt("LastGameBlue")}" + $" Purple: {PlayerPrefs.GetInt("LastGamePurple")}" + $" {PlayerPrefs.GetString("LastTime")}" + $" by {PlayerPrefs.GetString("LastGamePlayername")}" + $" on {PlayerPrefs.GetString("LastGameLevel")}";

    public void DisplayHighScoreNotification() // if gameover is true and new highscore is true, personalised notification is displayed 
    {
        if (gameOver == true && newHighscore == true)
        {

            highscoreCongrats.gameObject.SetActive(true);
            highscoreCongratsText.SetText("YOU GOT A NEW HIGH SCORE, " + playerName.text.ToUpper() + "!"); //ensures player name is displayed in upper case
        }

    }

    public void DisplayBestTimeNotification() // if gameover is true and new best time is true, personalised notification is displayed 
    {
        if (gameOver == true && newBestTime == true)
        {

            bestTimeCongrats.gameObject.SetActive(true);
            bestTimeCongratsText.SetText("YOU GOT A NEW BEST TIME, " + playerName.text.ToUpper() + "!"); //ensures player name is displayed in upper case
        }

    }

    // For showing highscore screen
    public void ScoresOn() //displays highscore screen & ensures overall highscore & last game score are hidden
    {
        highscoreScreen.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(false);
        lastscoreText.gameObject.SetActive(false);
    }

    // For hiding highscores
    public void ScoresOff() //hides highscore screen & ensures overall highscore & last game score are visible again
    {
        highscoreScreen.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(true);
        lastscoreText.gameObject.SetActive(true);
    }

    // For showing best times screen
    public void TimesOn() //displays best times screen & ensures overall highscore & last game score are hidden
    {
        timesScreen.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(false);
        lastscoreText.gameObject.SetActive(false);
    }

    // For hiding best times
    public void TimesOff() //hides best times screen & ensures overall highscore & last game score are visible again
    {
        timesScreen.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(true);
        lastscoreText.gameObject.SetActive(true);
    }

    public void HelpOn() //displays controls screen & ensures overall highscore & last game score are hidden
    {
        helpScreen.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(false);
        lastscoreText.gameObject.SetActive(false);
    }

    // For hiding highscores
    public void HelpOff() //hides controls screen & ensures overall highscore & last game score are visible again
    {
        helpScreen.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(true);
        lastscoreText.gameObject.SetActive(true);
    }

    // To play button click sounds
    public void ButtonSound()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
    }

    void RunTimer()
    {
        timeElapsed += Time.deltaTime;
        var timeSpan = TimeSpan.FromSeconds(timeElapsed);
        timerText.text = "" + string.Format(" {0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
        timerText2.text = "" + string.Format(" {0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);


    }
    //Clears all high scores & player names when GUI button pressed
    public void ClearHighScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        PlayerPrefs.SetString("Playername", "A Biotic");
        PlayerPrefs.SetInt("Red", 0);
        PlayerPrefs.SetInt("Blue", 0);
        PlayerPrefs.SetInt("Purple", 0);
        PlayerPrefs.SetString("Time", "00:00");
        PlayerPrefs.SetString("Level", "");
        PlayerPrefs.SetInt("EasyHighscore", 00);
        PlayerPrefs.SetString("EasyPlayername", "A Biotic");
        PlayerPrefs.SetInt("EasyRed", 00);
        PlayerPrefs.SetInt("EasyBlue", 00);
        PlayerPrefs.SetInt("EasyPurple", 00);
        PlayerPrefs.SetString("EasyTime", "00:00");
        PlayerPrefs.SetInt("MediumHighscore", 00);
        PlayerPrefs.SetString("MediumPlayername", "A Biotic");
        PlayerPrefs.SetInt("MediumRed", 00);
        PlayerPrefs.SetInt("MediumBlue", 00);
        PlayerPrefs.SetInt("MediumPurple", 0);
        PlayerPrefs.SetString("MediumTime", "00:00");
        PlayerPrefs.SetInt("HardHighscore", 00);
        PlayerPrefs.SetString("HardPlayername", "A Biotic");
        PlayerPrefs.SetInt("HardRed", 00);
        PlayerPrefs.SetInt("HardBlue", 00);
        PlayerPrefs.SetInt("HardPurple", 0);
        PlayerPrefs.SetString("HardTime", "00:00");
        UpdateHighScoreDisplay();
    }

    //Clears all best times & player names when GUI button pressed, returns times to 59:59 and names to A Biotic
    public void ClearBestTImes()
    {

        PlayerPrefs.SetFloat("Level1BestTime", 3599);
        PlayerPrefs.SetString("Level1Playername", "A Biotic");
        PlayerPrefs.SetFloat("Level2BestTime", 3599);
        PlayerPrefs.SetString("Level2Playername", "A Biotic");
        PlayerPrefs.SetFloat("Level3BestTime", 3599);
        PlayerPrefs.SetString("Level3Playername", "A Biotic");
        PlayerPrefs.SetFloat("Level4BestTime", 3599);
        PlayerPrefs.SetString("Level4Playername", "A Biotic");
        PlayerPrefs.SetFloat("Level5BestTime", 3599);
        PlayerPrefs.SetString("Level5Playername", "A Biotic");

    }

    //Method to check if pause has been activated
    public void CheckForPause() 
    {
        if (!paused) //if not paused & pause is then activated
        {
            paused = true; //sets pause bool true
            pauseScreen.SetActive(true); // sets pause screen active
            AudioListener.pause = true; //pauses audio
            Time.timeScale = 0; //sets timescale to 0
        }

        else // in other words if the game is already paused & pause is activated
        {
            paused = false; // sets pause bool false
            pauseScreen.SetActive(false); //switches off pause screen
            AudioListener.pause = false; // resumes audio
            Time.timeScale = 1; // sets timescale to 1
        }


    }
}
