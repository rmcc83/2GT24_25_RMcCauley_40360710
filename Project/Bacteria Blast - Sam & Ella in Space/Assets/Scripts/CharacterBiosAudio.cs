using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBiosAudio : MonoBehaviour
{
    public AudioSource characterAudioSource;
    public AudioSource musicAudioSource1;
    public AudioSource musicAudioSource2;
    public AudioSource musicAudioSource3;
    public AudioSource musicAudioSource4;
    public Button samButton;
    public Button ellaButton;
    public Button redButton;
    public Button blueButton;
    public Button purpleButton;
    public Button virusButton;
    public Button fuelButton;
    public Button weaponButton;
    public Button repairButton;
    public Button asteroidButton;
    public Button spaceshipButton;
    public Button escapePod;


    // Start is called before the first frame update
    void Start()
    {
        MusicAndButton();
    }

    // Update is called once per frame
    void Update()
    {
        MusicAndButton();

    }

    public void MusicAndButton() 
    {
        if (characterAudioSource.isPlaying)
        {
            musicAudioSource1.Pause();
            musicAudioSource2.Pause();
            musicAudioSource3.Pause();
            musicAudioSource4.Pause();
            samButton.interactable = false;
            ellaButton.interactable = false;
            redButton.interactable = false;
            blueButton.interactable = false;
            purpleButton.interactable = false;
            virusButton.interactable = false;
            fuelButton.interactable = false;
            weaponButton.interactable = false;
            repairButton.interactable = false;
            asteroidButton.interactable = false;
            spaceshipButton.interactable = false;
            escapePod.interactable = false;

        }

        if (!characterAudioSource.isPlaying)
        {
            musicAudioSource1.UnPause();
            musicAudioSource2.UnPause();
            musicAudioSource3.UnPause();
            musicAudioSource4.UnPause();
            samButton.interactable = true;
            ellaButton.interactable = true;
            redButton.interactable = true;
            blueButton.interactable = true;
            purpleButton.interactable = true;
            virusButton.interactable = true;
            fuelButton.interactable = true;
            weaponButton.interactable = true;
            repairButton.interactable = true;
            asteroidButton.interactable = true;
            spaceshipButton.interactable = true;
            escapePod.interactable = true;

        }

    }

}
