using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerSelect : MonoBehaviour
{
    public GameManager gameManager;
    private Button button;
    public int profile;

    void Start()
    {
        // At start, method is run to retrieve names from player prefs & display them on the buttons
        button = GetComponent<Button>();
        button.onClick.AddListener(SetProfile);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    public void SetProfile() // loads player profile info depending on what button was selected
    {
        switch (profile) 
        {
            case 1:
                PlayerPrefs.SetInt("CurrentProfile", 1);
                gameManager.profileNumber = 1;
                break;
            case 2:
                PlayerPrefs.SetInt("CurrentProfile", 3);
                gameManager.profileNumber = 2;
                break;
            case 3: 
                PlayerPrefs.SetInt("CurrentProfile", 3);
                gameManager.profileNumber = 3;
                break;
        }
        gameManager.Load();

    }


}
