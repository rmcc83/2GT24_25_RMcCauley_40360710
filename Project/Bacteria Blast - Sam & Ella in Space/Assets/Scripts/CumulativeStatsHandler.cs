using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CumulativeStatsHandler : MonoBehaviour
{
    //COUNTS

    // Timed Levels Played
    public int level1Played;
    public int level2Played;
    public int level3Played;
    public int level4Played;
    public int level5Played;
    public int totalTimedPlayed;

    // Endless Levels Played
    public int easyEndlessPlayed;
    public int mediumEndlessPlayed;
    public int hardEndlessPlayed;
    public int totalEndlessPlayed;

    // Timed Levels Won
    public int level1Won;
    public int level2Won;
    public int level3Won;
    public int level4Won;
    public int level5Won;
    public int totalTimedWon;

    // Timed levels lost
    public int level1Lost;
    public int level2Lost;
    public int level3Lost;
    public int level4Lost;
    public int level5Lost;
    public int totalTimedLost;

    // Endless games halted by running out of lives
    public int easyEndlessLives;
    public int mediumEndlessLives;
    public int hardEndlessLives;
    public int totalEndlessLives;

    // Endless games halted by wrecking on asteroids
    public int easyEndlessAsteroid;
    public int mediumEndlessAsteroid;
    public int hardEndlessAsteroid;
    public int totalEndlessAsteroid;

    // Endless games halted by ground crash
    public int easyEndlessCrash;
    public int mediumEndlessCrash;
    public int hardEndlessCrash;
    public int totalEndlessCrash;

    // Total bacteria collected
    public int totalRedCollected;
    public int totalBlueCollected;
    public int totalPurpleCollected;

    // Total asteroids hit
    public int totalSmallHit;
    public int totalMediumHit;
    public int totalLargeHit;

    // Crash counts
    public int groundCrash;

    // Powerups collected, viruses caught, asteroid destroyed
    public int virusEncountered;
    public int asteroidsBlasted;
    public int weaponCollected;
    public int smallFuelCollected;
    public int largeFuelCollected;
    public int repairCollected;


    // TEXT FIELDS


    public TextMeshProUGUI TitleText;

    // Timed played text
    public TextMeshProUGUI level1PlayedText;
    public TextMeshProUGUI level2PlayedText;
    public TextMeshProUGUI level3PlayedText;
    public TextMeshProUGUI level4PlayedText;
    public TextMeshProUGUI level5PlayedText;
    public TextMeshProUGUI totalTimedPlayedText;

    // Endless played text
    public TextMeshProUGUI easyEndlessPlayedText;
    public TextMeshProUGUI mediumEndlessPlayedText;
    public TextMeshProUGUI hardEndlessPlayedText;
    public TextMeshProUGUI totalEndlessPlayedText;

    // Timed won text
    public TextMeshProUGUI level1WonText;
    public TextMeshProUGUI level2WonText;
    public TextMeshProUGUI level3WonText;
    public TextMeshProUGUI level4WonText;
    public TextMeshProUGUI level5WonText;
    public TextMeshProUGUI totalTimedWonText;

    // TImed lost text
    public TextMeshProUGUI level1LostText;
    public TextMeshProUGUI level2LostText;
    public TextMeshProUGUI level3LostText;
    public TextMeshProUGUI level4LostText;
    public TextMeshProUGUI level5LostText;
    public TextMeshProUGUI totalTimedLostText;

    // Endless games halted by running out of lives text
    public TextMeshProUGUI easyEndlessLivesText;
    public TextMeshProUGUI mediumEndlessLivesText;
    public TextMeshProUGUI hardEndlessLivesText;
    public TextMeshProUGUI totalEndlessLivesText;

    // Endless games halted by running out of lives text
    public TextMeshProUGUI easyEndlessAsteroidText;
    public TextMeshProUGUI mediumEndlessAsteroidText;
    public TextMeshProUGUI hardEndlessAsteroidText;
    public TextMeshProUGUI totalEndlessAsteroidText;


    //Endless games halted by ground crash text
    public TextMeshProUGUI easyEndlessCrashText;
    public TextMeshProUGUI mediumEndlessCrashText;
    public TextMeshProUGUI hardEndlessCrashText;
    public TextMeshProUGUI totalEndlessCrashText;
   
    // Bacteria collected text
    public TextMeshProUGUI totalRedCollectedText;
    public TextMeshProUGUI totalBlueCollectedText;
    public TextMeshProUGUI totalPurpleCollectedText;

    // Total asteroids hit text
    public TextMeshProUGUI totalSmallHitText;
    public TextMeshProUGUI totalMediumHitText;
    public TextMeshProUGUI totalLargeHitText;


    // Crash Counts text
    public TextMeshProUGUI groundCrashText;

    // Powerups collected, viruses caught, asteroid destroyed text
    public TextMeshProUGUI virusEncounteredText;
    public TextMeshProUGUI asteroidsBlastedText;
    public TextMeshProUGUI weaponCollectedText;
    public TextMeshProUGUI smallFuelCollectedText;
    public TextMeshProUGUI largeFuelCollectedText;
    public TextMeshProUGUI repairCollectedText;


    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Title()
    {
        TitleText.text = gameManager.playerName.text + "'s Cumulative Stats";

    }

    public void Level1Played() 
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level1Played = PlayerPrefs.GetInt("Level1Played1") + 1;
                PlayerPrefs.SetInt("Level1Played1", level1Played);
                level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played1")}";
                break;
            case 2:
                level1Played = PlayerPrefs.GetInt("Level1Played2") + 1;
                PlayerPrefs.SetInt("Level1Played2", level1Played);
                level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played2")}";
                break;
            case 3:
                level1Played = PlayerPrefs.GetInt("Level1Played3") + 1;
                PlayerPrefs.SetInt("Level1Played3", level1Played);
                level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played3")}";
                break;
        }

    }

    public void Level2Played()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level2Played = PlayerPrefs.GetInt("Level2Played1") + 1;
                PlayerPrefs.SetInt("Level2Played1", level2Played);
                level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played1")}";
                break;
            case 2:
                level2Played = PlayerPrefs.GetInt("Level2Played2") + 1;
                PlayerPrefs.SetInt("Level2Played2", level2Played);
                level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played2")}";
                break;
            case 3:
                level2Played = PlayerPrefs.GetInt("Level2Played3") + 1;
                PlayerPrefs.SetInt("Level2Played3", level2Played);
                level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played3")}";
                break;
        }

    }

    public void Level3Played()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level3Played = PlayerPrefs.GetInt("Level3Played1") + 1;
                PlayerPrefs.SetInt("Level3Played1", level3Played);
                level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played1")}";
                break;
            case 2:
                level3Played = PlayerPrefs.GetInt("Level3Played2") + 1;
                PlayerPrefs.SetInt("Level3Played2", level3Played);
                level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played2")}";
                break;
            case 3:
                level3Played = PlayerPrefs.GetInt("Level3Played3") + 1;
                PlayerPrefs.SetInt("Level3Played3", level3Played);
                level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played3")}";
                break;
        }

    }

    public void Level4Played()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level4Played = PlayerPrefs.GetInt("Level4Played1") + 1;
                PlayerPrefs.SetInt("Level4Played1", level4Played);
                level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played1")}";
                break;
            case 2:
                level4Played = PlayerPrefs.GetInt("Level4Played2") + 1;
                PlayerPrefs.SetInt("Level4Played2", level4Played);
                level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played2")}";
                break;
            case 3:
                level4Played = PlayerPrefs.GetInt("Level4Played3") + 1;
                PlayerPrefs.SetInt("Level4Played3", level4Played);
                level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played3")}";
                break;
        }

    }

    public void Level5Played()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level5Played = PlayerPrefs.GetInt("Level5Played1") + 1;
                PlayerPrefs.SetInt("Level5Played1", level5Played);
                level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played1")}";
                break;
            case 2:
                level5Played = PlayerPrefs.GetInt("Level5Played2") + 1;
                PlayerPrefs.SetInt("Level5Played2", level5Played);
                level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played2")}";
                break;
            case 3:
                level5Played = PlayerPrefs.GetInt("Level5Played3") + 1;
                PlayerPrefs.SetInt("Level5Played3", level5Played);
                level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played3")}";
                break;
        }

    }

    public void TotalTimedPlayed()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalTimedPlayed = PlayerPrefs.GetInt("TotalTimedPlayed1") + 1;
                PlayerPrefs.SetInt("TotalTimedPlayed1", totalTimedPlayed);
                totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed1")}";
                break;
            case 2:
                totalTimedPlayed = PlayerPrefs.GetInt("TotalTimedPlayed2") + 1;
                PlayerPrefs.SetInt("TotalTimedPlayed2", totalTimedPlayed);
                totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed2")}";
                break;
            case 3:
                totalTimedPlayed = PlayerPrefs.GetInt("TotalTimedPlayed3") + 1;
                PlayerPrefs.SetInt("TotalTimedPlayed3", totalTimedPlayed);
                totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed3")}";
                break;
        }

    }

    public void EasyEndlessPlayed()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                easyEndlessPlayed = PlayerPrefs.GetInt("EasyEndlessPlayed1") + 1;
                PlayerPrefs.SetInt("EasyEndlessPlayed1", easyEndlessPlayed);
                easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed1")}";
                break;
            case 2:
                easyEndlessPlayed = PlayerPrefs.GetInt("EasyEndlessPlayed2") + 1;
                PlayerPrefs.SetInt("EasyEndlessPlayed2", easyEndlessPlayed);
                easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed2")}";
                break;
            case 3:
                easyEndlessPlayed = PlayerPrefs.GetInt("EasyEndlessPlayed3") + 1;
                PlayerPrefs.SetInt("EasyEndlessPlayed3", easyEndlessPlayed);
                easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed3")}";
                break;
        }

    }

    public void MediumEndlessPlayed()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                mediumEndlessPlayed = PlayerPrefs.GetInt("MediumEndlessPlayed1") + 1;
                PlayerPrefs.SetInt("MediumEndlessPlayed1", mediumEndlessPlayed);
                mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed1")}";
                break;
            case 2:
                mediumEndlessPlayed = PlayerPrefs.GetInt("MediumEndlessPlayed2") + 1;
                PlayerPrefs.SetInt("MediumEndlessPlayed2", mediumEndlessPlayed);
                mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed2")}";
                break;
            case 3:
                mediumEndlessPlayed = PlayerPrefs.GetInt("MediumEndlessPlayed3") + 1;
                PlayerPrefs.SetInt("MediumEndlessPlayed3", mediumEndlessPlayed);
                mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed3")}";
                break;
        }

    }

    public void HardEndlessPlayed()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                hardEndlessPlayed = PlayerPrefs.GetInt("HardEndlessPlayed1") + 1;
                PlayerPrefs.SetInt("HardEndlessPlayed1", hardEndlessPlayed);
                hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed1")}";
                break;
            case 2:
                hardEndlessPlayed = PlayerPrefs.GetInt("HardEndlessPlayed2") + 1;
                PlayerPrefs.SetInt("HardEndlessPlayed2", hardEndlessPlayed);
                hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed2")}";
                break;
            case 3:
                hardEndlessPlayed = PlayerPrefs.GetInt("HardEndlessPlayed3") + 1;
                PlayerPrefs.SetInt("HardEndlessPlayed3", hardEndlessPlayed);
                hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed3")}";
                break;
        }

    }

    public void TotalEndlessPlayed() 
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalEndlessPlayed = PlayerPrefs.GetInt("TotalEndlessPlayed1") + 1;
                PlayerPrefs.SetInt("TotalEndlessPlayed1", totalEndlessPlayed);
                totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed1")}";
                break;
            case 2:
                totalEndlessPlayed = PlayerPrefs.GetInt("TotalEndlessPlayed2") + 1;
                PlayerPrefs.SetInt("TotalEndlessPlayed2", totalEndlessPlayed);
                totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed2")}";
                break;
            case 3:
                totalEndlessPlayed = PlayerPrefs.GetInt("TotalEndlessPlayed3") + 1;
                PlayerPrefs.SetInt("TotalEndlessPlayed3", totalEndlessPlayed);
                totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed3")}";
                break;
        }

    }

    public void Level1Won()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level1Won = PlayerPrefs.GetInt("Level1Won1") + 1;
                PlayerPrefs.SetInt("Level1Won1", level1Won);
                level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won1")}";
                break;
            case 2:
                level1Won = PlayerPrefs.GetInt("Level1Won2") + 1;
                PlayerPrefs.SetInt("Level1Won2", level1Won);
                level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won2")}";
                break;
            case 3:
                level1Won = PlayerPrefs.GetInt("Level1Won2") + 1;
                PlayerPrefs.SetInt("Level1Won2", level1Won);
                level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won2")}";
                break;
        }

    }

    public void Level2Won()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level2Won = PlayerPrefs.GetInt("Level2Won1") + 1;
                PlayerPrefs.SetInt("Level2Won1", level1Won);
                level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won1")}";
                break;
            case 2:
                level2Won = PlayerPrefs.GetInt("Level2Won2") + 1;
                PlayerPrefs.SetInt("Level2Won2", level2Won);
                level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won2")}";
                break;
            case 3:
                level2Won = PlayerPrefs.GetInt("Level2Won3") + 1;
                PlayerPrefs.SetInt("Level2Won3", level2Won);
                level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won3")}";
                break;
        }       
                
    }

    public void Level3Won()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level3Won = PlayerPrefs.GetInt("Level3Won1") + 1;
                PlayerPrefs.SetInt("Level3Won1", level3Won);
                level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won1")}";
                break;
            case 2:
                level3Won = PlayerPrefs.GetInt("Level3Won2") + 1;
                PlayerPrefs.SetInt("Level3Won2", level3Won);
                level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won2")}";
                break;
            case 3:
                level3Won = PlayerPrefs.GetInt("Level3Won3") + 1;
                PlayerPrefs.SetInt("Level3Won3", level3Won);
                level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won3")}";
                break;
        }

    }

    public void Level4Won()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level4Won = PlayerPrefs.GetInt("Level4Won1") + 1;
                PlayerPrefs.SetInt("Level4Won1", level4Won);
                level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won1")}";
                break;
            case 2:
                level4Won = PlayerPrefs.GetInt("Level4Won2") + 1;
                PlayerPrefs.SetInt("Level4Won2", level4Won);
                level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won2")}";
                break;
            case 3:
                level4Won = PlayerPrefs.GetInt("Level4Won3") + 1;
                PlayerPrefs.SetInt("Level4Won3", level4Won);
                level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won3")}";
                break;
        }

    }

    public void Level5Won()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level5Won = PlayerPrefs.GetInt("Level5Won1") + 1;
                PlayerPrefs.SetInt("Level5Won1", level5Won);
                level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won1")}";
                break;
            case 2:
                level5Won = PlayerPrefs.GetInt("Level5Won2") + 1;
                PlayerPrefs.SetInt("Level5Won2", level5Won);
                level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won2")}";
                break;
            case 3:
                level5Won = PlayerPrefs.GetInt("Level5Won3") + 1;
                PlayerPrefs.SetInt("Level5Won3", level5Won);
                level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won3")}";
                break;
        }
    }
    public void TotalTimedWon()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalTimedWon = PlayerPrefs.GetInt("TotalTimedWon1") + 1;
                PlayerPrefs.SetInt("TotalTimedWon1", totalTimedWon);
                totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon1")}";
                break;
            case 2:
                totalTimedWon = PlayerPrefs.GetInt("TotalTimedWon2") + 1;
                PlayerPrefs.SetInt("TotalTimedWon2", totalTimedWon);
                totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon2")}";
                break;
            case 3:
                totalTimedWon = PlayerPrefs.GetInt("TotalTimedWon3") + 1;
                PlayerPrefs.SetInt("TotalTimedWon3", totalTimedWon);
                totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon3")}";
                break;
        }

    }

    public void EasyEndlessLives()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                easyEndlessLives = PlayerPrefs.GetInt("EasyEndlessLives1") + 1;
                PlayerPrefs.SetInt("EasyEndlessLives1", easyEndlessLives);
                easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives1")}";
                break;
            case 2:
                easyEndlessLives = PlayerPrefs.GetInt("EasyEndlessLives2") + 1;
                PlayerPrefs.SetInt("EasyEndlessLives2", easyEndlessLives);
                easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives2")}";
                break;
            case 3:
                easyEndlessLives = PlayerPrefs.GetInt("EasyEndlessLives3") + 1;
                PlayerPrefs.SetInt("EasyEndlessLives3", easyEndlessLives);
                easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives3")}";
                break;
        }

    }

    public void MediumEndlessLives()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                mediumEndlessLives = PlayerPrefs.GetInt("MediumEndlessLives1") + 1;
                PlayerPrefs.SetInt("MediumEndlessLives1", mediumEndlessLives);
                mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives1")}";
                break;
            case 2:
                mediumEndlessLives = PlayerPrefs.GetInt("MediumEndlessLives2") + 1;
                PlayerPrefs.SetInt("MediumEndlessLives2", mediumEndlessLives);
                mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives2")}";
                break;
            case 3:
                mediumEndlessLives = PlayerPrefs.GetInt("MediumEndlessLives2") + 1;
                PlayerPrefs.SetInt("MediumEndlessLives2", mediumEndlessLives);
                mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives2")}";
                break;
        }
    }

    public void HardEndlessLives()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                hardEndlessLives = PlayerPrefs.GetInt("HardEndlessLives1") + 1;
                PlayerPrefs.SetInt("HardEndlessLives1", hardEndlessLives);
                hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives1")}";
                break;
            case 2:
                hardEndlessLives = PlayerPrefs.GetInt("HardEndlessLives2") + 1;
                PlayerPrefs.SetInt("HardEndlessLives1", hardEndlessLives);
                hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives1")}";
                break;
            case 3:
                hardEndlessLives = PlayerPrefs.GetInt("HardEndlessLives3") + 1;
                PlayerPrefs.SetInt("HardEndlessLives3", hardEndlessLives);
                hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives3")}";
                break;
        }

    }

    public void TotalEndlessLives()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalEndlessLives = PlayerPrefs.GetInt("TotalEndlessLives1") + 1;
                PlayerPrefs.SetInt("TotalEndlessLives1", totalEndlessLives);
                totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives1")}";
                break;
            case 2:
                totalEndlessLives = PlayerPrefs.GetInt("TotalEndlessLives2") + 1;
                PlayerPrefs.SetInt("TotalEndlessLives2", totalEndlessLives);
                totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives2")}";
                break;
            case 3:
                totalEndlessLives = PlayerPrefs.GetInt("TotalEndlessLives3") + 1;
                PlayerPrefs.SetInt("TotalEndlessLives3", totalEndlessLives);
                totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives3")}";
                break;
        }
    }

    public void Level1Lost()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level1Lost = PlayerPrefs.GetInt("Level1Lost1") + 1;
                PlayerPrefs.SetInt("Level1Lost1", level1Lost);
                level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost1")}";
                break;
            case 2:
                level1Lost = PlayerPrefs.GetInt("Level1Lost2") + 1;
                PlayerPrefs.SetInt("Level1Lost2", level1Lost);
                level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost2")}";
                break;
            case 3:
                level1Lost = PlayerPrefs.GetInt("Level1Lost3") + 1;
                PlayerPrefs.SetInt("Level1Lost3", level1Lost);
                level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost3")}";
                break;
        }

    }

    public void Level2Lost()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level2Lost = PlayerPrefs.GetInt("Level2Lost1") + 1;
                PlayerPrefs.SetInt("Level2Lost1", level2Lost);
                level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost1")}";
                break;
            case 2:
                level2Lost = PlayerPrefs.GetInt("Level2Lost2") + 1;
                PlayerPrefs.SetInt("Level2Lost2", level2Lost);
                level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost2")}";
                break;
            case 3:
                level2Lost = PlayerPrefs.GetInt("Level2Lost3") + 1;
                PlayerPrefs.SetInt("Level2Lost3", level2Lost);
                level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost3")}";
                break;
        }
    }

    public void Level3Lost()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level3Lost = PlayerPrefs.GetInt("Level3Lost1") + 1;
                PlayerPrefs.SetInt("Level3Lost1", level3Lost);
                level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost1")}";
                break;
            case 2:
                level3Lost = PlayerPrefs.GetInt("Level3Lost2") + 1;
                PlayerPrefs.SetInt("Level3Lost2", level3Lost);
                level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost2")}";
                break;
            case 3:
                level3Lost = PlayerPrefs.GetInt("Level3Lost2") + 1;
                PlayerPrefs.SetInt("Level3Lost2", level3Lost);
                level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost2")}";
                break;
        }

    }

    public void Level4Lost()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level4Lost = PlayerPrefs.GetInt("Level4Lost1") + 1;
                PlayerPrefs.SetInt("Level4Lost1", level4Lost);
                level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost1")}";
                break;
            case 2:
                level4Lost = PlayerPrefs.GetInt("Level4Lost2") + 1;
                PlayerPrefs.SetInt("Level4Lost2", level4Lost);
                level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost2")}";
                break;
            case 3:
                level4Lost = PlayerPrefs.GetInt("Level4Lost3") + 1;
                PlayerPrefs.SetInt("Level4Lost3", level4Lost);
                level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost3")}";
                break;
        }

    }

    public void Level5Lost()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level5Lost = PlayerPrefs.GetInt("Level5Lost1") + 1;
                PlayerPrefs.SetInt("Level5Lost1", level5Lost);
                level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost1")}";
                break;
            case 2:
                level5Lost = PlayerPrefs.GetInt("Level5Lost2") + 1;
                PlayerPrefs.SetInt("Level5Lost2", level5Lost);
                level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost2")}";
                break;
            case 3:
                level5Lost = PlayerPrefs.GetInt("Level5Lost3") + 1;
                PlayerPrefs.SetInt("Level5Lost3", level5Lost);
                level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost3")}";
                break;
        }
    }

    public void TotalTimedLost()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalTimedLost = PlayerPrefs.GetInt("TotalTimedLost1") + 1;
                PlayerPrefs.SetInt("TotalTimedLost1", totalTimedLost);
                totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost1")}";
                break;
            case 2:
                totalTimedLost = PlayerPrefs.GetInt("TotalTimedLost2") + 1;
                PlayerPrefs.SetInt("TotalTimedLost2", totalTimedLost);
                totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost2")}";
                break;
            case 3:
                totalTimedLost = PlayerPrefs.GetInt("TotalTimedLost3") + 1;
                PlayerPrefs.SetInt("TotalTimedLost3", totalTimedLost);
                totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost3")}";
                break;
        }

    }

    public void EasyEndlessCrash()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                easyEndlessCrash = PlayerPrefs.GetInt("EasyEndlessCrash1") + 1;
                PlayerPrefs.SetInt("EasyEndlessCrash1", easyEndlessCrash);
                easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash1")}";
                break;
            case 2:
                easyEndlessCrash = PlayerPrefs.GetInt("EasyEndlessCrash2") + 1;
                PlayerPrefs.SetInt("EasyEndlessCrash2", easyEndlessCrash);
                easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash2")}";
                break;
            case 3:
                easyEndlessCrash = PlayerPrefs.GetInt("EasyEndlessCrash3") + 1;
                PlayerPrefs.SetInt("EasyEndlessCrash3", easyEndlessCrash);
                easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash3")}";
                break;
        }
    }

    public void MediumEndlessCrash()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                mediumEndlessCrash = PlayerPrefs.GetInt("MediumEndlessCrash1") + 1;
                PlayerPrefs.SetInt("MediumEndlessCrash1", mediumEndlessCrash);
                mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash1")}";
                break;
            case 2:
                mediumEndlessCrash = PlayerPrefs.GetInt("MediumEndlessCrash2") + 1;
                PlayerPrefs.SetInt("MediumEndlessCrash2", mediumEndlessCrash);
                mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash2")}";
                break;
            case 3:
                mediumEndlessCrash = PlayerPrefs.GetInt("MediumEndlessCrash3") + 1;
                PlayerPrefs.SetInt("MediumEndlessCrash3", mediumEndlessCrash);
                mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash3")}";
                break;
        }
    }

    public void HardEndlessCrash()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                hardEndlessCrash = PlayerPrefs.GetInt("HardEndlessCrash1") + 1;
                PlayerPrefs.SetInt("HardEndlessCrash1", hardEndlessCrash);
                hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash1")}";
                break;
            case 2:
                hardEndlessCrash = PlayerPrefs.GetInt("HardEndlessCrash2") + 1;
                PlayerPrefs.SetInt("HardEndlessCrash2", hardEndlessCrash);
                hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash2")}";
                break;
            case 3:
                hardEndlessCrash = PlayerPrefs.GetInt("HardEndlessCrash3") + 1;
                PlayerPrefs.SetInt("HardEndlessCrash3", hardEndlessCrash);
                hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash3")}";
                break;
        }
    }

    public void TotalEndlessCrash()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalEndlessCrash = PlayerPrefs.GetInt("TotalEndlessCrash1") + 1;
                PlayerPrefs.SetInt("TotalEndlessCrash1", totalEndlessCrash);
                totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash1")}";
                break;
            case 2:
                totalEndlessCrash = PlayerPrefs.GetInt("TotalEndlessCrash2") + 1;
                PlayerPrefs.SetInt("TotalEndlessCrash2", totalEndlessCrash);
                totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash2")}";
                break;
            case 3:
                totalEndlessCrash = PlayerPrefs.GetInt("TotalEndlessCrash3") + 1;
                PlayerPrefs.SetInt("TotalEndlessCrash3", totalEndlessCrash);
                totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash3")}";
                break;
        }
    }

    public void EasyEndlessAsteroid()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                easyEndlessAsteroid = PlayerPrefs.GetInt("EasyEndlessAsteroid1") + 1;
                PlayerPrefs.SetInt("EasyEndlessAsteroid1", easyEndlessAsteroid);
                easyEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("EasyEndlessAsteroid1")}";
                break;
            case 2:
                easyEndlessAsteroid = PlayerPrefs.GetInt("EasyEndlessAsteroid2") + 1;
                PlayerPrefs.SetInt("EasyEndlessAsteroid2", easyEndlessAsteroid);
                easyEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("EasyEndlessAsteroid2")}";
                break;
            case 3:
                easyEndlessAsteroid = PlayerPrefs.GetInt("EasyEndlessAsteroid3") + 1;
                PlayerPrefs.SetInt("EasyEndlessAsteroid3", easyEndlessAsteroid);
                easyEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("EasyEndlessAsteroid3")}";
                break;
        }
    }

    public void MediumEndlessAsteroid()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                mediumEndlessAsteroid = PlayerPrefs.GetInt("MediumEndlessAsteroid1") + 1;
                PlayerPrefs.SetInt("MediumEndlessAsteroid1", mediumEndlessAsteroid);
                mediumEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("MediumEndlessAsteroid1")}";
                break;
            case 2:
                mediumEndlessAsteroid = PlayerPrefs.GetInt("MediumEndlessAsteroid2") + 1;
                PlayerPrefs.SetInt("MediumEndlessAsteroid2", mediumEndlessAsteroid);
                mediumEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("MediumEndlessAsteroid2")}";
                break;
            case 3:
                mediumEndlessAsteroid = PlayerPrefs.GetInt("MediumEndlessAsteroid3") + 1;
                PlayerPrefs.SetInt("MediumEndlessAsteroid3", mediumEndlessAsteroid);
                mediumEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("MediumEndlessAsteroid3")}";
                break;
        }

    }

    public void HardEndlessAsteroid()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                hardEndlessAsteroid = PlayerPrefs.GetInt("HardEndlessAsteroid1") + 1;
                PlayerPrefs.SetInt("HardEndlessAsteroid1", hardEndlessAsteroid);
                hardEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("HardEndlessAsteroid1")}";
                break;
            case 2:
                hardEndlessAsteroid = PlayerPrefs.GetInt("HardEndlessAsteroid2") + 1;
                PlayerPrefs.SetInt("HardEndlessAsteroid2", hardEndlessAsteroid);
                hardEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("HardEndlessAsteroid2")}";
                break;
            case 3:
                hardEndlessAsteroid = PlayerPrefs.GetInt("HardEndlessAsteroid3") + 1;
                PlayerPrefs.SetInt("HardEndlessAsteroid3", hardEndlessAsteroid);
                hardEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("HardEndlessAsteroid3")}";
                break;
        }
    }

    public void TotalEndlessAsteroid()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalEndlessAsteroid = PlayerPrefs.GetInt("TotalEndlessAsteroid1") + 1;
                PlayerPrefs.SetInt("TotalEndlessAsteroid1", totalEndlessAsteroid);
                totalEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("TotalEndlessAsteroid1")}";
                break;
            case 2:
                totalEndlessAsteroid = PlayerPrefs.GetInt("TotalEndlessAsteroid2") + 1;
                PlayerPrefs.SetInt("TotalEndlessAsteroid2", totalEndlessAsteroid);
                totalEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("TotalEndlessAsteroid2")}";
                break;
            case 3:
                totalEndlessAsteroid = PlayerPrefs.GetInt("TotalEndlessAsteroid3") + 1;
                PlayerPrefs.SetInt("TotalEndlessAsteroid3", totalEndlessAsteroid);
                totalEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("TotalEndlessAsteroid3")}";
                break;
        }
    }

    public void BacteriaCollected() 
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalRedCollected = PlayerPrefs.GetInt("TotalRedCollected1") + gameManager.redCollected;
                totalBlueCollected = PlayerPrefs.GetInt("TotalBlueCollected1") + gameManager.blueCollected;
                totalPurpleCollected = PlayerPrefs.GetInt("TotalPurpleCollected1") + gameManager.purpleCollected;
                PlayerPrefs.SetInt("TotalRedCollected1", totalRedCollected);
                PlayerPrefs.SetInt("TotalBlueCollected1", totalBlueCollected);
                PlayerPrefs.SetInt("TotalPurpleCollected1", totalPurpleCollected);
                totalRedCollectedText.text = $"{PlayerPrefs.GetInt("TotalRedCollected1")}";
                totalBlueCollectedText.text = $"{PlayerPrefs.GetInt("TotalBlueCollected1")}";
                totalPurpleCollectedText.text = $"{PlayerPrefs.GetInt("TotalPurpleCollected1")}";
                break;
            case 2:
                totalRedCollected = PlayerPrefs.GetInt("TotalRedCollected2") + gameManager.redCollected;
                totalBlueCollected = PlayerPrefs.GetInt("TotalBlueCollected2") + gameManager.blueCollected;
                totalPurpleCollected = PlayerPrefs.GetInt("TotalPurpleCollected2") + gameManager.purpleCollected;
                PlayerPrefs.SetInt("TotalRedCollected2", totalRedCollected);
                PlayerPrefs.SetInt("TotalBlueCollected2", totalBlueCollected);
                PlayerPrefs.SetInt("TotalPurpleCollected2", totalPurpleCollected);
                totalRedCollectedText.text = $"{PlayerPrefs.GetInt("TotalRedCollected2")}";
                totalBlueCollectedText.text = $"{PlayerPrefs.GetInt("TotalBlueCollected2")}";
                totalPurpleCollectedText.text = $"{PlayerPrefs.GetInt("TotalPurpleCollected2")}";
                break;
            case 3:
                totalRedCollected = PlayerPrefs.GetInt("TotalRedCollected3") + gameManager.redCollected;
                totalBlueCollected = PlayerPrefs.GetInt("TotalBlueCollected3") + gameManager.blueCollected;
                totalPurpleCollected = PlayerPrefs.GetInt("TotalPurpleCollected3") + gameManager.purpleCollected;
                PlayerPrefs.SetInt("TotalRedCollected3", totalRedCollected);
                PlayerPrefs.SetInt("TotalBlueCollected3", totalBlueCollected);
                PlayerPrefs.SetInt("TotalPurpleCollected3", totalPurpleCollected);
                totalRedCollectedText.text = $"{PlayerPrefs.GetInt("TotalRedCollected3")}";
                totalBlueCollectedText.text = $"{PlayerPrefs.GetInt("TotalBlueCollected3")}";
                totalPurpleCollectedText.text = $"{PlayerPrefs.GetInt("TotalPurpleCollected3")}";
                break;
        }

    }

    public void AsteroidsHit() 
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                totalSmallHit = PlayerPrefs.GetInt("TotalSmallHit1") + gameManager.smallAsteroidHit;
                totalMediumHit = PlayerPrefs.GetInt("TotalMediumHit1") + gameManager.mediumAsteroidHit;
                totalLargeHit = PlayerPrefs.GetInt("TotalLargeHit1") + gameManager.largeAsteroidHit;
                PlayerPrefs.SetInt("TotalSmallHit1", totalSmallHit);
                PlayerPrefs.SetInt("TotalMediumHit1", totalMediumHit);
                PlayerPrefs.SetInt("TotalLargeHit1", totalLargeHit);
                totalSmallHitText.text = $"{PlayerPrefs.GetInt("TotalSmallHit1")}";
                totalMediumHitText.text = $"{PlayerPrefs.GetInt("TotalMediumHit1")}";
                totalLargeHitText.text = $"{PlayerPrefs.GetInt("TotalLargeHit1")}";
                break;
            case 2:
                totalSmallHit = PlayerPrefs.GetInt("TotalSmallHit2") + gameManager.smallAsteroidHit;
                totalMediumHit = PlayerPrefs.GetInt("TotalMediumHit2") + gameManager.mediumAsteroidHit;
                totalLargeHit = PlayerPrefs.GetInt("TotalLargeHit2") + gameManager.largeAsteroidHit;
                PlayerPrefs.SetInt("TotalSmallHit2", totalSmallHit);
                PlayerPrefs.SetInt("TotalMediumHit2", totalMediumHit);
                PlayerPrefs.SetInt("TotalLargeHit2", totalLargeHit);
                totalSmallHitText.text = $"{PlayerPrefs.GetInt("TotalSmallHit2")}";
                totalMediumHitText.text = $"{PlayerPrefs.GetInt("TotalMediumHit2")}";
                totalLargeHitText.text = $"{PlayerPrefs.GetInt("TotalLargeHit2")}";
                break;
            case 3:
                totalSmallHit = PlayerPrefs.GetInt("TotalSmallHit3") + gameManager.smallAsteroidHit;
                totalMediumHit = PlayerPrefs.GetInt("TotalMediumHit3") + gameManager.mediumAsteroidHit;
                totalLargeHit = PlayerPrefs.GetInt("TotalLargeHit3") + gameManager.largeAsteroidHit;
                PlayerPrefs.SetInt("TotalSmallHit3", totalSmallHit);
                PlayerPrefs.SetInt("TotalMediumHit3", totalMediumHit);
                PlayerPrefs.SetInt("TotalLargeHit3", totalLargeHit);
                totalSmallHitText.text = $"{PlayerPrefs.GetInt("TotalSmallHit3")}";
                totalMediumHitText.text = $"{PlayerPrefs.GetInt("TotalMediumHit3")}";
                totalLargeHitText.text = $"{PlayerPrefs.GetInt("TotalLargeHit3")}";
                break;
        }
    }

    public void VirusEncountered() 
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                virusEncountered = PlayerPrefs.GetInt("VirusEncountered1") + gameManager.virusEncountered;
                PlayerPrefs.SetInt("VirusEncountered1", virusEncountered);
                virusEncounteredText.text = $"{PlayerPrefs.GetInt("VirusEncountered1")}";
                break;
            case 2:
                virusEncountered = PlayerPrefs.GetInt("VirusEncountered2") + gameManager.virusEncountered;
                PlayerPrefs.SetInt("VirusEncountered2", virusEncountered);
                virusEncounteredText.text = $"{PlayerPrefs.GetInt("VirusEncountered2")}";
                break;
            case 3:
                virusEncountered = PlayerPrefs.GetInt("VirusEncountered3") + gameManager.virusEncountered;
                PlayerPrefs.SetInt("VirusEncountered3", virusEncountered);
                virusEncounteredText.text = $"{PlayerPrefs.GetInt("VirusEncountered3")}";
                break;
        }
    }

    public void AsteroidsBlasted()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                asteroidsBlasted = PlayerPrefs.GetInt("AsteroidsBlasted1") + gameManager.asteroidsBlasted;
                PlayerPrefs.SetInt("AsteroidsBlasted1", asteroidsBlasted);
                asteroidsBlastedText.text = $"{PlayerPrefs.GetInt("AsteroidsBlasted1")}";
                break;
            case 2:
                asteroidsBlasted = PlayerPrefs.GetInt("AsteroidsBlasted2") + gameManager.asteroidsBlasted;
                PlayerPrefs.SetInt("AsteroidsBlasted2", asteroidsBlasted);
                asteroidsBlastedText.text = $"{PlayerPrefs.GetInt("AsteroidsBlasted2")}";
                break;
            case 3:
                asteroidsBlasted = PlayerPrefs.GetInt("AsteroidsBlasted3") + gameManager.asteroidsBlasted;
                PlayerPrefs.SetInt("AsteroidsBlasted3", asteroidsBlasted);
                asteroidsBlastedText.text = $"{PlayerPrefs.GetInt("AsteroidsBlasted3")}";
                break;
        }
    }

    public void WeaponCollected()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                weaponCollected = PlayerPrefs.GetInt("WeaponCollected1") + gameManager.weaponCollected;
                PlayerPrefs.SetInt("WeaponCollected1", weaponCollected);
                weaponCollectedText.text = $"{PlayerPrefs.GetInt("WeaponCollected1")}";
                break;
            case 2:
                weaponCollected = PlayerPrefs.GetInt("WeaponCollected2") + gameManager.weaponCollected;
                PlayerPrefs.SetInt("WeaponCollected2", weaponCollected);
                weaponCollectedText.text = $"{PlayerPrefs.GetInt("WeaponCollected2")}";
                break;
            case 3:
                weaponCollected = PlayerPrefs.GetInt("WeaponCollected3") + gameManager.weaponCollected;
                PlayerPrefs.SetInt("WeaponCollected3", weaponCollected);
                weaponCollectedText.text = $"{PlayerPrefs.GetInt("WeaponCollected3")}";
                break;
        }
    }

    public void SmallFuelCollected()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                smallFuelCollected = PlayerPrefs.GetInt("SmallFuelCollected1") + gameManager.smallFuelCollected;
                PlayerPrefs.SetInt("SmallFuelCollected1", smallFuelCollected);
                smallFuelCollectedText.text = $"{PlayerPrefs.GetInt("SmallFuelCollected1")}";
                break;
            case 2:
                smallFuelCollected = PlayerPrefs.GetInt("SmallFuelCollected2") + gameManager.smallFuelCollected;
                PlayerPrefs.SetInt("SmallFuelCollected2", smallFuelCollected);
                smallFuelCollectedText.text = $"{PlayerPrefs.GetInt("SmallFuelCollected2")}";
                break;
            case 3:
                smallFuelCollected = PlayerPrefs.GetInt("SmallFuelCollected3") + gameManager.smallFuelCollected;
                PlayerPrefs.SetInt("SmallFuelCollected3", smallFuelCollected);
                smallFuelCollectedText.text = $"{PlayerPrefs.GetInt("SmallFuelCollected3")}";
                break;
        }
    }

    public void LargeFuelCollected()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                largeFuelCollected = PlayerPrefs.GetInt("LargeFuelCollected1") + gameManager.largeFuelCollected;
                PlayerPrefs.SetInt("LargeFuelCollected1", largeFuelCollected);
                largeFuelCollectedText.text = $"{PlayerPrefs.GetInt("LargeFuelCollected1")}";
                break;
            case 2:
                largeFuelCollected = PlayerPrefs.GetInt("LargeFuelCollected2") + gameManager.largeFuelCollected;
                PlayerPrefs.SetInt("LargeFuelCollected2", largeFuelCollected);
                largeFuelCollectedText.text = $"{PlayerPrefs.GetInt("LargeFuelCollected2")}";
                break;
            case 3:
                largeFuelCollected = PlayerPrefs.GetInt("LargeFuelCollected3") + gameManager.largeFuelCollected;
                PlayerPrefs.SetInt("LargeFuelCollected3", largeFuelCollected);
                largeFuelCollectedText.text = $"{PlayerPrefs.GetInt("LargeFuelCollected3")}";
                break;
        }
    }

    public void RepairCollected()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                repairCollected = PlayerPrefs.GetInt("RepairCollected1") + gameManager.repairCollected;
                PlayerPrefs.SetInt("RepairCollected1", repairCollected);
                repairCollectedText.text = $"{PlayerPrefs.GetInt("RepairCollected1")}";
                break;
            case 2:
                repairCollected = PlayerPrefs.GetInt("RepairCollected2") + gameManager.repairCollected;
                PlayerPrefs.SetInt("RepairCollected2", repairCollected);
                repairCollectedText.text = $"{PlayerPrefs.GetInt("RepairCollected2")}";
                break;
            case 3:
                repairCollected = PlayerPrefs.GetInt("RepairCollected3") + gameManager.repairCollected;
                PlayerPrefs.SetInt("RepairCollected3", repairCollected);
                repairCollectedText.text = $"{PlayerPrefs.GetInt("RepairCollected3")}";
                break;
        }
    }



    public void GroundCrash()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                groundCrash = PlayerPrefs.GetInt("GroundCrash1") + 1;
                PlayerPrefs.SetInt("GroundCrash1", groundCrash);
                groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash1")}";
                break;
            case 2:
                groundCrash = PlayerPrefs.GetInt("GroundCrash2") + 1;
                PlayerPrefs.SetInt("GroundCrash2", groundCrash);
                groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash2")}";
                break;
            case 3:
                groundCrash = PlayerPrefs.GetInt("GroundCrash3") + 1;
                PlayerPrefs.SetInt("GroundCrash3", groundCrash);
                groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash3")}";
                break;
        }
    }




    public void RunAll() 
    {
        Title();
        UpdateDisplay();
        BacteriaCollected();
        AsteroidsHit();
        VirusEncountered();
        WeaponCollected();
        SmallFuelCollected();
        LargeFuelCollected();
        AsteroidsBlasted();
        RepairCollected();

    }

    public void ClearAll()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                PlayerPrefs.SetInt("Level1Played1", 0);
                PlayerPrefs.SetInt("Level2Played1", 0);
                PlayerPrefs.SetInt("Level3Played1", 0);
                PlayerPrefs.SetInt("Level4Played1", 0);
                PlayerPrefs.SetInt("Level5Played1", 0);
                PlayerPrefs.SetInt("TotalTimedPlayed1", 0);
                PlayerPrefs.SetInt("EasyEndlessPlayed1", 0);
                PlayerPrefs.SetInt("MediumEndlessPlayed1", 0);
                PlayerPrefs.SetInt("HardEndlessPlayed1", 0);
                PlayerPrefs.SetInt("TotalEndlessPlayed1", 0);
                PlayerPrefs.SetInt("Level1Won1", 0);
                PlayerPrefs.SetInt("Level2Won1", 0);
                PlayerPrefs.SetInt("Level3Won1", 0);
                PlayerPrefs.SetInt("Level4Won1", 0);
                PlayerPrefs.SetInt("Level5Won1", 0);
                PlayerPrefs.SetInt("TotalTimedWon1", 0);
                PlayerPrefs.SetInt("EasyEndlessLives1", 0);
                PlayerPrefs.SetInt("MediumEndlessLives1", 0);
                PlayerPrefs.SetInt("HardEndlessLives1", 0);
                PlayerPrefs.SetInt("TotalEndlessLives1", 0);
                PlayerPrefs.SetInt("Level1Lost1", 0);
                PlayerPrefs.SetInt("Level2Lost1", 0);
                PlayerPrefs.SetInt("Level3Lost1", 0);
                PlayerPrefs.SetInt("Level4Lost1", 0);
                PlayerPrefs.SetInt("Level5Lost1", 0);
                PlayerPrefs.SetInt("TotalTimedLost1", 0);
                PlayerPrefs.SetInt("EasyEndlessCrash1", 0);
                PlayerPrefs.SetInt("MediumEndlessCrash1", 0);
                PlayerPrefs.SetInt("HardEndlessCrash1", 0);
                PlayerPrefs.SetInt("TotalEndlessCrash1", 0);
                PlayerPrefs.SetInt("EasyEndlessAsteroid1", 0);
                PlayerPrefs.SetInt("MediumEndlessAsteroid1", 0);
                PlayerPrefs.SetInt("HardEndlessAsteroid1", 0);
                PlayerPrefs.SetInt("TotalEndlessAsteroid1", 0);
                PlayerPrefs.SetInt("TotalRedCollected1", 0);
                PlayerPrefs.SetInt("TotalBlueCollected1", 0);
                PlayerPrefs.SetInt("TotalPurpleCollected1", 0);
                PlayerPrefs.SetInt("TotalSmallHit1", 0);
                PlayerPrefs.SetInt("TotalMediumHit1", 0);
                PlayerPrefs.SetInt("TotalLargeHit1", 0);
                PlayerPrefs.SetInt("VirusEncountered1", 0);
                PlayerPrefs.SetInt("AsteroidsBlasted1", 0);
                PlayerPrefs.SetInt("WeaponCollected1", 0);
                PlayerPrefs.SetInt("SmallFuelCollected1", 0);
                PlayerPrefs.SetInt("LargeFuelCollected1", 0);
                PlayerPrefs.SetInt("GroundCrash1", 0);
                break;
            case 2:
                PlayerPrefs.SetInt("Level1Played2", 0);
                PlayerPrefs.SetInt("Level2Played2", 0);
                PlayerPrefs.SetInt("Level3Played2", 0);
                PlayerPrefs.SetInt("Level4Played2", 0);
                PlayerPrefs.SetInt("Level5Played2", 0);
                PlayerPrefs.SetInt("TotalTimedPlayed2", 0);
                PlayerPrefs.SetInt("EasyEndlessPlayed2", 0);
                PlayerPrefs.SetInt("MediumEndlessPlayed2", 0);
                PlayerPrefs.SetInt("HardEndlessPlayed2", 0);
                PlayerPrefs.SetInt("TotalEndlessPlayed2", 0);
                PlayerPrefs.SetInt("Level1Won2", 0);
                PlayerPrefs.SetInt("Level2Won2", 0);
                PlayerPrefs.SetInt("Level3Won2", 0);
                PlayerPrefs.SetInt("Level4Won2", 0);
                PlayerPrefs.SetInt("Level5Won2", 0);
                PlayerPrefs.SetInt("TotalTimedWon2", 0);
                PlayerPrefs.SetInt("EasyEndlessLives2", 0);
                PlayerPrefs.SetInt("MediumEndlessLives2", 0);
                PlayerPrefs.SetInt("HardEndlessLives2", 0);
                PlayerPrefs.SetInt("TotalEndlessLives2", 0);
                PlayerPrefs.SetInt("Level1Lost2", 0);
                PlayerPrefs.SetInt("Level2Lost2", 0);
                PlayerPrefs.SetInt("Level3Lost2", 0);
                PlayerPrefs.SetInt("Level4Lost2", 0);
                PlayerPrefs.SetInt("Level5Lost2", 0);
                PlayerPrefs.SetInt("TotalTimedLost2", 0);
                PlayerPrefs.SetInt("EasyEndlessCrash2", 0);
                PlayerPrefs.SetInt("MediumEndlessCrash2", 0);
                PlayerPrefs.SetInt("HardEndlessCrash2", 0);
                PlayerPrefs.SetInt("TotalEndlessCrash2", 0);
                PlayerPrefs.SetInt("EasyEndlessAsteroid2", 0);
                PlayerPrefs.SetInt("MediumEndlessAsteroid2", 0);
                PlayerPrefs.SetInt("HardEndlessAsteroid2", 0);
                PlayerPrefs.SetInt("TotalEndlessAsteroid2", 0);
                PlayerPrefs.SetInt("TotalRedCollected2", 0);
                PlayerPrefs.SetInt("TotalBlueCollected2", 0);
                PlayerPrefs.SetInt("TotalPurpleCollected2", 0);
                PlayerPrefs.SetInt("TotalSmallHit2", 0);
                PlayerPrefs.SetInt("TotalMediumHit2", 0);
                PlayerPrefs.SetInt("TotalLargeHit2", 0);
                PlayerPrefs.SetInt("VirusEncountered2", 0);
                PlayerPrefs.SetInt("AsteroidsBlasted2", 0);
                PlayerPrefs.SetInt("WeaponCollected2", 0);
                PlayerPrefs.SetInt("SmallFuelCollected2", 0);
                PlayerPrefs.SetInt("LargeFuelCollected2", 0);
                PlayerPrefs.SetInt("GroundCrash2", 0);
                break;
            case 3:
                PlayerPrefs.SetInt("Level1Played3", 0);
                PlayerPrefs.SetInt("Level2Played3", 0);
                PlayerPrefs.SetInt("Level3Played3", 0);
                PlayerPrefs.SetInt("Level4Played3", 0);
                PlayerPrefs.SetInt("Level5Played3", 0);
                PlayerPrefs.SetInt("TotalTimedPlayed3", 0);
                PlayerPrefs.SetInt("EasyEndlessPlayed3", 0);
                PlayerPrefs.SetInt("MediumEndlessPlayed3", 0);
                PlayerPrefs.SetInt("HardEndlessPlayed3", 0);
                PlayerPrefs.SetInt("TotalEndlessPlayed3", 0);
                PlayerPrefs.SetInt("Level1Won3", 0);
                PlayerPrefs.SetInt("Level2Won3", 0);
                PlayerPrefs.SetInt("Level3Won3", 0);
                PlayerPrefs.SetInt("Level4Won3", 0);
                PlayerPrefs.SetInt("Level5Won3", 0);
                PlayerPrefs.SetInt("TotalTimedWon3", 0);
                PlayerPrefs.SetInt("EasyEndlessLives3", 0);
                PlayerPrefs.SetInt("MediumEndlessLives3", 0);
                PlayerPrefs.SetInt("HardEndlessLives3", 0);
                PlayerPrefs.SetInt("TotalEndlessLives3", 0);
                PlayerPrefs.SetInt("Level1Lost3", 0);
                PlayerPrefs.SetInt("Level2Lost3", 0);
                PlayerPrefs.SetInt("Level3Lost3", 0);
                PlayerPrefs.SetInt("Level4Lost3", 0);
                PlayerPrefs.SetInt("Level5Lost3", 0);
                PlayerPrefs.SetInt("TotalTimedLost3", 0);
                PlayerPrefs.SetInt("EasyEndlessCrash3", 0);
                PlayerPrefs.SetInt("MediumEndlessCrash3", 0);
                PlayerPrefs.SetInt("HardEndlessCrash3", 0);
                PlayerPrefs.SetInt("TotalEndlessCrash3", 0);
                PlayerPrefs.SetInt("EasyEndlessAsteroid3", 0);
                PlayerPrefs.SetInt("MediumEndlessAsteroid3", 0);
                PlayerPrefs.SetInt("HardEndlessAsteroid3", 0);
                PlayerPrefs.SetInt("TotalEndlessAsteroid3", 0);
                PlayerPrefs.SetInt("TotalRedCollected3", 0);
                PlayerPrefs.SetInt("TotalBlueCollected3", 0);
                PlayerPrefs.SetInt("TotalPurpleCollected3", 0);
                PlayerPrefs.SetInt("TotalSmallHit3", 0);
                PlayerPrefs.SetInt("TotalMediumHit3", 0);
                PlayerPrefs.SetInt("TotalLargeHit3", 0);
                PlayerPrefs.SetInt("VirusEncountered3", 0);
                PlayerPrefs.SetInt("AsteroidsBlasted3", 0);
                PlayerPrefs.SetInt("WeaponCollected3", 0);
                PlayerPrefs.SetInt("SmallFuelCollected3", 0);
                PlayerPrefs.SetInt("LargeFuelCollected3", 0);
                PlayerPrefs.SetInt("GroundCrash3", 0);
                break;
        }
                RunAll();
    }

    public void UpdateDisplay()
    {
        switch (gameManager.profileNumber)
        {
            case 1:
                level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played1")}";
                level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played1")}";
                level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played1")}";
                level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played1")}";
                level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played1")}";
                totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed1")}";
                easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed1")}";
                mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed1")}";
                hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed1")}";
                totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed1")}";
                level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won1")}";
                level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won1")}";
                level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won1")}";
                level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won1")}";
                level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won1")}";
                totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon1")}";
                easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash1")}";
                mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash1")}";
                hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash1")}";
                totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash1")}";
                easyEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("EasyEndlessAsteroid1")}";
                mediumEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("MediumEndlessAsteroid1")}";
                hardEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("HardEndlessAsteroid1")}";
                totalEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("TotalEndlessAsteroid1")}";
                level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost1")}";
                level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost1")}";
                level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost1")}";
                level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost1")}";
                level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost1")}";
                totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost1")}";
                easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives1")}";
                mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives1")}";
                hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives1")}";
                totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives1")}";
                groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash1")}";
                break;
            case 2:
                level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played2")}";
                level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played2")}";
                level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played2")}";
                level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played2")}";
                level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played2")}";
                totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed2")}";
                easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed2")}";
                mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed2")}";
                hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed2")}";
                totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed2")}";
                level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won2")}";
                level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won2")}";
                level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won2")}";
                level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won2")}";
                level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won2")}";
                totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon2")}";
                easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash2")}";
                mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash2")}";
                hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash2")}";
                totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash2")}";
                easyEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("EasyEndlessAsteroid2")}";
                mediumEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("MediumEndlessAsteroid2")}";
                hardEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("HardEndlessAsteroid2")}";
                totalEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("TotalEndlessAsteroid2")}";
                level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost2")}";
                level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost2")}";
                level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost2")}";
                level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost2")}";
                level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost2")}";
                totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost2")}";
                easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives2")}";
                mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives2")}";
                hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives2")}";
                totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives2")}";
                groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash2")}";
                break;
            case 3:
                level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played3")}";
                level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played3")}";
                level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played3")}";
                level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played3")}";
                level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played3")}";
                totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed3")}";
                easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed3")}";
                mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed3")}";
                hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed3")}";
                totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed3")}";
                level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won3")}";
                level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won3")}";
                level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won3")}";
                level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won3")}";
                level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won3")}";
                totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon3")}";
                easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash3")}";
                mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash3")}";
                hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash3")}";
                totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash3")}";
                easyEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("EasyEndlessAsteroid3")}";
                mediumEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("MediumEndlessAsteroid3")}";
                hardEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("HardEndlessAsteroid3")}";
                totalEndlessAsteroidText.text = $"{PlayerPrefs.GetInt("TotalEndlessAsteroid3")}";
                level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost3")}";
                level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost3")}";
                level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost3")}";
                level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost3")}";
                level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost3")}";
                totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost3")}";
                easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives3")}";
                mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives3")}";
                hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives3")}";
                totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives3")}";
                groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash3")}";
                break;
        }
    }

}


