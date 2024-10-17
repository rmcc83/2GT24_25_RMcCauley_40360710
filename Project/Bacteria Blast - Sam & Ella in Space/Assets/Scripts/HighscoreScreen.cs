using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreScreen: MonoBehaviour
{ 

    public TextMeshProUGUI easyScore;
    public TextMeshProUGUI easyRed;
    public TextMeshProUGUI easyBlue;
    public TextMeshProUGUI easyPurple;
    public TextMeshProUGUI easyName;
    public TextMeshProUGUI mediumScore;
    public TextMeshProUGUI mediumRed;
    public TextMeshProUGUI mediumBlue;
    public TextMeshProUGUI mediumPurple;
    public TextMeshProUGUI mediumName;
    public TextMeshProUGUI hardScore;
    public TextMeshProUGUI hardRed;
    public TextMeshProUGUI hardBlue;
    public TextMeshProUGUI hardPurple;
    public TextMeshProUGUI hardName;

    public void ShowScreen()
    { 
        EasyScore();
        EasyRed();
        EasyBlue();
        EasyPurple();
        EasyName();
        MediumScore();
        MediumRed();
        MediumBlue();
        MediumPurple();
        MediumName();
        HardScore();
        HardRed();
        HardBlue();
        HardPurple();
        HardName();

    }


    public void EasyScore()
    {

        easyScore.text = "" + PlayerPrefs.GetInt("EasyHighscore");

    }

    public void EasyRed()
    {

        easyRed.text = "" + PlayerPrefs.GetInt("EasyRed");

    }

    public void EasyBlue()
    {

        easyBlue.text = "" + PlayerPrefs.GetInt("EasyBlue");

    }

    public void EasyPurple()
    {

        easyPurple.text = "" + PlayerPrefs.GetInt("EasyPurple");

    }

    public void EasyName()
    {

        easyName.text = "" + PlayerPrefs.GetString("EasyPlayername", "A Biotic");

    }

    public void MediumScore()
    {

        mediumScore.text = "" + PlayerPrefs.GetInt("MediumHighscore");

    }

    public void MediumRed()
    {

        mediumRed.text = "" + PlayerPrefs.GetInt("MediumRed");

    }

    public void MediumBlue()
    {

        mediumBlue.text = "" + PlayerPrefs.GetInt("MediumBlue");

    }

    public void MediumPurple()
    {

        mediumPurple.text = "" + PlayerPrefs.GetInt("MediumPurple");

    }

    public void MediumName()
    {

        mediumName.text = "" + PlayerPrefs.GetString("MediumPlayername", "A Biotic");

    }

    public void HardScore()
    {

        hardScore.text = "" + PlayerPrefs.GetInt("HardHighscore");

    }

    public void HardRed()
    {

        hardRed.text = "" + PlayerPrefs.GetInt("HardRed");

    }

    public void HardBlue()
    {

        hardBlue.text = "" + PlayerPrefs.GetInt("HardBlue");

    }

    public void HardPurple()
    {

        hardPurple.text = "" + PlayerPrefs.GetInt("HardPurple");

    }

    public void HardName()
    {

        hardName.text = "" + PlayerPrefs.GetString("HardPlayername", "A Biotic");

    }


}




