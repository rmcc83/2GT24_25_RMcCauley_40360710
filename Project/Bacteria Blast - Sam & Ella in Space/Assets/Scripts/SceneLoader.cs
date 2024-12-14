using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    //Loading bar
    public GameObject loadingScreen;
    AsyncOperation loadingOperation;
    public Slider progressBar;
    public float progressValue;
    public TextMeshProUGUI loadingText;

    // When this part of the timeline is hit, the main game scene loads
    public void OnEnable()
    {
        StartCoroutine(LoadScene());
        Time.timeScale = 1.0f; // ensure timescale is normal
    }

    public IEnumerator LoadScene()
    {
        yield return null;


        loadingScreen.gameObject.SetActive(true); // switches on loading screen
        loadingOperation = SceneManager.LoadSceneAsync("Background"); // starts to load background story
        loadingOperation.allowSceneActivation = false; // won't load scene immediately

        while (!loadingOperation.isDone) // while loading is not complete
        {

            progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f); // show progress on slider
            progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f); // calculates progress
            loadingText.text = "LOADING, PLEASE WAIT...."; //display loading text

            if (loadingOperation.progress >= 0.9f) // if loading is complete
            {
                loadingText.text = "LOADING COMPLETE"; // display success text
                new WaitForSeconds(2); // wait for 2 seconds so player can read it
                loadingOperation.allowSceneActivation = true; //load scene
            }

            yield return null;

        }

        Time.timeScale = 1.0f; // ensure timescale is normal
    }

}

