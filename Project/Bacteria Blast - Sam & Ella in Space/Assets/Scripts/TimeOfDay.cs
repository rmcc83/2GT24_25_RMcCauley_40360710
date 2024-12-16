using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeOfDay : MonoBehaviour
{
    public int sysHour;
    public TextMeshProUGUI greeting;
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        CheckTime(); // run the checktime method when the script loads, i.e. when the screen is displayed
     
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTime();
    }

    public void CheckTime() 
    {
        sysHour = System.DateTime.Now.Hour; //gets the hour from the current system time

        if (sysHour >= 0 && sysHour < 12) // if hour is between 0 & 11
        {
            greeting.text = "Good Morning, " + gameManager.playerName.text + "!"; // display good morning along with currently loaded player name

        }


        if (sysHour >= 12 && sysHour < 18) // if hour is between 12 & 17
        {
            greeting.text = "Good Afternoon, " + gameManager.playerName.text + "!"; // display good afternoon along with currently loaded player name

        }


        if (sysHour >= 18 && sysHour < 24) // if hour is between 18 & 23
        {
            greeting.text = "Good evening, " + gameManager.playerName.text + "!"; // display good evening along with currently loaded player name

        }
          

    }
}
