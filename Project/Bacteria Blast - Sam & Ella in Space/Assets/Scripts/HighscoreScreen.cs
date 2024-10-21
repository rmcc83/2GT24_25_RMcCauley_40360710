using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreScreen: MonoBehaviour
{ 

    public TextMeshProUGUI easyScore; // highscore on easy level
    public TextMeshProUGUI easyRed; // red collected on highscoring run of easy level
    public TextMeshProUGUI easyBlue; // blue collected on highscoring run of easy level
    public TextMeshProUGUI easyPurple; // purple collected on highscoring run on easy level
    public TextMeshProUGUI easyName; // player who acheived easy highscore
    public TextMeshProUGUI easyTime; // time in which easy highscore was achieved
    public TextMeshProUGUI mediumScore; // highscore on easy level
    public TextMeshProUGUI mediumRed; // red collected on highscoring run of medium level
    public TextMeshProUGUI mediumBlue; // blue collected on highscoring run of medium level
    public TextMeshProUGUI mediumPurple; // purple collected on highscoring run on medium level
    public TextMeshProUGUI mediumName; // player who acheived medium highscore
    public TextMeshProUGUI mediumTime; // time in which medium highscore was achieved
    public TextMeshProUGUI hardScore; // highscore on hard level
    public TextMeshProUGUI hardRed; // red collected on highscoring run of hard level
    public TextMeshProUGUI hardBlue; // blue collected on highscoring run of hard level
    public TextMeshProUGUI hardPurple; // purple collected on highscoring run on hard level
    public TextMeshProUGUI hardName; // player who acheived hard highscore
    public TextMeshProUGUI hardTime; // time in which hard highscore was achieved

    public void ShowScreen() // runs everything when screen is displayed
    { 
        EasyScore();
        EasyRed();
        EasyBlue();
        EasyPurple();
        EasyName();
        EasyTime();
        MediumScore();
        MediumRed();
        MediumBlue();
        MediumPurple();
        MediumName();
        MediumTime();
        HardScore();
        HardRed();
        HardBlue();
        HardPurple();
        HardName();
        HardTime();

    }


    public void EasyScore() // gets the easy highscore saved in playerprefs & displays it
    {

        easyScore.text = "" + PlayerPrefs.GetInt("EasyHighscore");

    }

    public void EasyRed() //gets the red collected on easy run saved in playerprefs & displays it
    {

        easyRed.text = "" + PlayerPrefs.GetInt("EasyRed");

    }

    public void EasyBlue() //gets the blue collected on easy run saved in playerprefs & displays it
    {

        easyBlue.text = "" + PlayerPrefs.GetInt("EasyBlue");

    }

    public void EasyPurple() //gets the purple collected on easy run saved in playerprefs & displays it
    {

        easyPurple.text = "" + PlayerPrefs.GetInt("EasyPurple");

    }

    public void EasyName() //gets the player name saved for easy run & displays it - default name is A Biotic
    {

        easyName.text = "" + PlayerPrefs.GetString("EasyPlayername", "A Biotic");

    }

    public void EasyTime() //gets the time saved for easy run & displays it
    {

        easyTime.text = "" + PlayerPrefs.GetString("EasyTime");

    }

    public void MediumScore() // gets the medium highscore saved in playerprefs & displays it
    {

        mediumScore.text = "" + PlayerPrefs.GetInt("MediumHighscore");

    }

    public void MediumRed() //gets the red collected on medium run saved in playerprefs & displays it
    {

        mediumRed.text = "" + PlayerPrefs.GetInt("MediumRed");

    }

    public void MediumBlue() //gets the blue collected on medium run saved in playerprefs & displays it
    {

        mediumBlue.text = "" + PlayerPrefs.GetInt("MediumBlue");

    }

    public void MediumPurple() //gets the purple collected on medium run saved in playerprefs & displays it
    {

        mediumPurple.text = "" + PlayerPrefs.GetInt("MediumPurple");

    }

    public void MediumName() //gets the player name saved for medium run & displays it - default name is A Biotic
    {

        mediumName.text = "" + PlayerPrefs.GetString("MediumPlayername", "A Biotic");

    }

    public void MediumTime() //gets the time saved for medium run & displays it
    {

        mediumTime.text = "" + PlayerPrefs.GetString("MediumTime");

    }

    public void HardScore() // gets the hard highscore saved in playerprefs & displays it
    {

        hardScore.text = "" + PlayerPrefs.GetInt("HardHighscore");

    }

    public void HardRed() //gets the red collected on hard run saved in playerprefs & displays it
    {

        hardRed.text = "" + PlayerPrefs.GetInt("HardRed");

    }

    public void HardBlue() //gets the blue collected on hard run saved in playerprefs & displays it
    {

        hardBlue.text = "" + PlayerPrefs.GetInt("HardBlue");

    }

    public void HardPurple() //gets the purple collected on hard run saved in playerprefs & displays it
    {

        hardPurple.text = "" + PlayerPrefs.GetInt("HardPurple");

    }

    public void HardName() //gets the player name saved for hard run & displays it - default name is A Biotic
    {

        hardName.text = "" + PlayerPrefs.GetString("HardPlayername", "A Biotic");

    }

    public void HardTime() //gets the time saved for hard run & displays it
    {

        hardTime.text = "" + PlayerPrefs.GetString("HardTime");

    }


}




