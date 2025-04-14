using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestTImeScreen : MonoBehaviour
{
    public TextMeshProUGUI timeLevel1Text; // best time on level 1
    public TextMeshProUGUI timeLevel2Text; // best time on level 2
    public TextMeshProUGUI timeLevel3Text; // best time on level 3
    public TextMeshProUGUI timeLevel4Text; // best time on level 4
    public TextMeshProUGUI timeLevel5Text; // best time on level 5
    public TextMeshProUGUI level1Name; // name of player achieving best time on level 1
    public TextMeshProUGUI level2Name; // name of player achieving best time on level 2
    public TextMeshProUGUI level3Name; // name of player achieving best time on level 3
    public TextMeshProUGUI level4Name; // name of player achieving best time on level 4
    public TextMeshProUGUI level5Name; // name of player achieving best time on level 5
    public TextMeshProUGUI level1Control; // control scheme used to achieve best time on level 1
    public TextMeshProUGUI level2Control; // control scheme used to achieve best time on level 2
    public TextMeshProUGUI level3Control; // control scheme used to achieve best time on level 3
    public TextMeshProUGUI level4Control; // control scheme used to achieve best time on level 4
    public TextMeshProUGUI level5Control; // control scheme used to achieve best time on level 5

    public void ShowScreen() // runs everything when screen is displayed
    {
        Level1Time();
        Level2Time();
        Level3Time();
        Level4Time();
        Level5Time();
        Level1Name();
        Level2Name();
        Level3Name();
        Level4Name();
        Level5Name();
        Level1Control();
        Level2Control();
        Level3Control();
        Level4Control();
        Level5Control();

    }


    public void Level1Time() // gets the level 1 best time saved in playerprefs & displays it
    {
        double level1Time = PlayerPrefs.GetFloat("Level1BestTime");
        var timeSpan = TimeSpan.FromSeconds(level1Time);
        timeLevel1Text.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
    }

    public void Level2Time() // gets the level 2 best time saved in playerprefs & displays it
    {

        double level2Time = PlayerPrefs.GetFloat("Level2BestTime");
        var timeSpan = TimeSpan.FromSeconds(level2Time);
        timeLevel2Text.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);

    }
    public void Level3Time() // gets the level 3 best time saved in playerprefs & displays it
    {

        double level3Time = PlayerPrefs.GetFloat("Level3BestTime");
        var timeSpan = TimeSpan.FromSeconds(level3Time);
        timeLevel3Text.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);

    }
    public void Level4Time() // gets the level 4 best time saved in playerprefs & displays it
    {

        double level4Time = PlayerPrefs.GetFloat("Level4BestTime");
        var timeSpan = TimeSpan.FromSeconds(level4Time);
        timeLevel4Text.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);

    }

    public void Level5Time() // gets the level 5 best time saved in playerprefs & displays it
    {

        double level5Time = PlayerPrefs.GetFloat("Level5BestTime");
        var timeSpan = TimeSpan.FromSeconds(level5Time);
        timeLevel5Text.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);

    }

    public void Level1Name() //gets the name of the player who achieved the best time in level 1 & displays it
    {

        level1Name.text = "" + PlayerPrefs.GetString("Level1Playername");

    }

    public void Level2Name() //gets the name of the player who achieved the best time in level 2 & displays it
    {

        level2Name.text = "" + PlayerPrefs.GetString("Level2Playername");

    }

    public void Level3Name() //gets the name of the player who achieved the best time in level 3 & displays it
    {

        level3Name.text = "" + PlayerPrefs.GetString("Level3Playername");

    }

    public void Level4Name() //gets the name of the player who achieved the best time in level 4 & displays it
    {

        level4Name.text = "" + PlayerPrefs.GetString("Level4Playername");

    }

    public void Level5Name() //gets the name of the player who achieved the best time in level 5 & displays it
    {

        level5Name.text = "" + PlayerPrefs.GetString("Level5Playername");

    }

    public void Level1Control() //gets the control scheme used to achieve the best time in level 1 & displays it
    {

        level1Control.text = "" + PlayerPrefs.GetString("Level1Control");

    }

    public void Level2Control() //gets the control scheme used to achieve the best time in level 2 & displays it
    {

        level2Control.text = "" + PlayerPrefs.GetString("Level2Control");

    }

    public void Level3Control() //gets the control scheme used to achieve the best time in level 3 & displays it
    {

        level3Control.text = "" + PlayerPrefs.GetString("Level3Control");

    }

    public void Level4Control() //gets the control scheme used to achieve the best time in level 4 & displays it
    {

        level4Control.text = "" + PlayerPrefs.GetString("Level4Control");

    }

    public void Level5Control() //gets the control scheme used to achieve the best time in level 5 & displays it
    {

        level5Control.text = "" + PlayerPrefs.GetString("Level5Control");

    }



}


