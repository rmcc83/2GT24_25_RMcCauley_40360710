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
                gameManager.currentProfile = 1;
                gameManager.Load();
                break;
            case 2:
                PlayerPrefs.SetInt("CurrentProfile", 2);
                gameManager.currentProfile = 2;
                gameManager.Load();
                break;
            case 3: 
                PlayerPrefs.SetInt("CurrentProfile", 3);
                gameManager.currentProfile = 3;
                gameManager.Load();
                break;
        }
       
    }


}
