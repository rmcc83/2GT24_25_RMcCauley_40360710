using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public AudioSource introAudio;
    public AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        introAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If escape is pressed, skip & load main game scene
        {

            SceneManager.LoadScene("Background story");

        }
    }

    public void ButtonSound()
    {
        introAudio.PlayOneShot(buttonSound, 1.0f);

    }
}