using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;
using ControlFreak2;

public class GameManager : MonoBehaviour
{
    // Counting numbers of collectables, items hit etc for use in cumulative stats screen  
    public int virusEncountered; // amount of viruses collected 
    public int asteroidsBlasted; // amount of asteroids destroyed with projectiles 
    public int smallAsteroidHit; //amount of small asteroids hit
    public int mediumAsteroidHit; //amount of medium asteroids hit
    public int largeAsteroidHit; //amount of large asteroids hit
    public int smallFuelCollected; //amount of small fuel powerups collected
    public int largeFuelCollected; //amount of large fuel powerups collected
    public int weaponCollected; //amount of weapon powerups collected
    public int repairCollected; //amount of repair powerups collected

    // Count & display bacteria remaining to collect in timed levels
    public int redRemaining; // count amount of red bacteria 
    public int blueRemaining;  // count amount of blue bacteria 
    public int purpleRemaining; // count amount of purple bacteria 
    public TextMeshProUGUI redRemainText; // display red remaining
    public TextMeshProUGUI blueRemainText; // display blue remaining
    public TextMeshProUGUI purpleRemainText; // display purple remaining

    // Count & display bacteria collected in endless levels
    public int redCollected;  // count amount of red bacteria 
    public int blueCollected; // count amount of blue bacteria 
    public int purpleCollected; // count amount of purple bacteria
    public TextMeshProUGUI redCollectText; // display red
    public TextMeshProUGUI blueCollectText; // display blue
    public TextMeshProUGUI purpleCollectText; // display purple

    // Sound effects
    private AudioSource gameAudio;
    public AudioClip buttonSound;

    // Radio station items on options screen
    public GameObject screen1; // station 1 name display
    public GameObject screen2; // station 2 name display
    public GameObject screen3; // station 3 name display
    public GameObject screen4; // station 4 name display
    public int music; 
    public Slider musicSlider; // music volume setting
    public AudioSource track1; // station 1 audio
    public AudioSource track2; // station 2 audio
    public AudioSource track3; // station 3 audio
    public AudioSource track4; // station 4 audio

    //Fuel system
    public TextMeshProUGUI fuelText; // Fuel bar text label in timed levels
    public TextMeshProUGUI fuelEndlessText; // Fuel bar text label in endless levels
    public float fuel; // amount of fuel remaining
    public Slider fuelSlider; // fuel bar display - timed levels
    public Slider fuelSliderEndless; // fuel bar display - endless levels

    // Weapon System text indicators
    public TextMeshProUGUI armedText;
    public TextMeshProUGUI unArmedText;
    public TextMeshProUGUI armedTextEndless;
    public TextMeshProUGUI unArmedTextEndless;


    // Lives/Virus pods system
    public int lives; // shown by virus sprites - this reduces when player hits viruses
    public Sprite[] lifeSprites;//array of sprites for each number of lives/virus pods
    public Image livesImage; // where the lives/virus pods display in a timed level
    public Image livesImageEndless; //where the lives/virus pods display in an endless level

    //Spaceship health system
    public int health; // shown by spaceship sprites - this reduces when player hits asteroids & increases when repair is collected
    public Sprite[] healthSprites;//array of sprites for spaceship health
    public Image healthImage; // where spaeship health displays in timed level
    public Image healthImageEndless; // where spaeship health displays in endless level

    // Score system
    public int score; // keeps score
    public TextMeshProUGUI scoreText; // Displays score on screen

    // Timing system
    public float timeElapsed = 0;
    public TextMeshProUGUI timerText; // timer display - endless levels
    public TextMeshProUGUI timerText2; // timer display - 'timed' levels

    // Win System
    public bool gameWin; // true when player succeeds in timed level 
    public GameObject winScreen; // displays when player collects all required bacteria on timed level
    public TextMeshProUGUI winText; // player name is inserted into this on game win
    public Button nextLevelButton; // displayed on win screen but not level 5 win

    // Lose system
    public bool gameLose; // true when player fails timed level 
    public GameObject loseScreen; // displays when player fails to collect all required bacteria on timed level
    public TextMeshProUGUI loseText; // player name is inserted into this on game lose

