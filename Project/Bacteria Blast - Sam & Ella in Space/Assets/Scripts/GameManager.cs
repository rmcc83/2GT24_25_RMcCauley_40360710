using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    public int score;
    public float fuel;
    public int lives;
    public int health;
    public int redRemaining;
    public int blueRemaining;
    public int purpleRemaining;
    public int redCollected;
    public int blueCollected;
    public int purpleCollected;
    public int virusEncountered;
    public int asteroidsBlasted;
    public int smallAsteroidHit;
    public int mediumAsteroidHit;
    public int largeAsteroidHit;
    public int smallFuelCollected;
    public int largeFuelCollected;
    public int weaponCollected;
    public int music;
    private Vector3 initialPosition;
    public Sprite[] lifeSprites;//array of sprites for each number of lives
    public Image livesImage;
    public Image livesImageEndless;
    public Sprite[] healthSprites;//array of sprites for spaceship health
    public Image healthImage;
    public Image healthImageEndless;
    public Slider fuelSlider;
    public Slider fuelSliderEndless;
    public TMP_InputField playerName;
    public GameObject winScreen;
    public GameObject nextLevelButton;
    public GameObject gameScreen;
    public GameObject gameScreenEndless;
    public GameObject highscoreCongrats;
    public GameObject bestTimeCongrats;
    public GameObject highscoreDisplay;
    public GameObject lastscoreDisplay;
    public GameObject highscoreScreen;
    public GameObject timesScreen;
    public GameObject helpScreen;
    public GameObject statsScreen;
    public GameObject characterScreen;
    public GameObject confirmNameReset;
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
    public AudioClip lowFuelSound;
    public float timeElapsed = 0;
    public TextMeshProUGUI timerText; // endless levels
    public TextMeshProUGUI timerText2; // 'normal' levels
    public float currentLevel1BestTime;
    public float currentLevel2BestTime;
    public float currentLevel3BestTime;
    public float currentLevel4BestTime;
    public float currentLevel5BestTime;
    public int playerSkinEquipped;
    public GameObject spaceship1;
    public GameObject spaceship2;
    public GameObject spaceship3;
    public GameObject spaceship4;
    public GameObject spaceship1Prefab;
    public GameObject spaceship2Prefab;
    public GameObject spaceship3Prefab;
    public GameObject spaceship4Prefab;

    public CumulativeStatsHandler cumulativeStatsHandler;

    // Start is called before the first frame update
    void Start()
    {

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameAudio = GetComponent<AudioSource>();
        initialPosition = new Vector3(-68.3f, 1.28f, -1f); // starting position of player object

    }

    public void Load()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        CheckHighScore(); // run check highscore method
        UpdateHighScoreDisplay(); // run update highscore display method
        UpdateLastScoreDisplay(); // run update last score display method
        LoadVolume(); // run load volume method
        LoadName(); // run load name method

        // if main scene, music load method is run
        if (sceneName == "Sam & Ella in Space")
        {
            LoadMusic();

        }

        LoadSkin();


    }

    // Update is called once per frame
    void Update()
    {


        // Run the timer & check for nummber of bacteria blasted when the game starts & stop when game is over
        if (gameStarted == true && !gameOver)
        {
            RunTimer();
            UpdateBacteriaBlasted();
            FuelGauge();
            CheckHealth();

            
        }

        //Check if the user has pressed the P key - only works in main scene if game has started, so won't show pause screen when names being entered
        if (Input.GetKeyDown(KeyCode.P) && gameStarted == true)
        {
            CheckForPause();
        }

        if (gameOver == true)
        {
            spawnManager.StopSpawn();

        }

    }

    public void CheckHealth() 
    {
        if (health == 0)
        {

            if (gameEndless != true)
            {
                GameLose();

            }

            if (gameEndless == true)
            {

                GameOverAsteroid();

            }
        }



    }


    public void StartGame(int level) // level number is passed in from level select button.  Starting lives, starting ship health, starting fuel,
                                     // amount of bacteria which must be collected to win are set depending on the level selected.

    {

        redRemaining = (level * 2);
        blueRemaining = (level * 2);
        purpleRemaining = (level * 2);

        switch (level)
        {
            case 1:
                currentLevel = 1;
                lives = 6;
                health = 4;
                fuel = 100;
                break;

            case 2:
                currentLevel = 2;
                lives = 6;
                health = 4;
                fuel = 100;
                break;

            case 3:
                currentLevel = 3;
                lives = 4;
                health = 3;
                fuel = 100;
                break;

            case 4:
                currentLevel = 4;
                lives = 4;
                health = 3;
                fuel = 100;
                break;

            case 5:
                currentLevel = 5;
                lives = 3;
                health = 2;
                fuel = 75;
                break;
        }


        // The below happens for all the levels which call this method


        livesImage.sprite = lifeSprites[lives]; //sets lives display to starting amount
        healthImage.sprite = healthSprites[health]; //sets health display to starting amount
        fuelSlider.value = fuel; // sets fuel bar to starting amount
        ResetGravity(); // run reset gravity method - necessary to ensure gravity does not increase each time game is played, as gravity modifier is being utilised
        gameScreen.SetActive(true); // sets gamescreen (with score, fuel etc) active
        gameScreenEndless.SetActive(false); // sets endless game screen inactive        
        redRemainText.text = "      " + redRemaining; // displays red bacteria remaining
        blueRemainText.text = "    " + blueRemaining; // displays blue bacteria remaining
        purpleRemainText.text = "      " + purpleRemaining; // displays purple bacteria remaining
        CommonGameStart(); // runs the method which contains things common to all modes levels
    }

    // Adds appropriate value to score when bacteria collected, and updates score display
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = playerName.text.ToUpper() + "'S Score : " + score;
    }


    public void StartGameEndless(int level) // level number is passed in from level select button.  Starting lives,
                                            // starting fuel, starting ship health, difficulty in words is set depending on (endless) level selected.
    {
        switch (level)
        {
            case 99:
                currentLevel = 99;
                lives = 6;
                health = 4;
                fuel = 100;
                endlessDifficultyText.text = "Difficulty: Easy";
                break;

            case 98:
                currentLevel = 98;
                lives = 4;
                health = 3;
                fuel = 80;
                endlessDifficultyText.text = "Difficulty: Medium";
                break;

            case 97:
                currentLevel = 97;
                lives = 2;
                health = 2;
                fuel = 50;
                endlessDifficultyText.text = "Difficulty: Hard";
                break;
        }

        score = 0;
        livesImageEndless.sprite = lifeSprites[lives];  //sets lives display to starting amount
        healthImageEndless.sprite = healthSprites[health]; //sets health display to starting amount
        fuelSliderEndless.value = fuel; // sets fuel bar to starting amount
        gameEndless = true; // flags endless game is selected
        redCollected = 0; //sets red collected to 0
        blueCollected = 0; //sets blue collected to 0
        purpleCollected = 0; //sets purple collected to 0
        ResetGravity(); // run reset gravity method - necessary to ensure gravity does not increase each time game is played, as gravity modifier is being utilised
        gameScreen.SetActive(false); // sets normal game screen off
        gameScreenEndless.SetActive(true); // sets endless game screen on
        scoreText.text = playerName.text.ToUpper() + "'S SCORE : " + score; //displays score along with player name
        redCollectText.text = "      " + redCollected; //displays red bacteria collected
        blueCollectText.text = "    " + blueCollected; //displays blue bacteria collected
        purpleCollectText.text = "      " + purpleCollected; //displays purple bacteria collected
        CommonGameStart();  // runs the method which contains things common to all modes levels
    }

    // These are common to all modes & levels
    public void CommonGameStart()
    {
        highscoreDisplay.SetActive(false); // sets highscore display inactive
        lastscoreDisplay.SetActive(false); // sets last score display inactive
        gameStarted = true; // flags that game has started
        gameOver = false; // flags that game is not over
        gameWin = false; //sets game win flag flase
        gameLose = false; //sets game lose flag false
        spawnManager.StartSpawn(); // runs start spawn method from spawnmanager
        SaveName(); // runs savename method

    }


    public void IncreaseFuel(int value)
    {

        fuel += value; // Increases fuel by appropriate amount when powerup is collected.

        if (fuel > 100) //  Fuel cannot go above 100%.
        {
            fuel = 100;

        }

        FuelGauge();
    }

    public void FuelGauge()
    {
        if (fuel < 30)  // colours fuel bar red when fuel below 30%
        {
            fuelSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0.8f, 0.2f, 0.1f);
            fuelSliderEndless.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0.8f, 0.2f, 0.1f);

        }


        if (fuel >= 30 && fuel <= 60)  // colours fuel bar orange when fuel between 30 & 60 %
        {
            fuelSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(1f, 0.6f, 0f);
            fuelSliderEndless.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(1f, 0.6f, 0f);


        }

        if (fuel == 25) // plays low fuel alarm sound when fuel is 25%
        {

            gameAudio.PlayOneShot(lowFuelSound, 1.0f);

        }

        if (fuel > 60) // ensures bar is green when fuel is more than 60%
        {
            fuelSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.3f);
            fuelSliderEndless.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.3f);

        }


        fuelSlider.value = fuel;        //Sets fuel indicator bar according to amount of fuel available (timed mode).
        fuelSliderEndless.value = fuel; // Sets fuel bar in endless mode

    }


    // Adjusts lives & displays current amount
    public void AddLives(int value)
    {
        lives += value;
        livesImage.sprite = lifeSprites[lives];
        livesImageEndless.sprite = lifeSprites[lives];

        // When lives are 0, game is over, you lose.  Method called will depend on game mode currently being played
        if (lives <= 0)
        {

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
    }



    // Adjusts damage from asteroids & displays current amount
    public void DoDamage(int value)
    {
        health -= value;
        health = Mathf.Clamp(health, 0, 4);
        healthImage.sprite = healthSprites[health];
        healthImageEndless.sprite = healthSprites[health];

        // When ship health is 0, game is over, you lose.  Method called will depend on game mode currently being played
        

    }

    // updates bacteria numbers display
    public void UpdateBacteriaBlasted()
    {

        if (gameEndless != true)  //if endless game is not being played
        {
            redRemainText.text = "      " + redRemaining; // display remaining red
            blueRemainText.text = "    " + blueRemaining; //display remaining blue
            purpleRemainText.text = "      " + purpleRemaining; //display remaining purple

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
                gameWin = true;
                GameWin();
            }


        }


        if (gameEndless == true) // if endless game is being played
        {
            redCollectText.text = "      " + redCollected; // displays number of red bacteria collected
            blueCollectText.text = "    " + blueCollected; // displays number of blue bacteria collected
            purpleCollectText.text = "      " + purpleCollected; // displays number of purple bacteria collected

        }

    }

    public void GameWin() // at gamewin, music stops, win screen is displayed, stats are updated
                          // & a personalised message is displayed
    {
        StopMusic();
        gameOver = true;
        gameWin = true;
        winScreen.gameObject.SetActive(true);
        winText.SetText("CONGRATULATIONS, " + playerName.text.ToUpper() + " - YOU HAVE COLLECTED ALL THE REQUIRED BACTERIAL SAMPLES!!!"); // player name is included in message, & forced to upper case
        CheckBestTime(); // check if time is a new best for that level
        pauseButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        UpdateTimedGamesPlayed();
        UpdateTimedGamesWon();
        UpdateCumulativeStats();

        if (currentLevel == 5)          // If level is 5, next level button is deactivated as there are no more levels
        {
            nextLevelButton.SetActive(false);
        }
    }

    public void GameLose() // at game lose, music stops, game is over, game is lost, lose screen is displayed, personalised message is displayed, stats updated
    {
        StopMusic();
        gameOver = true;
        gameLose = true;
        loseScreen.gameObject.SetActive(true);
        loseText.SetText("SORRY," + playerName.text.ToUpper() + " - THIS TIME YOU DIDN'T COLLECT ENOUGH BACTERIAL SAMPLES."); // player name is included in message, & forced to upper case
        pauseButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        UpdateTimedGamesPlayed();
        UpdateTimedGamesLost();
        UpdateCumulativeStats();
    }

    public void GameOverCrash() // method used in endless game when player crashes into the ground.  Music stops, gameover screen is displayed, personalised message is displayed,
                                // score is checked against saved highscore, score is saved as last score, highscore & last score displays are updated, stats are updated
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
        UpdateEndlessGamesPlayed();
        UpdateEndlessGamesCrash();
        UpdateCumulativeStats();
    }

    public void GameOverAsteroid() // method used in endless game when player wrecks spaceship on asteroids.  Music stops, gameover screen is displayed, personalised message is displayed,
                                // score is checked against saved highscore, score is saved as last score, highscore & last score displays are updated, stats are updated
    {
        StopMusic();
        gameOver = true;
        pauseButtonEndless.gameObject.SetActive(false);
        quitButtonEndless.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.SetText("SORRY, " + playerName.text.ToUpper() + " - YOU WRECKED YOUR SHIP!  DON'T WORRY, RESCUE IS ON THE WAY!"); // player name is included in message, & forced to upper case
        CheckHighScore();
        SaveLastScore();
        UpdateHighScoreDisplay();
        UpdateLastScoreDisplay();
        UpdateEndlessGamesPlayed();
        UpdateEndlessGamesAsteroid();
        UpdateCumulativeStats();
    }

    public void GameOverLives() // method used in endless game when player runs out of lives.  Music stops, gameover screen is displayed, personalised message is displayed,
                                // player object motion is fully constrained so it freezes in place, score is checked against saved highscore, score is saved as last score,
                                // highscore & last score displays are updated, stats are updated
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
        UpdateEndlessGamesPlayed();
        UpdateEndlessGamesLives();
        UpdateCumulativeStats();
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

        switch (music)
        {
            case 0:
                track1.Play();
                track2.Stop();
                track3.Stop();
                track4.Stop();
                screen1.gameObject.SetActive(true);
                screen2.gameObject.SetActive(false);
                screen3.gameObject.SetActive(false);
                screen4.gameObject.SetActive(false);
                break;

            case 1:
                track1.Play();
                track2.Stop();
                track3.Stop();
                track4.Stop();
                screen1.gameObject.SetActive(true);
                screen2.gameObject.SetActive(false);
                screen3.gameObject.SetActive(false);
                screen4.gameObject.SetActive(false);
                break;

            case 2:
                track1.Stop();
                track2.Play();
                track3.Stop();
                track4.Stop();
                screen1.gameObject.SetActive(false);
                screen2.gameObject.SetActive(true);
                screen3.gameObject.SetActive(false);
                screen4.gameObject.SetActive(false);
                break;

            case 3:
                track1.Stop();
                track2.Stop();
                track3.Play();
                track4.Stop();
                screen1.gameObject.SetActive(false);
                screen2.gameObject.SetActive(false);
                screen3.gameObject.SetActive(true);
                screen4.gameObject.SetActive(false);
                break;

            case 4:
                track1.Stop();
                track2.Stop();
                track3.Stop();
                track4.Play();
                screen1.gameObject.SetActive(false);
                screen2.gameObject.SetActive(false);
                screen3.gameObject.SetActive(false);
                screen4.gameObject.SetActive(true);
                break;

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

        switch (currentLevel)
        {
            case 99:
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
                break;

            case 98:
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
                break;

            case 97:
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
                break;

        }

    }

    public void CheckBestTime() //handles checking for best time & saving best time.  Checks/saves best time in playerprefs for each level,
                                //if no previous time saved, will check against a default of 3599 i.e. 59 mins 59 seconds
    {

        switch (currentLevel)
        {
            case 1:
                currentLevel1BestTime = (PlayerPrefs.GetFloat("Level1BestTime", 3599));

                if (timeElapsed < currentLevel1BestTime)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level1Playername", playerName.text.ToUpper()); ;
                    PlayerPrefs.SetFloat("Level1BestTime", timeElapsed);
                }
                break;

            case 2:
                currentLevel2BestTime = (PlayerPrefs.GetFloat("Level2BestTime", 3599));

                if (timeElapsed < currentLevel2BestTime)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level2Playername", playerName.text.ToUpper()); ;
                    PlayerPrefs.SetFloat("Level2BestTime", timeElapsed);
                }
                break;

            case 3:
                currentLevel3BestTime = (PlayerPrefs.GetFloat("Level3BestTime", 3599));

                if (timeElapsed < currentLevel3BestTime)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level3Playername", playerName.text.ToUpper()); ;
                    PlayerPrefs.SetFloat("Level3BestTime", timeElapsed);
                }
                break;

            case 4:
                currentLevel4BestTime = (PlayerPrefs.GetFloat("Level4BestTime", 3599));

                if (timeElapsed < currentLevel4BestTime)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level4Playername", playerName.text.ToUpper()); ;
                    PlayerPrefs.SetFloat("Level4BestTime", timeElapsed);
                }
                break;

            case 5:
                currentLevel5BestTime = (PlayerPrefs.GetFloat("Level5BestTime", 3599));

                if (timeElapsed < currentLevel5BestTime)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level5Playername", playerName.text.ToUpper()); ;
                    PlayerPrefs.SetFloat("Level5BestTime", timeElapsed);
                }
                break;
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

    public void StatsOn() //displays stats screen & ensures overall highscore & last game score are hidden
    {
        statsScreen.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(false);
        lastscoreText.gameObject.SetActive(false);
    }

    public void StatsOff() //hides stats screen & ensures overall highscore & last game score are visible again
    {
        statsScreen.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(true);
        lastscoreText.gameObject.SetActive(true);
    }



    // To play button click sounds
    public void ButtonSound()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
    }

    void RunTimer() //runs timer & formats time display
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

    public void SetPlayerSkinEquipped(int value)
    {
        playerSkinEquipped = value;

    }

    public void SaveSkin() // saves selected spaceship skin to player prefs
    {
        if (player1 == true)
        {
            PlayerPrefs.SetInt("SkinEquipped1", playerSkinEquipped);
            PlayerPrefs.Save();
        }

        if (player2 == true)
        {
            PlayerPrefs.SetInt("SkinEquipped2", playerSkinEquipped);
            PlayerPrefs.Save();
        }

        if (player3 == true)
        {
            PlayerPrefs.SetInt("SkinEquipped3", playerSkinEquipped);
            PlayerPrefs.Save();
        }

    }

    public void LoadSkin() //loads saved spaceship skin for that player profile from playerprefs
    {

        if (player1 == true)
        {
            playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped1");

        }

        if (player2 == true)
        {
            playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped2");

        }

        if (player3 == true)
        {
            playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped3");

        }


        switch (playerSkinEquipped)
        {
            case 0:

                spaceship1.SetActive(true);
                spaceship2.SetActive(false);
                spaceship3.SetActive(false);
                spaceship4.SetActive(false);
                break;

            case 1:
                spaceship1.SetActive(true);
                spaceship2.SetActive(false);
                spaceship3.SetActive(false);
                spaceship4.SetActive(false);
                break;

            case 2:
                spaceship1.SetActive(false);
                spaceship2.SetActive(true);
                spaceship3.SetActive(false);
                spaceship4.SetActive(false);
                break;

            case 3:
                spaceship1.SetActive(false);
                spaceship2.SetActive(false);
                spaceship3.SetActive(true);
                spaceship4.SetActive(false);
                break;

            case 4:
                spaceship1.SetActive(false);
                spaceship2.SetActive(false);
                spaceship3.SetActive(false);
                spaceship4.SetActive(true);
                break;
        }


    }

    public void UpdateTimedGamesPlayed() // updates games played stat
    {
        switch (currentLevel)
        {
            case 1:
                cumulativeStatsHandler.Level1Played();
                break;
            case 2:
                cumulativeStatsHandler.Level2Played();
                break;
            case 3:
                cumulativeStatsHandler.Level3Played();
                break;
            case 4:
                cumulativeStatsHandler.Level4Played();
                break;
            case 5:
                cumulativeStatsHandler.Level5Played();
                break;
        }

        cumulativeStatsHandler.TotalTimedPlayed();

    }

    public void UpdateEndlessGamesPlayed() // updates games played stat
    {

        switch (currentLevel)
        {
            case 99:
                cumulativeStatsHandler.EasyEndlessPlayed();
                break;
            case 98:
                cumulativeStatsHandler.MediumEndlessPlayed();
                break;
            case 97:
                cumulativeStatsHandler.HardEndlessPlayed();
                break;
        }

        cumulativeStatsHandler.TotalEndlessPlayed();
    }


    public void UpdateTimedGamesWon() //updates timed games won stat
    {

        switch (currentLevel)
        {
            case 1:
                cumulativeStatsHandler.Level1Won();
                break;
            case 2:
                cumulativeStatsHandler.Level2Won();
                break;
            case 3:
                cumulativeStatsHandler.Level3Won();
                break;
            case 4:
                cumulativeStatsHandler.Level4Won();
                break;
            case 5:
                cumulativeStatsHandler.Level5Won();
                break;
        }

        cumulativeStatsHandler.TotalTimedWon();
    }

    public void UpdateEndlessGamesLives() //updates end method for endless game mode stat
    {
        switch (currentLevel)
        {
            case 99:
                cumulativeStatsHandler.EasyEndlessLives();
                break;
            case 98:
                cumulativeStatsHandler.MediumEndlessLives();
                break;
            case 97:
                cumulativeStatsHandler.HardEndlessLives();
                break;
        }

        cumulativeStatsHandler.TotalEndlessLives();

    }

    public void UpdateEndlessGamesAsteroid() //updates end method for endless game mode stat
    {
        switch (currentLevel)
        {
            case 99:
                cumulativeStatsHandler.EasyEndlessAsteroid();
                break;
            case 98:
                cumulativeStatsHandler.MediumEndlessAsteroid();
                break;
            case 97:
                cumulativeStatsHandler.HardEndlessAsteroid();
                break;
        }

        cumulativeStatsHandler.TotalEndlessAsteroid();

    }

    public void UpdateTimedGamesLost() //updates timed games lost stat
    {
        switch (currentLevel)
        {
            case 1:
                cumulativeStatsHandler.Level1Lost();
                break;
            case 2:
                cumulativeStatsHandler.Level2Lost();
                break;
            case 3:
                cumulativeStatsHandler.Level3Lost();
                break;
            case 4:
                cumulativeStatsHandler.Level4Lost();
                break;
            case 5:
                cumulativeStatsHandler.Level5Lost();
                break;

        }
        cumulativeStatsHandler.TotalTimedLost();
    }

    public void UpdateEndlessGamesCrash() //updates number of endless games which finished with a crash
    {
        switch (currentLevel)
        {
            case 99:
                cumulativeStatsHandler.EasyEndlessCrash();
                break;
            case 98:
                cumulativeStatsHandler.MediumEndlessCrash();
                break;
            case 97:
                cumulativeStatsHandler.HardEndlessCrash();
                break;
        }

        cumulativeStatsHandler.TotalEndlessCrash();

    }


    public void UpdateCumulativeStats() //updates cumulative stats
    {

        cumulativeStatsHandler.RunAll();
    }

    public void CheckNameChange() // if name being saved does not equal that saved in player prefs, confirm name reset screen is displayed
                                  // If player proceeds, player stats will be reset
    {
        if (player1 == true)
        {
            if (playerName.text != PlayerPrefs.GetString("Player1Name"))
            {

                confirmNameReset.SetActive(true);

            }

        }

        if (player2 == true)
        {
            if (playerName.text != PlayerPrefs.GetString("Player2Name"))
            {

                confirmNameReset.SetActive(true);

            }

        }

        if (player3 == true)
        {
            if (playerName.text != PlayerPrefs.GetString("Player3Name"))
            {
                confirmNameReset.SetActive(true);

            }
        }
    }

    // For showing character screen
    public void CharacterOn()
    {
        characterScreen.gameObject.SetActive(true);
        highscoreDisplay.gameObject.SetActive(false);
        lastscoreDisplay.gameObject.SetActive(false);
    }

    //For hiding character screen
    public void CharacterOff()
    {
        characterScreen.gameObject.SetActive(false);
        highscoreDisplay.gameObject.SetActive(true);
        lastscoreDisplay.gameObject.SetActive(true);



    }

    // To play epilogue scene

    public void Epilogue()
    {
        SceneManager.LoadScene("Epilogue");

    }

    // To play intro scene
    public void Intro()
    {
        SceneManager.LoadScene("Intro");

    }

    public void RestartLevel() // When you fail a level & press the restart button, this function is called.  Spawning stops, a new player object is instantiated
                               // The game over or lose screen is switched off, elapsed time is set to 0, and the current level number is fed into the appropriate
                               // start game function so the same level will restart
    {
        spawnManager.StopSpawn();
        CommonToResetAndNext();
        InstantiateNewPlayerObject();
        gameOverScreen.SetActive(false);
        loseScreen.SetActive(false);


        if (gameEndless == true)
        {
            timeElapsed = 0;
            StartGameEndless(currentLevel);

        }

        if (gameEndless == false)
        {
            timeElapsed = 0;
            score = 0;
            StartGame(currentLevel);

        }

    }

    public void NextLevel() // When you win a level in timed mode and press the next level button, this function runs.  Spawning stops, the win screen is switched off,
                            // elapsed time is set to 0, and the current level number plus 1 is fed into the appropriate start game function so the next level will start
    {
        spawnManager.StopSpawn();
        CommonToResetAndNext();
        winScreen.SetActive(false);
        timeElapsed = 0;
        StartGame(currentLevel + 1);

    }

    public void CommonToResetAndNext() // This is used when level restart or next level button is pressed.  Remaining items on the screen are removed, pause & quit buttons are
                                        // reactivated, weapon arm indicators are reset
    {
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Blue Bacterium"))
        {
            Destroy(gameObj);
        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Red Bacterium"))
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
        pauseButton.SetActive(true);
        pauseButtonEndless.SetActive(true);
        quitButtonEndless.SetActive(true);
        quitButton.SetActive(true);
        playerController.armedText.gameObject.SetActive(false);
        playerController.unarmedText.gameObject.SetActive(true);
        playerController.armedTextEndless.gameObject.SetActive(false);
        playerController.unarmedTextEndless.gameObject.SetActive(true);

    }

    void InstantiateNewPlayerObject() // Used to instantaite a new player object when level is restarted after failure.  First the selected type is read from player
                                      // prefs, then the correct prefab is instantiated in the start position
    {
        if (player1 == true)
        {
            playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped1");

        }

        if (player2 == true)
        {
            playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped2");

        }

        if (player3 == true)
        {
            playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped3");

        }


        switch (playerSkinEquipped)
        {
            
            case 1:
                Instantiate(spaceship1Prefab, initialPosition, spaceship1.transform.rotation);
                break;

            case 2:
                Instantiate(spaceship2Prefab, initialPosition, spaceship1.transform.rotation);
                break;

            case 3:
                Instantiate(spaceship3Prefab, initialPosition, spaceship1.transform.rotation);
                break;

            case 4:
                Instantiate(spaceship4Prefab, initialPosition, spaceship1.transform.rotation);
                break;
        }


    }

}
