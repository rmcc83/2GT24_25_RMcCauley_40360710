using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameOptions : MonoBehaviour
{
    // Screen & panel
    public GameObject optionsScreen;
    public GameObject optionsPanel;
    public GameObject background;

    // Buttons
    public GameObject clearTimesButton;
    public GameObject clearScoresButton;
    public GameObject resetLocksButton;
    public GameObject back;

    // Confirmation prompts
    public GameObject confirmScores;
    public GameObject confirmTimes;


    public GameObject characterSelect;
    public GameObject radio;
    public GameObject playerName;
    public GameObject altControls;

    public void InGame() 
    {
        optionsPanel.SetActive(true);
        optionsScreen.gameObject.SetActive(true);
        background.gameObject.SetActive(false);
        playerName.SetActive(false);
        clearTimesButton.SetActive(false);
        clearScoresButton.SetActive(false);
        resetLocksButton.SetActive(false);
        characterSelect.SetActive(false);
        radio.SetActive(true);
        back.SetActive(false);
        confirmScores.SetActive(false);
        confirmTimes.SetActive(false);
        altControls.SetActive(false);
        AudioListener.pause = false; // re-enables the audio listener which is stopped on pause, so players can hear music they are selecting

    }

    public void InGameOff()
    {
        optionsPanel.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        playerName.SetActive(false);
        clearTimesButton.SetActive(false);
        clearScoresButton.SetActive(false);
        resetLocksButton.SetActive(false);
        characterSelect.SetActive(false);
        radio.SetActive(false);
        back.SetActive(false);
        confirmScores.SetActive(false);
        confirmTimes.SetActive(false);
        altControls.SetActive(false);
    }
}