    // Game over system
    public bool gameOver; // true when game over condition occurs
    public GameObject gameOverScreen; // displays when endless level is terminated by any death (asteroid, ground, virus etc)
    public TextMeshProUGUI gameOverText; // player name is inserted into game over message

    // Various different screens in game
    public GameObject gameScreen; // Contains all UI elements for timed level
    public GameObject gameScreenEndless; // Contains all UI elements for endless level
    public GameObject timesScreen; // best times screen
    public GameObject highscoreScreen; // highscores screen
    public GameObject helpScreen; // info & control screen
    public GameObject helpScreen2; // gamescreen guide screen
    public GameObject statsScreen; // cumulative stats screen
    public GameObject characterScreen; // character info screen (Sam, Ella, bacteria, etc)
    public GameObject titleScreen; // Main menu screen
    public GameObject pauseScreen; // pause screen
    public GameObject confirmQuit; // confirm quit dialog
    public GameObject confirmQuitEndless; // confirm quit dialog in endless mode

    // Highscore system
    public bool newHighscore; // true when new highscore achieved for current level
    public GameObject highscoreCongrats; // displays at end of endless level when new high score is achieved
    public TextMeshProUGUI highscoreCongratsText; // customised highscore congrats message inc player name
    public GameObject highscoreDisplay; // Displays overall best score in endless level at top of main menu/title screen
    public TextMeshProUGUI highscoreText; // Contains text of overall best score for display

    // Last score system
    public GameObject lastscoreDisplay; // Displays deails of last endless game at top of main menu/title screen
    public TextMeshProUGUI lastscoreText; // contanis text of last game details

    // Best time system
    public bool newBestTime; // true when new best time achieved for current level
    public GameObject bestTimeCongrats; // displays at end of timed level when new best time achieved
    public TextMeshProUGUI bestTimeCongratsText; // best time congrats message inc player name
    public float currentLevel1BestTime; // loads in saved best time for level 1 for current player from player prefs for comparison with latest time
    public float currentLevel2BestTime; // loads in saved best time for level 2 for current player from player prefs for comparison with latest time
    public float currentLevel3BestTime; // loads in saved best time for level 3 for current player from player prefs for comparison with latest time
    public float currentLevel4BestTime; // loads in saved best time for level 4 for current player from player prefs for comparison with latest time
    public float currentLevel5BestTime; // loads in saved best time for level 5 for current player from player prefs for comparison with latest time


    // Player name
    public TMP_InputField playerName; // Player name input field on options screen
    public GameObject confirmNameReset; // Confirmation screen for player name change

    // Spaceship selection
    public int playerSkinEquipped; // loadssaved spaceship selection from player prefs
    public GameObject spaceship1; 
    public GameObject spaceship2;
    public GameObject spaceship3;
    public GameObject spaceship4;
    public GameObject spaceship1Prefab; //for instantiating new spaceship 1
    public GameObject spaceship2Prefab; //for instantiating new spaceship 2
    public GameObject spaceship3Prefab; //for instantiating new spaceship 3
    public GameObject spaceship4Prefab; //for instantiating new spaceship 4

    // Player object
    private Vector3 initialPosition; // starting position of spaceship
    public GameObject player;
    private Rigidbody playerRb;

    // Pause & Quit buttons on game screens
    public GameObject pauseButtonEndless;
    public GameObject pauseButton;
    public GameObject quitButtonEndless;
    public GameObject quitButton;

    // Game state flags

    public bool gameStarted; // true when game has started
    public bool gameEndless; // true when endless game is being played
    public bool paused; // true when game is paused
    public int cheatActive; // number of cheat code entered

    // Alternate Controls
    public int controlType; // loads control scheme type from playerprefs
    public Slider altControlSlider; // Control selection slider
    public TextMeshProUGUI controlEndlessText; // Control type in words on endless level - not displayed but used in score displays etc
    public TextMeshProUGUI controlTimedText; // Control type in words on timed level - not displayed but used in score displays etc

