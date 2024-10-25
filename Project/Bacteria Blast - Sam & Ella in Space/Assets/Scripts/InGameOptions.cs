using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameOptions : MonoBehaviour
{
    public GameObject optionsScreen;
    public GameObject optionsPanel;
    public GameObject background;
    public GameObject playerName;
    public GameObject clearTimesButton;
    public GameObject clearScoresButton;
    public GameObject characterSelect;
    public GameObject radio;
    public GameObject back;
    public GameObject confirmScores;
    public GameObject confirmTimes;

    public void InGame() 
    {
        optionsPanel.SetActive(true);
        optionsScreen.gameObject.SetActive(true);
        background.gameObject.SetActive(false);
        playerName.SetActive(false);
        clearTimesButton.SetActive(false);
        clearScoresButton.SetActive(false);
        characterSelect.SetActive(true);
        radio.SetActive(true);
        back.SetActive(false);
        confirmScores.SetActive(false);
        confirmTimes.SetActive(false);
        AudioListener.pause = false;

    }

    public void InGameOff()
    {
        optionsPanel.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        playerName.SetActive(false);
        clearTimesButton.SetActive(false);
        clearScoresButton.SetActive(false);
        characterSelect.SetActive(false);
        radio.SetActive(false);
        back.SetActive(false);
        confirmScores.SetActive(false);
        confirmTimes.SetActive(false);

    }
}
