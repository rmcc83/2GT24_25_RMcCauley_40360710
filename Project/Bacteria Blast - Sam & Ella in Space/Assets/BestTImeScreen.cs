using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestTImeScreen : MonoBehaviour
{
    public TextMeshProUGUI level1Time; // best time on level 1
    public TextMeshProUGUI level2Time; // best time on level 2
    public TextMeshProUGUI level3Time; // best time on level 3
    public TextMeshProUGUI level4Time; // best time on level 4
    public TextMeshProUGUI level5Time; // best time on level 5
    public TextMeshProUGUI level1Name; // name of player achieving best time on level 1
    public TextMeshProUGUI level2Name; // name of player achieving best time on level 2
    public TextMeshProUGUI level3Name; // name of player achieving best time on level 3
    public TextMeshProUGUI level4Name; // name of player achieving best time on level 4
    public TextMeshProUGUI level5Name; // name of player achieving best time on level 5


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

    }


    public void Level1Time() // gets the level 1 best time saved in playerprefs & displays it
    {

        level1Time.text = "" + PlayerPrefs.GetFloat("Level1BestTime");
    }

    public void Level2Time() // gets the level 2 best time saved in playerprefs & displays it
    {

        level2Time.text = "" + PlayerPrefs.GetFloat("Level2BestTime");

    }
    public void Level3Time() // gets the level 3 best time saved in playerprefs & displays it
    {

        level3Time.text = "" + PlayerPrefs.GetFloat("Level3BestTime");

    }
    public void Level4Time() // gets the level 4 best time saved in playerprefs & displays it
    {

        level4Time.text = "" + PlayerPrefs.GetFloat("Level4BestTime");

    }

    public void Level5Time() // gets the level 5 best time saved in playerprefs & displays it
    {

        level5Time.text = "" + PlayerPrefs.GetFloat("Level5BestTime");

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

    

}