    // Touch Controls
    public GameObject touchControls;
    public GameObject joystick;
    public GameObject boostButton;


    // Misc

    public float repairDropChancePercentage; // % chance of a repair kit appearing when asteroid is blasted
    public int currentLevel; // holds current level number
    public int profileNumber; // current player profile number
    public float gravityModifier;
    public TextMeshProUGUI endlessDifficultyText; // Difficulty text in words for endless level - not displayed but used in score displays etc
    

    private SpawnManager spawnManager;
    public PlayerController playerController;
    public CumulativeStatsHandler cumulativeStatsHandler;
    private CheatCodeManager cheatCodeManager;
    public LevelUnlock levelUnlock;
    public InGameOptions inGameOptions;
 

    // Start is called before the first frame update
    void Start()
    {

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameAudio = GetComponent<AudioSource>();
        initialPosition = new Vector3(-68.3f, 1.28f, -1f); // starting position of player object
        cheatCodeManager = GetComponent<CheatCodeManager>();
        
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
        LoadControls();

    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
       // player = GameObject.FindGameObjectWithTag("Player");

        //Return to Title screen if user presses escape key or PS4 share

        if (CF2Input.GetKeyDown(KeyCode.Escape))
        {

            if (gameStarted == true && !gameOver)
            {
                confirmQuit.SetActive(true);
                confirmQuitEndless.SetActive(true);

            }


        }

        // Run the timer & check for nummber of bacteria blasted when the game starts & stop when game is over
        if (gameStarted == true && !gameOver)
        {
            RunTimer();
            UpdateBacteriaBlasted();
            FuelGauge();
            CheckHealth();
            TouchControls();

        }

        //Check if the user has pressed the P key - only works in main scene if game has started, so won't show pause screen when names being entered
        if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.P) && gameStarted == true)
        {
            CheckForPause();
        }

        if (gameOver == true)
        {
            spawnManager.StopSpawn();

        }


    }

    public void CheckHealth()         // When ship health is 0, game is over, you lose.  Method called will depend on game mode currently being played
    {
        if (gameStarted == true && health == 0)
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
                repairDropChancePercentage = 80;
                break;

            case 2:
                currentLevel = 2;
                lives = 6;
                health = 4;
                fuel = 100;
                repairDropChancePercentage = 70;
                break;

            case 3:
                currentLevel = 3;
                lives = 4;
                health = 3;
                fuel = 100;
                repairDropChancePercentage = 50;
                break;

            case 4:
                currentLevel = 4;
                lives = 4;
                health = 3;
                fuel = 100;
                repairDropChancePercentage = 40;
                break;

            case 5:
                currentLevel = 5;
                lives = 3;
                health = 2;
                fuel = 75;
                repairDropChancePercentage = 30;
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
                repairDropChancePercentage = 80;
                endlessDifficultyText.text = "Difficulty: Easy";
                break;

            case 98:
                currentLevel = 98;
                lives = 4;
                health = 3;
                fuel = 80;
                repairDropChancePercentage = 50;
                endlessDifficultyText.text = "Difficulty: Medium";
                break;

            case 97:
                currentLevel = 97;
                lives = 2;
                health = 2;
                fuel = 50;
                repairDropChancePercentage = 30;
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
        cheatCodeManager.CheatCancel();
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



    // Adjusts damage from asteroids & displays current amount of health remaining via sprites
    public void DoDamage(int value)
    {
        if (cheatActive != 2)
        {
            health -= value;
        }
        health = Mathf.Clamp(health, 0, 4); // ensures health will not go negative
        healthImage.sprite = healthSprites[health];
        healthImageEndless.sprite = healthSprites[health];
        

    }

    // Adds health from repair kits & displays current amount of health remaining via sprites
    public void Repair(int value) 
    {
        health += value;
        health = Mathf.Clamp(health, 0, 4); // ensures health will not go above 4
        healthImage.sprite = healthSprites[health];
        healthImageEndless.sprite = healthSprites[health];

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

        if (cheatActive == 0) // if cheat mode is not active, next level is unlocked
        { 
           levelUnlock.UnLockLevel();
          
        }


        if (currentLevel == 5 || cheatActive != 0)        // If level is 5, or cheat is active, next level button is deactivated
        {
            nextLevelButton.interactable = false;
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
        switch (profileNumber)
        {
            case 1:
                PlayerPrefs.SetString("Player1Name", playerName.text);
                break;
            case 2:
                PlayerPrefs.SetString("Player2Name", playerName.text);
                break;
            case 3:
                PlayerPrefs.SetString("Player3Name", playerName.text);
                break;
        }
    }

    public void LoadName() // allows previously saved player name in particular slot to be loaded from playerprefs
    {

        switch (profileNumber)
        {
            case 1:
                playerName.text = PlayerPrefs.GetString("Player1Name", "A Biotic");
                break;
            case 2:
                playerName.text = PlayerPrefs.GetString("Player2Name", "A Biotic");
                break;
            case 3:
                playerName.text = PlayerPrefs.GetString("Player3Name", "A Biotic");
                break;
        }

    }

    public void SaveVolume() // saves current volume setting in player prefs for particular player profile
    {
        switch (profileNumber)
        {
            case 1:
                PlayerPrefs.SetFloat("MusicVolume1", musicSlider.value);
                break;
            case 2:
                PlayerPrefs.SetFloat("MusicVolume2", musicSlider.value);
                break;
            case 3:
                PlayerPrefs.SetFloat("MusicVolume3", musicSlider.value);
                break;
        }
        PlayerPrefs.Save();
    }

    public void LoadVolume() //loads previously saved volume setting for that player profile from playerprefs.  If no saved value, defaults to 50%
    {
        switch (profileNumber)
        {
            case 1:
                if (PlayerPrefs.HasKey("MusicVolume1"))
                {
                    musicSlider.value = PlayerPrefs.GetFloat("MusicVolume1");
                }

                else musicSlider.value = 0.5f;
                break;
            case 2:
                if (PlayerPrefs.HasKey("MusicVolume2"))
                {
                    musicSlider.value = PlayerPrefs.GetFloat("MusicVolume2");
                }

                else musicSlider.value = 0.5f;
                break;
            case 3:
                if (PlayerPrefs.HasKey("MusicVolume3"))
                {
                    musicSlider.value = PlayerPrefs.GetFloat("MusicVolume3");
                }

                else musicSlider.value = 0.5f;
                break;
        }

    }

    public void SetMusic(int value) // sets music to particular track
    {
        music = value;

    }

    public void SaveMusic() //saves set music track against current player profile in playerprefs
    {
        switch (profileNumber)
        {
            case 1:
                PlayerPrefs.SetInt("Music1", music);
                break;
            case 2:
                PlayerPrefs.SetInt("Music2", music);
                break;
            case 3:
                PlayerPrefs.SetInt("Music3", music);
                break;
        }
        PlayerPrefs.Save();

    }

    public void LoadMusic() //loads music setting for current player from playerprefs, and then plays appropriate tune & sets appropriate 'radio' screen to match
    {
        switch (profileNumber)
        {
            case 1:
                music = PlayerPrefs.GetInt("Music1");
                break;
            case 2:
                music = PlayerPrefs.GetInt("Music2");
                break;
            case 3:
                music = PlayerPrefs.GetInt("Music3");
                break;
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

        if (score > PlayerPrefs.GetInt("Highscore") && cheatActive == 0) //if current score is higher than saved highscore, and cheat is not active, new highscore flag is true, new high score notification is displayed,
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
                if (score > PlayerPrefs.GetInt("EasyHighscore") && cheatActive == 0)
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
                    PlayerPrefs.SetString("EasyControl", controlEndlessText.text);
                }
                break;

            case 98:
                if (score > PlayerPrefs.GetInt("MediumHighscore") && cheatActive == 0)
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
                    PlayerPrefs.SetString("MediumControl", controlEndlessText.text);

                }
                break;

            case 97:
                if (score > PlayerPrefs.GetInt("HardHighscore") && cheatActive == 0)
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
                    PlayerPrefs.SetString("HardControl", controlEndlessText.text);
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

                if (timeElapsed < currentLevel1BestTime && cheatActive == 0)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level1Playername", playerName.text.ToUpper()); 
                    PlayerPrefs.SetFloat("Level1BestTime", timeElapsed);
                    PlayerPrefs.SetString("Level1Control", controlTimedText.text);

                }
                break;

            case 2:
                currentLevel2BestTime = (PlayerPrefs.GetFloat("Level2BestTime", 3599));

                if (timeElapsed < currentLevel2BestTime && cheatActive == 0)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level2Playername", playerName.text.ToUpper()); 
                    PlayerPrefs.SetFloat("Level2BestTime", timeElapsed);
                    PlayerPrefs.SetString("Level2Control", controlTimedText.text);
                }
                break;

            case 3:
                currentLevel3BestTime = (PlayerPrefs.GetFloat("Level3BestTime", 3599));

                if (timeElapsed < currentLevel3BestTime && cheatActive == 0)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level3Playername", playerName.text.ToUpper()); 
                    PlayerPrefs.SetFloat("Level3BestTime", timeElapsed);
                    PlayerPrefs.SetString("Level3Control", controlTimedText.text);
                }
                break;

            case 4:
                currentLevel4BestTime = (PlayerPrefs.GetFloat("Level4BestTime", 3599));

                if (timeElapsed < currentLevel4BestTime && cheatActive == 0)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level4Playername", playerName.text.ToUpper());
                    PlayerPrefs.SetFloat("Level4BestTime", timeElapsed);
                    PlayerPrefs.SetString("Level4Control", controlTimedText.text);
                }
                break;

            case 5:
                currentLevel5BestTime = (PlayerPrefs.GetFloat("Level5BestTime", 3599));

                if (timeElapsed < currentLevel5BestTime && cheatActive == 0)
                {
                    newBestTime = true;
                    DisplayBestTimeNotification();
                    PlayerPrefs.SetString("Level5Playername", playerName.text.ToUpper());
                    PlayerPrefs.SetFloat("Level5BestTime", timeElapsed);
                    PlayerPrefs.SetString("Level5Control", controlTimedText.text);
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

    public void DisplayHighScoreNotification() // if gameover is true and new highscore is true & cheat is not active, personalised notification is displayed 
    {
        if (gameOver == true && newHighscore == true && cheatActive == 0)
        {

            highscoreCongrats.gameObject.SetActive(true);
            highscoreCongratsText.SetText("YOU GOT A NEW HIGH SCORE, " + playerName.text.ToUpper() + "!"); //ensures player name is displayed in upper case
        }

    }

    public void DisplayBestTimeNotification() // if gameover is true and new best time is true and cheat is not active, personalised notification is displayed 
    {
        if (gameOver == true && newBestTime == true && cheatActive == 0)
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

   
    public void HelpOff() //hides controls screen & ensures overall highscore & last game score are visible again
    {
        helpScreen.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(true);
        lastscoreText.gameObject.SetActive(true);
    }

    public void Help2Off() //hides help 2 screen & ensures overall highscore & last game score are visible again
    {
        helpScreen2.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(true);
        lastscoreText.gameObject.SetActive(true);
    }
    public void Help2Back() //hides help 2 screen but does not make last game score visible (used for going back to controls help screen)
    {
        helpScreen2.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(false);
        lastscoreText.gameObject.SetActive(false);
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
        PlayerPrefs.SetString("EasyControl", "CLASSIC");
        PlayerPrefs.SetString("EasyTime", "00:00");
        PlayerPrefs.SetInt("MediumHighscore", 00);
        PlayerPrefs.SetString("MediumPlayername", "A Biotic");
        PlayerPrefs.SetInt("MediumRed", 00);
        PlayerPrefs.SetInt("MediumBlue", 00);
        PlayerPrefs.SetInt("MediumPurple", 0);
        PlayerPrefs.SetString("MediumControl", "CLASSIC");
        PlayerPrefs.SetString("MediumTime", "00:00");
        PlayerPrefs.SetInt("HardHighscore", 00);
        PlayerPrefs.SetString("HardPlayername", "A Biotic");
        PlayerPrefs.SetInt("HardRed", 00);
        PlayerPrefs.SetInt("HardBlue", 00);
        PlayerPrefs.SetInt("HardPurple", 0);
        PlayerPrefs.SetString("HardControl", "CLASSIC");
        PlayerPrefs.SetString("HardTime", "00:00");
        UpdateHighScoreDisplay();
    }

    //Clears all best times & player names when GUI button pressed, returns times to 59:59 and names to A Biotic
    public void ClearBestTImes()
    {

        PlayerPrefs.SetFloat("Level1BestTime", 3599);
        PlayerPrefs.SetString("Level1Playername", "A Biotic");
        PlayerPrefs.SetString("Level1Control", "CLASSIC");
        PlayerPrefs.SetFloat("Level2BestTime", 3599);
        PlayerPrefs.SetString("Level2Playername", "A Biotic");
        PlayerPrefs.SetString("Level2Control", "CLASSIC");
        PlayerPrefs.SetFloat("Level3BestTime", 3599);
        PlayerPrefs.SetString("Level3Playername", "A Biotic");
        PlayerPrefs.SetString("Level3Control", "CLASSIC");
        PlayerPrefs.SetFloat("Level4BestTime", 3599);
        PlayerPrefs.SetString("Level4Playername", "A Biotic");
        PlayerPrefs.SetString("Level4Control", "CLASSIC"); 
        PlayerPrefs.SetFloat("Level5BestTime", 3599);
        PlayerPrefs.SetString("Level5Playername", "A Biotic");
        PlayerPrefs.SetString("Level5Control", "CLASSIC");

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
            inGameOptions.InGameOff(); //ensure options screen is switched off
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
        switch (profileNumber)
        {
            case 1:
                PlayerPrefs.SetInt("SkinEquipped1", playerSkinEquipped);
                break;
            case 2:
                PlayerPrefs.SetInt("SkinEquipped2", playerSkinEquipped);
                break;
            case 3:
                PlayerPrefs.SetInt("SkinEquipped3", playerSkinEquipped);
                break;
        }
        PlayerPrefs.Save();

    }

    public void LoadSkin() //loads saved spaceship skin for that player profile from playerprefs
    {
        switch (profileNumber)
        {
            case 1:
                playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped1");
                break;
            case 2:
                playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped2");
                break;
            case 3:
                playerSkinEquipped = PlayerPrefs.GetInt("SkinEquipped3");
                break;
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
        switch (profileNumber)
        {
            case 1:
                if (playerName.text != PlayerPrefs.GetString("Player1Name"))
                {

                    confirmNameReset.SetActive(true);

                }
                break;
            case 2:
                if (playerName.text != PlayerPrefs.GetString("Player2Name"))
                {

                    confirmNameReset.SetActive(true);

                }
                break;
            case 3:
                if (playerName.text != PlayerPrefs.GetString("Player3Name"))
                {
                    confirmNameReset.SetActive(true);

                }
                break;
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
        InstantiateNewPlayerObject();
        spawnManager.StopSpawn();
        CommonToResetAndNext();
        gameOverScreen.SetActive(false);
        loseScreen.SetActive(false);
        timeElapsed = 0;


        if (gameEndless == true)
        {

           StartGameEndless(currentLevel);
        }

        if (gameEndless == false)
        {

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
        bestTimeCongrats.SetActive(false);
        timeElapsed = 0;
        StartGame(currentLevel + 1);

    }

    public void CommonToResetAndNext() // This is used when level restart or next level button is pressed.  Remaining items on the screen are removed, pause & quit buttons are
                                        // reactivated, weapon arm indicators are reset, highscore congrats screen is switched off
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

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Escape Pod"))
        {
            Destroy(gameObj);

        }

        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Character"))
        {
            Destroy(gameObj);

        }

        highscoreCongrats.gameObject.SetActive(false);
        pauseButton.SetActive(true);
        pauseButtonEndless.SetActive(true);
        quitButtonEndless.SetActive(true);
        quitButton.SetActive(true);
        armedText.gameObject.SetActive(false);
        unArmedText.gameObject.SetActive(true);
        armedTextEndless.gameObject.SetActive(false);
        unArmedTextEndless.gameObject.SetActive(true);
        cheatCodeManager.CheatCancel();
        LoadMusic();
    }

    public void InstantiateNewPlayerObject() // Used to instantaite a new player object when level is restarted after failure.  First the selected type is read from player
    {                                   // prefs, then the correct prefab is instantiated in the start position at the correct rotation
        

        switch (playerSkinEquipped)
        {
            case 0:
                player = spaceship1 = Instantiate(spaceship1Prefab, initialPosition, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                break;

            case 1:
                player = spaceship1 = Instantiate(spaceship1Prefab, initialPosition, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                break;

            case 2:
                player = spaceship2 = Instantiate(spaceship2Prefab, initialPosition, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                break;

            case 3:
                player = spaceship3 = Instantiate(spaceship3Prefab, initialPosition, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                break;

            case 4:
                player = spaceship4 = Instantiate(spaceship4Prefab, initialPosition, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                break;
        }
        

    }

    // Turning cheats on
    public void CheatOn() 
    {
        switch (cheatActive)
        {
            case 1:
                armedText.gameObject.SetActive(true);
                unArmedText.gameObject.SetActive(false);
                armedTextEndless.gameObject.SetActive(true);
                unArmedTextEndless.gameObject.SetActive(false);
                break;
            case 2:
                break;
            case 3:
                break;

        }
    }

    // Turning cheats off
    public void CheatOff()
    {
        armedText.gameObject.SetActive(false);
        unArmedText.gameObject.SetActive(true);
        armedTextEndless.gameObject.SetActive(false);
        unArmedTextEndless.gameObject.SetActive(true);

    }

    // Triggers the Alternate controls bool when toggle in options menu is used, and saves the state in playerprefs
    public void AltControls() 
    {
        if (altControlSlider.value == 1)      
        {
            controlEndlessText.text = "ALTERNATE";
            controlTimedText.text = "ALTERNATE";
            switch (profileNumber)
            {
                case 1:
                    PlayerPrefs.SetInt("Control1", 1);
                    break;
                case 2:
                    PlayerPrefs.SetFloat("Control2", 1);
                    break;
                case 3:
                    PlayerPrefs.SetFloat("Control3", 1);
                    break;
            }
        }
        else
        {
            controlEndlessText.text = "CLASSIC";
            controlTimedText.text = "CLASSIC";
            switch (profileNumber)
            {
                case 1:
                    PlayerPrefs.SetInt("Control1", 0);
                    break;
                case 2:
                    PlayerPrefs.SetFloat("Control2", 0);
                    break;
                case 3:
                    PlayerPrefs.SetFloat("Control3", 0);
                    break;
            }
        }
        PlayerPrefs.Save();

    }

    public void LoadControls() // Load normal or alt control setting from playerprefs and ensure state is displayed in toggle in options menu
    {
        switch (profileNumber)
        {
            case 1:
                controlType = PlayerPrefs.GetInt("Control1");
                break;
            case 2:
                controlType = PlayerPrefs.GetInt("Control2");
                break;
            case 3:
                controlType = PlayerPrefs.GetInt("Control3");
                break;
        }

        switch (controlType) 
        {
            case 0:
                altControlSlider.value = 0;
                controlEndlessText.text = "CLASSIC";
                controlTimedText.text = "CLASSIC";
                break;
            case 1:
                altControlSlider.value = 1;
                controlEndlessText.text = "ALTERNATE";
                controlTimedText.text = "ALTERNATE";
                break;
        }
    }

    public void TouchControls() 
    {
        if (gameStarted == true)
        {
            touchControls.SetActive(true);

            if (altControlSlider.value == 1) 
            {
                joystick.SetActive(true);
                boostButton.SetActive(false);          
            }

            if (altControlSlider.value == 0)
            {
                joystick.SetActive(false);
                boostButton.SetActive(true);
            }
         }
          else touchControls.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
