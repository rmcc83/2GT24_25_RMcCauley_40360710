using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Epilogue : MonoBehaviour
{
    public AudioSource storyAudio;
    public AudioClip crashSound;
    public AudioClip buttonSound;
    public GameObject speedPanel;
    public GameObject loadingScreen;
    AsyncOperation loadingOperation;
    public Slider progressBar;
    public float progressValue;
    public TextMeshProUGUI loadingText;

    // Start is called before the first frame update
    void Start()
    {
        storyAudio = GetComponent<AudioSource>();
        Time.timeScale = 1.0f; //ensure timescale is normal
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


        loadingScreen.gameObject.SetActive(true); // switches on loading screen
        loadingOperation = SceneManager.LoadSceneAsync("Sam & Ella in Space"); // starts to load main game scene
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
                loadingOperation.allowSceneActivation = true;  //load scene
            }

            yield return null;

        }

        Time.timeScale = 1.0f; // ensure timescale is normal
    }

    public void ButtonSound()
    {
        storyAudio.PlayOneShot(buttonSound, 1.0f);

    }

    public void TextSlow() 
    { 
        Time.timeScale = 0.5f;  
    }

    public void TextNormal() 
    {
        Time.timeScale = 1.0f;

    }
    public void TextFast() 
    {
        Time.timeScale = 2.0f;

    }

    public void TextPanel() 
    {
      
            speedPanel.GetComponent<Animator>().SetTrigger("Pop");       
    }

    public void Skip()
    {

        StartCoroutine(LoadScene());
    }


}
