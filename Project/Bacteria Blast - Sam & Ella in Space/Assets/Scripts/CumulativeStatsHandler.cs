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

    // Endless games halted by crash
    public int easyEndlessCrash;
    public int mediumEndlessCrash;
    public int hardEndlessCrash;
    public int totalEndlessCrash;

    // Total bacteria collected
    public int totalRedCollected;
    public int totalBlueCollected;
    public int totalPurpleCollected;

    // Crash counts
    public int asteroidCrash;
    public int groundCrash;

    // Powerups collected, viruses caught, asteroid destroyed
    public int virusEncountered;
    public int asteroidsBlasted;
    public int weaponCollected;
    public int smallFuelCollected;
    public int largeFuelCollected;


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


    //Endless games halted by crash text
    public TextMeshProUGUI easyEndlessCrashText;
    public TextMeshProUGUI mediumEndlessCrashText;
    public TextMeshProUGUI hardEndlessCrashText;
    public TextMeshProUGUI totalEndlessCrashText;
   
    // Bacteria collected text
    public TextMeshProUGUI totalRedCollectedText;
    public TextMeshProUGUI totalBlueCollectedText;
    public TextMeshProUGUI totalPurpleCollectedText;

    // Crash Counts text
    public TextMeshProUGUI asteroidCrashText;
    public TextMeshProUGUI groundCrashText;

    // Powerups collected, viruses caught, asteroid destroyed text
    public TextMeshProUGUI virusEncounteredText;
    public TextMeshProUGUI asteroidsBlastedText;
    public TextMeshProUGUI weaponCollectedText;
    public TextMeshProUGUI smallFuelCollectedText;
    public TextMeshProUGUI largeFuelCollectedText;


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
        if (gameManager.player1 == true)
        {
            level1Played = PlayerPrefs.GetInt("Level1Played1") + 1;
            PlayerPrefs.SetInt("Level1Played1", level1Played);
            level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played1")}";
        }

        if (gameManager.player2 == true)
        {
            level1Played = PlayerPrefs.GetInt("Level1Played2") + 1;
            PlayerPrefs.SetInt("Level1Played2", level1Played);
            level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played2")}";
        }

        if (gameManager.player3 == true)
        {
            level1Played = PlayerPrefs.GetInt("Level1Played3") + 1;
            PlayerPrefs.SetInt("Level1Played3", level1Played);
            level1PlayedText.text = $"{PlayerPrefs.GetInt("Level1Played3")}";
        }

    }

    public void Level2Played()
    {
        if (gameManager.player1 == true)
        {
            level2Played = PlayerPrefs.GetInt("Level2Played1") + 1;
            PlayerPrefs.SetInt("Level2Played1", level2Played);
            level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played1")}";
        }

        if (gameManager.player2 == true)
        {
            level2Played = PlayerPrefs.GetInt("Level2Played2") + 1;
            PlayerPrefs.SetInt("Level2Played2", level2Played);
            level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played2")}";
        }

        if (gameManager.player3 == true)
        {
            level2Played = PlayerPrefs.GetInt("Level2Played3") + 1;
            PlayerPrefs.SetInt("Level2Played3", level2Played);
            level2PlayedText.text = $"{PlayerPrefs.GetInt("Level2Played3")}";
        }

    }

    public void Level3Played()
    {
        if (gameManager.player1 == true)
        {
            level3Played = PlayerPrefs.GetInt("Level3Played1") + 1;
            PlayerPrefs.SetInt("Level3Played1", level3Played);
            level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played1")}";
        }

        if (gameManager.player2 == true)
        {
            level3Played = PlayerPrefs.GetInt("Level3Played2") + 1;
            PlayerPrefs.SetInt("Level3Played2", level3Played);
            level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played2")}";
        }

        if (gameManager.player3 == true)
        {
            level3Played = PlayerPrefs.GetInt("Level3Played3") + 1;
            PlayerPrefs.SetInt("Level3Played3", level3Played);
            level3PlayedText.text = $"{PlayerPrefs.GetInt("Level3Played3")}";
        }

    }

    public void Level4Played()
    {
        if (gameManager.player1 == true)
        {
            level4Played = PlayerPrefs.GetInt("Level4Played1") + 1;
            PlayerPrefs.SetInt("Level4Played1", level4Played);
            level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played1")}";
        }

        if (gameManager.player2 == true)
        {
            level4Played = PlayerPrefs.GetInt("Level4Played2") + 1;
            PlayerPrefs.SetInt("Level4Played2", level4Played);
            level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played2")}";
        }

        if (gameManager.player3 == true)
        {
            level4Played = PlayerPrefs.GetInt("Level4Played3") + 1;
            PlayerPrefs.SetInt("Level4Played3", level4Played);
            level4PlayedText.text = $"{PlayerPrefs.GetInt("Level4Played3")}";
        }

    }

    public void Level5Played()
    {
        if (gameManager.player1 == true)
        {
            level5Played = PlayerPrefs.GetInt("Level5Played1") + 1;
            PlayerPrefs.SetInt("Level5Played1", level5Played);
            level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played1")}";
        }

        if (gameManager.player2 == true)
        {
            level5Played = PlayerPrefs.GetInt("Level5Played2") + 1;
            PlayerPrefs.SetInt("Level5Played2", level5Played);
            level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played2")}";
        }

        if (gameManager.player3 == true)
        {
            level5Played = PlayerPrefs.GetInt("Level5Played3") + 1;
            PlayerPrefs.SetInt("Level5Played3", level5Played);
            level5PlayedText.text = $"{PlayerPrefs.GetInt("Level5Played3")}";
        }

    }

    public void TotalTimedPlayed()
    {
        if (gameManager.player1 == true)
        {
            totalTimedPlayed = PlayerPrefs.GetInt("TotalTimedPlayed1") + 1;
            PlayerPrefs.SetInt("TotalTimedPlayed1", totalTimedPlayed);
            totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed1")}";
        }

        if (gameManager.player2 == true)
        {
            totalTimedPlayed = PlayerPrefs.GetInt("TotalTimedPlayed2") + 1;
            PlayerPrefs.SetInt("TotalTimedPlayed2", totalTimedPlayed);
            totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed2")}";
        }

        if (gameManager.player3 == true)
        {
            totalTimedPlayed = PlayerPrefs.GetInt("TotalTimedPlayed3") + 1;
            PlayerPrefs.SetInt("TotalTimedPlayed3", totalTimedPlayed);
            totalTimedPlayedText.text = $"{PlayerPrefs.GetInt("TotalTimedPlayed3")}";
        }

    }

    public void EasyEndlessPlayed()
    {
        if (gameManager.player1 == true)
        {
            easyEndlessPlayed = PlayerPrefs.GetInt("EasyEndlessPlayed1") + 1;
            PlayerPrefs.SetInt("EasyEndlessPlayed1", easyEndlessPlayed);
            easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed1")}";
        }

        if (gameManager.player2 == true)
        {
            easyEndlessPlayed = PlayerPrefs.GetInt("EasyEndlessPlayed2") + 1;
            PlayerPrefs.SetInt("EasyEndlessPlayed2", easyEndlessPlayed);
            easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed2")}";
        }

        if (gameManager.player3 == true)
        {
            easyEndlessPlayed = PlayerPrefs.GetInt("EasyEndlessPlayed3") + 1;
            PlayerPrefs.SetInt("EasyEndlessPlayed3", easyEndlessPlayed);
            easyEndlessPlayedText.text = $"{PlayerPrefs.GetInt("EasyEndlessPlayed3")}";
        }

    }

    public void MediumEndlessPlayed()
    {
        if (gameManager.player1 == true)
        {
            mediumEndlessPlayed = PlayerPrefs.GetInt("MediumEndlessPlayed1") + 1;
            PlayerPrefs.SetInt("MediumEndlessPlayed1", mediumEndlessPlayed);
            mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed1")}";
        }

        if (gameManager.player2 == true)
        {
            mediumEndlessPlayed = PlayerPrefs.GetInt("MediumEndlessPlayed2") + 1;
            PlayerPrefs.SetInt("MediumEndlessPlayed2", mediumEndlessPlayed);
            mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed2")}";
        }

        if (gameManager.player3 == true)
        {
            mediumEndlessPlayed = PlayerPrefs.GetInt("MediumEndlessPlayed3") + 1;
            PlayerPrefs.SetInt("MediumEndlessPlayed3", mediumEndlessPlayed);
            mediumEndlessPlayedText.text = $"{PlayerPrefs.GetInt("MediumEndlessPlayed3")}";
        }

    }

    public void HardEndlessPlayed()
    {
        if (gameManager.player1 == true)
        {
            hardEndlessPlayed = PlayerPrefs.GetInt("HardEndlessPlayed1") + 1;
            PlayerPrefs.SetInt("HardEndlessPlayed1", hardEndlessPlayed);
            hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed1")}";
        }

        if (gameManager.player2 == true)
        {
            hardEndlessPlayed = PlayerPrefs.GetInt("HardEndlessPlayed2") + 1;
            PlayerPrefs.SetInt("HardEndlessPlayed2", hardEndlessPlayed);
            hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed2")}";
        }

        if (gameManager.player3 == true)
        {
            hardEndlessPlayed = PlayerPrefs.GetInt("HardEndlessPlayed3") + 1;
            PlayerPrefs.SetInt("HardEndlessPlayed3", hardEndlessPlayed);
            hardEndlessPlayedText.text = $"{PlayerPrefs.GetInt("HardEndlessPlayed3")}";
        }

    }

    public void TotalEndlessPlayed() 
    {
        if (gameManager.player1 == true)
        {
            totalEndlessPlayed = PlayerPrefs.GetInt("TotalEndlessPlayed1") + 1;
            PlayerPrefs.SetInt("TotalEndlessPlayed1", totalEndlessPlayed);
            totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed1")}";
        }

        if (gameManager.player2 == true)
        {
            totalEndlessPlayed = PlayerPrefs.GetInt("TotalEndlessPlayed2") + 1;
            PlayerPrefs.SetInt("TotalEndlessPlayed2", totalEndlessPlayed);
            totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed2")}";
        }

        if (gameManager.player3 == true)
        {
            totalEndlessPlayed = PlayerPrefs.GetInt("TotalEndlessPlayed3") + 1;
            PlayerPrefs.SetInt("TotalEndlessPlayed3", totalEndlessPlayed);
            totalEndlessPlayedText.text = $"{PlayerPrefs.GetInt("TotalEndlessPlayed3")}";
        }

    }

    public void Level1Won()
    {
        if (gameManager.player1 == true)
        {
            level1Won = PlayerPrefs.GetInt("Level1Won1") + 1;
            PlayerPrefs.SetInt("Level1Won1", level1Won);
            level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won1")}";
        }

        if (gameManager.player2 == true)
        {
            level1Won = PlayerPrefs.GetInt("Level1Won2") + 1;
            PlayerPrefs.SetInt("Level1Won2", level1Won);
            level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won2")}";
        }

        if (gameManager.player3 == true)
        {
            level1Won = PlayerPrefs.GetInt("Level1Won3") + 1;
            PlayerPrefs.SetInt("Level1Won3", level1Won);
            level1WonText.text = $"{PlayerPrefs.GetInt("Level1Won3")}";
        }

    }

    public void Level2Won()
    {
        if (gameManager.player1 == true)
        {
            level2Won = PlayerPrefs.GetInt("Level2Won1") + 1;
            PlayerPrefs.SetInt("Level2Won1", level1Won);
            level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won1")}";
        }

        if (gameManager.player2 == true)
        {
            level2Won = PlayerPrefs.GetInt("Level2Won2") + 1;
            PlayerPrefs.SetInt("Level2Won2", level2Won);
            level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won2")}";
        }

        if (gameManager.player3 == true)
        {
            level2Won = PlayerPrefs.GetInt("Level2Won3") + 1;
            PlayerPrefs.SetInt("Level2Won3", level2Won);
            level2WonText.text = $"{PlayerPrefs.GetInt("Level2Won3")}";
        }

    }

    public void Level3Won()
    {
        if (gameManager.player1 == true)
        {
            level3Won = PlayerPrefs.GetInt("Level3Won1") + 1;
            PlayerPrefs.SetInt("Level3Won1", level3Won);
            level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won1")}";
        }

        if (gameManager.player2 == true)
        {
            level3Won = PlayerPrefs.GetInt("Level3Won2") + 1;
            PlayerPrefs.SetInt("Level3Won2", level3Won);
            level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won2")}";
        }

        if (gameManager.player3 == true)
        {
            level3Won = PlayerPrefs.GetInt("Level3Won3") + 1;
            PlayerPrefs.SetInt("Level3Won3", level3Won);
            level3WonText.text = $"{PlayerPrefs.GetInt("Level3Won3")}";
        }

    }

    public void Level4Won()
    {
        if (gameManager.player1 == true)
        {
            level4Won = PlayerPrefs.GetInt("Level4Won1") + 1;
            PlayerPrefs.SetInt("Level4Won1", level4Won);
            level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won1")}";
        }

        if (gameManager.player2 == true)
        {
            level4Won = PlayerPrefs.GetInt("Level4Won2") + 1;
            PlayerPrefs.SetInt("Level4Won2", level4Won);
            level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won2")}";
        }

        if (gameManager.player3 == true)
        {
            level4Won = PlayerPrefs.GetInt("Level4Won3") + 1;
            PlayerPrefs.SetInt("Level4Won3", level4Won);
            level4WonText.text = $"{PlayerPrefs.GetInt("Level4Won3")}";
        }

    }

    public void Level5Won()
    {
        if (gameManager.player1 == true)
        {
            level5Won = PlayerPrefs.GetInt("Level5Won1") + 1;
            PlayerPrefs.SetInt("Level5Won1", level5Won);
            level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won1")}";
        }

        if (gameManager.player2 == true)
        {
            level5Won = PlayerPrefs.GetInt("Level5Won2") + 1;
            PlayerPrefs.SetInt("Level5Won2", level5Won);
            level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won2")}";
        }

        if (gameManager.player3 == true)
        {
            level5Won = PlayerPrefs.GetInt("Level5Won3") + 1;
            PlayerPrefs.SetInt("Level5Won3", level5Won);
            level5WonText.text = $"{PlayerPrefs.GetInt("Level5Won3")}";
        }

    }
    public void TotalTimedWon()
    {
        if (gameManager.player1 == true)
        {
            totalTimedWon = PlayerPrefs.GetInt("TotalTimedWon1") + 1;
            PlayerPrefs.SetInt("TotalTimedWon1", totalTimedWon);
            totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon1")}";
        }

        if (gameManager.player2 == true)
        {
            totalTimedWon = PlayerPrefs.GetInt("TotalTimedWon2") + 1;
            PlayerPrefs.SetInt("TotalTimedWon2", totalTimedWon);
            totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon2")}";
        }

        if (gameManager.player3 == true)
        {
            totalTimedWon = PlayerPrefs.GetInt("TotalTimedWon3") + 1;
            PlayerPrefs.SetInt("TotalTimedWon3", totalTimedWon);
            totalTimedWonText.text = $"{PlayerPrefs.GetInt("TotalTimedWon3")}";
        }

    }

    public void EasyEndlessLives()
    {
        if (gameManager.player1 == true)
        {
            easyEndlessLives = PlayerPrefs.GetInt("EasyEndlessLives1") + 1;
            PlayerPrefs.SetInt("EasyEndlessLives1", easyEndlessLives);
            easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives1")}";
        }

        if (gameManager.player2 == true)
        {
            easyEndlessLives = PlayerPrefs.GetInt("EasyEndlessLives2") + 1;
            PlayerPrefs.SetInt("EasyEndlessLives2", easyEndlessLives);
            easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives2")}";
        }

        if (gameManager.player3 == true)
        {
            easyEndlessLives = PlayerPrefs.GetInt("EasyEndlessLives3") + 1;
            PlayerPrefs.SetInt("EasyEndlessLives3", easyEndlessLives);
            easyEndlessLivesText.text = $"{PlayerPrefs.GetInt("EasyEndlessLives3")}";
        }

    }

    public void MediumEndlessLives()
    {
        if (gameManager.player1 == true)
        {
            mediumEndlessLives = PlayerPrefs.GetInt("MediumEndlessLives1") + 1;
            PlayerPrefs.SetInt("MediumEndlessLives1", mediumEndlessLives);
            mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives1")}";
        }

        if (gameManager.player2 == true)
        {
            mediumEndlessLives = PlayerPrefs.GetInt("MediumEndlessLives2") + 1;
            PlayerPrefs.SetInt("MediumEndlessLives2", mediumEndlessLives);
            mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives2")}";
        }

        if (gameManager.player3 == true)
        {
            mediumEndlessLives = PlayerPrefs.GetInt("MediumEndlessLives3") + 1;
            PlayerPrefs.SetInt("MediumEndlessLives3", mediumEndlessLives);
            mediumEndlessLivesText.text = $"{PlayerPrefs.GetInt("MediumEndlessLives3")}";
        }

    }

    public void HardEndlessLives()
    {
        if (gameManager.player1 == true)
        {
            hardEndlessLives = PlayerPrefs.GetInt("HardEndlessLives1") + 1;
            PlayerPrefs.SetInt("HardEndlessLives1", hardEndlessLives);
            hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives1")}";
        }

        if (gameManager.player2 == true)
        {
            hardEndlessLives = PlayerPrefs.GetInt("HardEndlessLives2") + 1;
            PlayerPrefs.SetInt("HardEndlessLives2", hardEndlessLives);
            hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives2")}";
        }

        if (gameManager.player3 == true)
        {
            hardEndlessLives = PlayerPrefs.GetInt("HardEndlessLives3") + 1;
            PlayerPrefs.SetInt("HardEndlessLives3", hardEndlessLives);
            hardEndlessLivesText.text = $"{PlayerPrefs.GetInt("HardEndlessLives3")}";
        }

    }

    public void TotalEndlessLives()
    {
        if (gameManager.player1 == true)
        {
            totalEndlessLives = PlayerPrefs.GetInt("TotalEndlessLives1") + 1;
            PlayerPrefs.SetInt("TotalEndlessLives1", totalEndlessLives);
            totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives1")}";
        }

        if (gameManager.player2 == true)
        {
            totalEndlessLives = PlayerPrefs.GetInt("TotalEndlessLives2") + 1;
            PlayerPrefs.SetInt("TotalEndlessLives2", totalEndlessLives);
            totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives2")}";
        }

        if (gameManager.player3 == true)
        {
            totalEndlessLives = PlayerPrefs.GetInt("TotalEndlessLives3") + 1;
            PlayerPrefs.SetInt("TotalEndlessLives3", totalEndlessLives);
            totalEndlessLivesText.text = $"{PlayerPrefs.GetInt("TotalEndlessLives3")}";
        }

    }

    public void Level1Lost()
    {
        if (gameManager.player1 == true)
        {
            level1Lost = PlayerPrefs.GetInt("Level1Lost1") + 1;
            PlayerPrefs.SetInt("Level1Lost1", level1Lost);
            level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost1")}";
        }

        if (gameManager.player2 == true)
        {
            level1Lost = PlayerPrefs.GetInt("Level1Lost2") + 1;
            PlayerPrefs.SetInt("Level1Lost2", level1Lost);
            level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost2")}";
        }

        if (gameManager.player3 == true)
        {
            level1Lost = PlayerPrefs.GetInt("Level1Lost3") + 1;
            PlayerPrefs.SetInt("Level1Lost3", level1Lost);
            level1LostText.text = $"{PlayerPrefs.GetInt("Level1Lost3")}";
        }

    }

    public void Level2Lost()
    {
        if (gameManager.player1 == true)
        {
            level2Lost = PlayerPrefs.GetInt("Level2Lost1") + 1;
            PlayerPrefs.SetInt("Level2Lost1", level2Lost);
            level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost1")}";
        }

        if (gameManager.player2 == true)
        {
            level2Lost = PlayerPrefs.GetInt("Level2Lost2") + 1;
            PlayerPrefs.SetInt("Level2Lost2", level2Lost);
            level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost2")}";
        }

        if (gameManager.player3 == true)
        {
            level2Lost = PlayerPrefs.GetInt("Level2Lost3") + 1;
            PlayerPrefs.SetInt("Level2Lost3", level2Lost);
            level2LostText.text = $"{PlayerPrefs.GetInt("Level2Lost3")}";
        }

    }

    public void Level3Lost()
    {
        if (gameManager.player1 == true)
        {
            level3Lost = PlayerPrefs.GetInt("Level3Lost1") + 1;
            PlayerPrefs.SetInt("Level3Lost1", level3Lost);
            level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost1")}";
        }

        if (gameManager.player2 == true)
        {
            level3Lost = PlayerPrefs.GetInt("Level3Lost2") + 1;
            PlayerPrefs.SetInt("Level3Lost2", level3Lost);
            level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost2")}";
        }

        if (gameManager.player3 == true)
        {
            level3Lost = PlayerPrefs.GetInt("Level3Lost3") + 1;
            PlayerPrefs.SetInt("Level3Lost3", level3Lost);
            level3LostText.text = $"{PlayerPrefs.GetInt("Level3Lost3")}";
        }

    }

    public void Level4Lost()
    {
        if (gameManager.player1 == true)
        {
            level4Lost = PlayerPrefs.GetInt("Level4Lost1") + 1;
            PlayerPrefs.SetInt("Level4Lost1", level4Lost);
            level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost1")}";
        }

        if (gameManager.player2 == true)
        {
            level4Lost = PlayerPrefs.GetInt("Level4Lost2") + 1;
            PlayerPrefs.SetInt("Level4Lost2", level4Lost);
            level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost2")}";
        }

        if (gameManager.player3 == true)
        {
            level4Lost = PlayerPrefs.GetInt("Level4Lost3") + 1;
            PlayerPrefs.SetInt("Level4Lost3", level4Lost);
            level4LostText.text = $"{PlayerPrefs.GetInt("Level4Lost3")}";
        }

    }

    public void Level5Lost()
    {
        if (gameManager.player1 == true)
        {
            level5Lost = PlayerPrefs.GetInt("Level5Lost1") + 1;
            PlayerPrefs.SetInt("Level5Lost1", level5Lost);
            level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost1")}";
        }

        if (gameManager.player2 == true)
        {
            level5Lost = PlayerPrefs.GetInt("Level5Lost2") + 1;
            PlayerPrefs.SetInt("Level5Lost2", level5Lost);
            level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost2")}";
        }

        if (gameManager.player3 == true)
        {
            level5Lost = PlayerPrefs.GetInt("Level5Lost3") + 1;
            PlayerPrefs.SetInt("Level5Lost3", level5Lost);
            level5LostText.text = $"{PlayerPrefs.GetInt("Level5Lost3")}";
        }

    }

    public void TotalTimedLost()
    {
        if (gameManager.player1 == true)
        {
            totalTimedLost = PlayerPrefs.GetInt("TotalTimedLost1") + 1;
            PlayerPrefs.SetInt("TotalTimedLost1", totalTimedLost);
            totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost1")}";
        }

        if (gameManager.player2 == true)
        {
            totalTimedLost = PlayerPrefs.GetInt("TotalTimedLost2") + 1;
            PlayerPrefs.SetInt("TotalTimedLost2", totalTimedLost);
            totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost2")}";
        }

        if (gameManager.player3 == true)
        {
            totalTimedLost = PlayerPrefs.GetInt("TotalTimedLost3") + 1;
            PlayerPrefs.SetInt("TotalTimedLost3", totalTimedLost);
            totalTimedLostText.text = $"{PlayerPrefs.GetInt("TotalTimedLost3")}";
        }

    }

    public void EasyEndlessCrash()
    {
        if (gameManager.player1 == true)
        {
            easyEndlessCrash = PlayerPrefs.GetInt("EasyEndlessCrash1") + 1;
            PlayerPrefs.SetInt("EasyEndlessCrash1", easyEndlessCrash);
            easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash1")}";
        }

        if (gameManager.player2 == true)
        {
            easyEndlessCrash = PlayerPrefs.GetInt("EasyEndlessCrash2") + 1;
            PlayerPrefs.SetInt("EasyEndlessCrash2", easyEndlessCrash);
            easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash2")}";
        }

        if (gameManager.player3 == true)
        {
            easyEndlessCrash = PlayerPrefs.GetInt("EasyEndlessCrash3") + 1;
            PlayerPrefs.SetInt("EasyEndlessCrash3", easyEndlessCrash);
            easyEndlessCrashText.text = $"{PlayerPrefs.GetInt("EasyEndlessCrash3")}";
        }

    }

    public void MediumEndlessCrash()
    {
        if (gameManager.player1 == true)
        {
            mediumEndlessCrash = PlayerPrefs.GetInt("MediumEndlessCrash1") + 1;
            PlayerPrefs.SetInt("MediumEndlessCrash1", mediumEndlessCrash);
            mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash1")}";
        }

        if (gameManager.player2 == true)
        {
            mediumEndlessCrash = PlayerPrefs.GetInt("MediumEndlessCrash2") + 1;
            PlayerPrefs.SetInt("MediumEndlessCrash2", mediumEndlessCrash);
            mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash2")}";
        }

        if (gameManager.player3 == true)
        {
            mediumEndlessCrash = PlayerPrefs.GetInt("MediumEndlessCrash3") + 1;
            PlayerPrefs.SetInt("MediumEndlessCrash3", mediumEndlessCrash);
            mediumEndlessCrashText.text = $"{PlayerPrefs.GetInt("MediumEndlessCrash3")}";
        }

    }

    public void HardEndlessCrash()
    {
        if (gameManager.player1 == true)
        {
            hardEndlessCrash = PlayerPrefs.GetInt("HardEndlessCrash1") + 1;
            PlayerPrefs.SetInt("HardEndlessCrash1", hardEndlessCrash);
            hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash1")}";
        }

        if (gameManager.player2 == true)
        {
            hardEndlessCrash = PlayerPrefs.GetInt("HardEndlessCrash2") + 1;
            PlayerPrefs.SetInt("HardEndlessCrash2", hardEndlessCrash);
            hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash2")}";
        }

        if (gameManager.player3 == true)
        {
            hardEndlessCrash = PlayerPrefs.GetInt("HardEndlessCrash3") + 1;
            PlayerPrefs.SetInt("HardEndlessCrash3", hardEndlessCrash);
            hardEndlessCrashText.text = $"{PlayerPrefs.GetInt("HardEndlessCrash3")}";
        }

    }

    public void TotalEndlessCrash()
    {
        if (gameManager.player1 == true)
        {
            totalEndlessCrash = PlayerPrefs.GetInt("TotalEndlessCrash1") + 1;
            PlayerPrefs.SetInt("TotalEndlessCrash1", totalEndlessCrash);
            totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash1")}";
        }

        if (gameManager.player2 == true)
        {
            totalEndlessCrash = PlayerPrefs.GetInt("TotalEndlessCrash2") + 1;
            PlayerPrefs.SetInt("TotalEndlessCrash2", totalEndlessCrash);
            totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash2")}";
        }

        if (gameManager.player3 == true)
        {
            totalEndlessCrash = PlayerPrefs.GetInt("TotalEndlessCrash3") + 1;
            PlayerPrefs.SetInt("TotalEndlessCrash3", totalEndlessCrash);
            totalEndlessCrashText.text = $"{PlayerPrefs.GetInt("TotalEndlessCrash3")}";
        }

    }

    public void BacteriaCollected() 
    {
        if (gameManager.player1 == true)
        {
            totalRedCollected = PlayerPrefs.GetInt("TotalRedCollected1") + gameManager.redCollected;
            totalBlueCollected = PlayerPrefs.GetInt("TotalBlueCollected1") + gameManager.blueCollected;
            totalPurpleCollected = PlayerPrefs.GetInt("TotalPurpleCollected1") + gameManager.purpleCollected;
            PlayerPrefs.SetInt("TotalRedCollected1", totalRedCollected);
            PlayerPrefs.SetInt("TotalBlueCollected1", totalBlueCollected);
            PlayerPrefs.SetInt("TotalPurpleCollected1", totalPurpleCollected);
            totalRedCollectedText.text = $"{PlayerPrefs.GetInt("TotalRedCollected1")}";
            totalBlueCollectedText.text = $"{PlayerPrefs.GetInt("TotalBlueCollected1")}";
            totalPurpleCollectedText.text = $"{PlayerPrefs.GetInt("TotalPurpleCollected1")}";
        }

        if (gameManager.player2 == true)
        {
            totalRedCollected = PlayerPrefs.GetInt("TotalRedCollected2") + gameManager.redCollected;
            totalBlueCollected = PlayerPrefs.GetInt("TotalBlueCollected2") + gameManager.blueCollected;
            totalPurpleCollected = PlayerPrefs.GetInt("TotalPurpleCollected2") + gameManager.purpleCollected;
            PlayerPrefs.SetInt("TotalRedCollected2", totalRedCollected);
            PlayerPrefs.SetInt("TotalBlueCollected2", totalBlueCollected);
            PlayerPrefs.SetInt("TotalPurpleCollected2", totalPurpleCollected);
            totalRedCollectedText.text = $"{PlayerPrefs.GetInt("TotalRedCollected2")}";
            totalBlueCollectedText.text = $"{PlayerPrefs.GetInt("TotalBlueCollected2")}";
            totalPurpleCollectedText.text = $"{PlayerPrefs.GetInt("TotalPurpleCollected2")}";
        }

        if (gameManager.player3 == true)
        {
            totalRedCollected = PlayerPrefs.GetInt("TotalRedCollected3") + gameManager.redCollected;
            totalBlueCollected = PlayerPrefs.GetInt("TotalBlueCollected3") + gameManager.blueCollected;
            totalPurpleCollected = PlayerPrefs.GetInt("TotalPurpleCollected3") + gameManager.purpleCollected;
            PlayerPrefs.SetInt("TotalRedCollected3", totalRedCollected);
            PlayerPrefs.SetInt("TotalBlueCollected3", totalBlueCollected);
            PlayerPrefs.SetInt("TotalPurpleCollected3", totalPurpleCollected);
            totalRedCollectedText.text = $"{PlayerPrefs.GetInt("TotalRedCollected3")}";
            totalBlueCollectedText.text = $"{PlayerPrefs.GetInt("TotalBlueCollected3")}";
            totalPurpleCollectedText.text = $"{PlayerPrefs.GetInt("TotalPurpleCollected3")}";
        }

    }

    public void VirusEncountered() 
    {
        if (gameManager.player1 == true)
        {
            virusEncountered = PlayerPrefs.GetInt("VirusEncountered1") + gameManager.virusEncountered;
            PlayerPrefs.SetInt("VirusEncountered1", virusEncountered);
            virusEncounteredText.text = $"{PlayerPrefs.GetInt("VirusEncountered1")}";

        }

        if (gameManager.player2 == true)
        {
            virusEncountered = PlayerPrefs.GetInt("VirusEncountered2") + gameManager.virusEncountered;
            PlayerPrefs.SetInt("VirusEncountered2", virusEncountered);
            virusEncounteredText.text = $"{PlayerPrefs.GetInt("VirusEncountered2")}";

        }

        if (gameManager.player3 == true)
        {
            virusEncountered = PlayerPrefs.GetInt("VirusEncountered3") + gameManager.virusEncountered;
            PlayerPrefs.SetInt("VirusEncountered3", virusEncountered);
            virusEncounteredText.text = $"{PlayerPrefs.GetInt("VirusEncountered3")}";

        }

    }

    public void AsteroidsBlasted()
    {
        if (gameManager.player1 == true)
        {
            asteroidsBlasted = PlayerPrefs.GetInt("AsteroidsBlasted1") + gameManager.asteroidsBlasted;
            PlayerPrefs.SetInt("AsteroidsBlasted1", asteroidsBlasted);
            asteroidsBlastedText.text = $"{PlayerPrefs.GetInt("AsteroidsBlasted1")}";

        }

        if (gameManager.player2 == true)
        {
            asteroidsBlasted = PlayerPrefs.GetInt("AsteroidsBlasted2") + gameManager.asteroidsBlasted;
            PlayerPrefs.SetInt("AsteroidsBlasted2", asteroidsBlasted);
            asteroidsBlastedText.text = $"{PlayerPrefs.GetInt("AsteroidsBlasted2")}";

        }

        if (gameManager.player3 == true)
        {
            asteroidsBlasted = PlayerPrefs.GetInt("AsteroidsBlasted3") + gameManager.asteroidsBlasted;
            PlayerPrefs.SetInt("AsteroidsBlasted3", asteroidsBlasted);
            asteroidsBlastedText.text = $"{PlayerPrefs.GetInt("AsteroidsBlasted3")}";

        }

    }

    public void WeaponCollected()
    {
        if (gameManager.player1 == true)
        {
            weaponCollected = PlayerPrefs.GetInt("WeaponCollected1") + gameManager.weaponCollected;
            PlayerPrefs.SetInt("WeaponCollected1", weaponCollected);
            weaponCollectedText.text = $"{PlayerPrefs.GetInt("WeaponCollected1")}";

        }

        if (gameManager.player2 == true)
        {
            weaponCollected = PlayerPrefs.GetInt("WeaponCollected2") + gameManager.weaponCollected;
            PlayerPrefs.SetInt("WeaponCollected2", weaponCollected);
            weaponCollectedText.text = $"{PlayerPrefs.GetInt("WeaponCollected2")}";

        }

        if (gameManager.player3 == true)
        {
            weaponCollected = PlayerPrefs.GetInt("WeaponCollected3") + gameManager.weaponCollected;
            PlayerPrefs.SetInt("WeaponCollected3", weaponCollected);
            weaponCollectedText.text = $"{PlayerPrefs.GetInt("WeaponCollected3")}";

        }

    }

    public void SmallFuelCollected()
    {
        if (gameManager.player1 == true)
        {
            smallFuelCollected = PlayerPrefs.GetInt("SmallFuelCollected1") + gameManager.smallFuelCollected;
            PlayerPrefs.SetInt("SmallFuelCollected1", smallFuelCollected);
            smallFuelCollectedText.text = $"{PlayerPrefs.GetInt("SmallFuelCollected1")}";
        }

        if (gameManager.player2 == true)
        {
            smallFuelCollected = PlayerPrefs.GetInt("SmallFuelCollected2") + gameManager.smallFuelCollected;
            PlayerPrefs.SetInt("SmallFuelCollected2", smallFuelCollected);
            smallFuelCollectedText.text = $"{PlayerPrefs.GetInt("SmallFuelCollected2")}";
        }

        if (gameManager.player3 == true)
        {
            smallFuelCollected = PlayerPrefs.GetInt("SmallFuelCollected3") + gameManager.smallFuelCollected;
            PlayerPrefs.SetInt("SmallFuelCollected3", smallFuelCollected);
            smallFuelCollectedText.text = $"{PlayerPrefs.GetInt("SmallFuelCollected3")}";
        }

    }

    public void LargeFuelCollected()
    {
        if (gameManager.player1 == true)
        {
            largeFuelCollected = PlayerPrefs.GetInt("LargeFuelCollected1") + gameManager.largeFuelCollected;
            PlayerPrefs.SetInt("LargeFuelCollected1", largeFuelCollected);
            largeFuelCollectedText.text = $"{PlayerPrefs.GetInt("LargeFuelCollected1")}";
        }

        if (gameManager.player2 == true)
        {
            largeFuelCollected = PlayerPrefs.GetInt("LargeFuelCollected2") + gameManager.largeFuelCollected;
            PlayerPrefs.SetInt("LargeFuelCollected2", largeFuelCollected);
            largeFuelCollectedText.text = $"{PlayerPrefs.GetInt("LargeFuelCollected2")}";
        }

        if (gameManager.player3 == true)
        {
            largeFuelCollected = PlayerPrefs.GetInt("LargeFuelCollected3") + gameManager.largeFuelCollected;
            PlayerPrefs.SetInt("LargeFuelCollected3", largeFuelCollected);
            largeFuelCollectedText.text = $"{PlayerPrefs.GetInt("LargeFuelCollected3")}";
        }

    }

    public void AsteroidCrash()
    {
        if (gameManager.player1 == true)
        {
            asteroidCrash = PlayerPrefs.GetInt("AsteroidCrash1") + 1;
            PlayerPrefs.SetInt("AsteroidCrash1", asteroidCrash);
            asteroidCrashText.text = $"{PlayerPrefs.GetInt("AsteroidCrash1")}";
        }

        if (gameManager.player2 == true)
        {
            asteroidCrash = PlayerPrefs.GetInt("AsteroidCrash2") + 1;
            PlayerPrefs.SetInt("AsteroidCrash2", asteroidCrash);
            asteroidCrashText.text = $"{PlayerPrefs.GetInt("AsteroidCrash2")}";
        }

        if (gameManager.player3 == true)
        {
            asteroidCrash = PlayerPrefs.GetInt("AsteroidCrash3") + 1;
            PlayerPrefs.SetInt("AsteroidCrash3", asteroidCrash);
            asteroidCrashText.text = $"{PlayerPrefs.GetInt("AsteroidCrash3")}";
        }
    }

    public void GroundCrash()
    {
        if (gameManager.player1 == true)
        {
            groundCrash = PlayerPrefs.GetInt("GroundCrash1") + 1;
            PlayerPrefs.SetInt("GroundCrash1", groundCrash);
            groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash1")}";
        }

        if (gameManager.player2 == true)
        {
            groundCrash = PlayerPrefs.GetInt("GroundCrash2") + 1;
            PlayerPrefs.SetInt("GroundCrash2", groundCrash);
            groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash2")}";
        }

        if (gameManager.player3 == true)
        {
            groundCrash = PlayerPrefs.GetInt("GroundCrash3") + 1;
            PlayerPrefs.SetInt("GroundCrash3", groundCrash);
            groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash3")}";
        }
    }




    public void RunAll() 
    {
        Title();
        UpdateDisplay();
        BacteriaCollected();
        VirusEncountered();
        WeaponCollected();
        SmallFuelCollected();
        LargeFuelCollected();
        AsteroidsBlasted();

    }

    public void ClearAll()
    {
        if (gameManager.player1 == true)
        {
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
            PlayerPrefs.SetInt("TotalRedCollected1", 0);
            PlayerPrefs.SetInt("TotalBlueCollected1", 0);
            PlayerPrefs.SetInt("TotalPurpleCollected1", 0);
            PlayerPrefs.SetInt("VirusEncountered1", 0);
            PlayerPrefs.SetInt("AsteroidsBlasted1", 0);
            PlayerPrefs.SetInt("WeaponCollected1", 0);
            PlayerPrefs.SetInt("SmallFuelCollected1", 0);
            PlayerPrefs.SetInt("LargeFuelCollected1", 0);
            PlayerPrefs.SetInt("GroundCrash1", 0);
            PlayerPrefs.SetInt("AsteroidCrash1", 0);
            RunAll();

        }

        if (gameManager.player2 == true)
        {
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
            PlayerPrefs.SetInt("TotalRedCollected2", 0);
            PlayerPrefs.SetInt("TotalBlueCollected2", 0);
            PlayerPrefs.SetInt("TotalPurpleCollected2", 0);
            PlayerPrefs.SetInt("VirusEncountered2", 0);
            PlayerPrefs.SetInt("AsteroidsBlasted2", 0);
            PlayerPrefs.SetInt("WeaponCollected2", 0);
            PlayerPrefs.SetInt("SmallFuelCollected2", 0);
            PlayerPrefs.SetInt("LargeFuelCollected2", 0);
            PlayerPrefs.SetInt("GroundCrash2", 0);
            PlayerPrefs.SetInt("AsteroidCrash2", 0);
            RunAll();
        }

        if (gameManager.player3 == true)
        {
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
            PlayerPrefs.SetInt("TotalRedCollected3", 0);
            PlayerPrefs.SetInt("TotalBlueCollected3", 0);
            PlayerPrefs.SetInt("TotalPurpleCollected3", 0);
            PlayerPrefs.SetInt("VirusEncountered3", 0);
            PlayerPrefs.SetInt("AsteroidsBlasted3", 0);
            PlayerPrefs.SetInt("WeaponCollected3", 0);
            PlayerPrefs.SetInt("SmallFuelCollected3", 0);
            PlayerPrefs.SetInt("LargeFuelCollected3", 0);
            PlayerPrefs.SetInt("GroundCrash3", 0);
            PlayerPrefs.SetInt("AsteroidCrash3", 0);
            RunAll();
        }

    }

    public void UpdateDisplay()
    {
        if (gameManager.player1 == true)
        {
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
            asteroidCrashText.text = $"{PlayerPrefs.GetInt("AsteroidCrash1")}";
            groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash1")}";

        }

        if (gameManager.player2 == true)
        {
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
            asteroidCrashText.text = $"{PlayerPrefs.GetInt("AsteroidCrash2")}";
            groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash2")}";
        }

        if (gameManager.player3 == true)
        {
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
            asteroidCrashText.text = $"{PlayerPrefs.GetInt("AsteroidCrash3")}";
            groundCrashText.text = $"{PlayerPrefs.GetInt("GroundCrash3")}";
        }

    }

}


