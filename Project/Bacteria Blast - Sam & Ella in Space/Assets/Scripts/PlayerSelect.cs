using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerSelect : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player3Name;


    void Start()
    {
        // At start, method is run to retrieve names from player prefs & display them on the buttons
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ButtonNames();

    }

    // selecting first button  will load profile 1
    public void Button1()
    {
        PlayerPrefs.SetInt("CurrentProfile", 1);
        gameManager.player1 = true;
        gameManager.player2 = false;
        gameManager.player3 = false;


    }

    // selecting second button will load profile 2
    public void Button2()
    {
        PlayerPrefs.SetInt("CurrentProfile", 2);
        gameManager.player1 = false;
        gameManager.player2 = true;
        gameManager.player3 = false;

    }

    // selecting third button will load profile 3
    public void Button3()
    {
        PlayerPrefs.SetInt("CurrentProfile", 3);
        gameManager.player1 = false;
        gameManager.player2 = false;
        gameManager.player3 = true;

    }

    // retrieves names from player prefs and displays them on the buttons; if nothing saved in playerprefs, uses default of player 1/2/3
    public void ButtonNames()
    {
        player1Name.text = PlayerPrefs.GetString("Player1Name", "Player 1");
        player2Name.text = PlayerPrefs.GetString("Player2Name", "Player 2");
        player3Name.text = PlayerPrefs.GetString("Player3Name", "Player 3");

    }



}
