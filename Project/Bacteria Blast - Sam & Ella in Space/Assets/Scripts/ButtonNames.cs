using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonNames : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    public TextMeshProUGUI player3Name;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Buttons();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Buttons() // shows saved player name on appropriate button
    {
       
        player1Name.text = PlayerPrefs.GetString("Player1Name", "Player 1");
        player2Name.text = PlayerPrefs.GetString("Player2Name", "Player 2");
        player3Name.text = PlayerPrefs.GetString("Player3Name", "Player 3");
    }
}
