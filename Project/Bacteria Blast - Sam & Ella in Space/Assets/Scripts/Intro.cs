using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    // Sound
    public AudioSource introAudio;
    public AudioClip buttonSound;

    // Loading
    public GameObject loadingScreen;
    AsyncOperation loadingOperation;
    public Slider progressBar;
    public float progressValue;
    public TextMeshProUGUI loadingText;

    // Start is called before the first frame update
    void Start()
    {
        introAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadScene());
        }
    }

    public IEnumerator LoadScene()
    {
        yield return null;


        loadingScreen.gameObject.SetActive(true);  // switches on loading screen
        loadingOperation = SceneManager.LoadSceneAsync("Background Story"); // starts to load background story
        loadingOperation.allowSceneActivation = false;  // won't load scene immediately

        while (!loadingOperation.isDone) // while loading is not complete
        {

            progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f); // show progress on slider
            progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);  // calculates progress
            loadingText.text = "LOADING, PLEASE WAIT...."; //display loading text

            if (loadingOperation.progress >= 0.9f) // if loading is complete
            {
                loadingText.text = "LOADING COMPLETE"; // display success text
                new WaitForSeconds(2);  // wait for 2 seconds so player can read it
                loadingOperation.allowSceneActivation = true;  //load scene
            }

            yield return null;

        }

        Time.timeScale = 1.0f;
    }

    public void ButtonSound()
    {
        introAudio.PlayOneShot(buttonSound, 1.0f);

    }

    public void Skip()
    {

        StartCoroutine(LoadScene());
    }
}