using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroShip : MonoBehaviour
{
    public AudioSource storyAudio;
    public AudioClip buttonSound;
    public GameObject speedPanel;

    // Start is called before the first frame update
    void Start()
    {
        storyAudio = GetComponent<AudioSource>();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Sam & Ella in Space");
            Time.timeScale = 1.0f;
        }
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


}
