using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderBackground : MonoBehaviour
{
    // When this part of the timeline is hit, the main game scene loads
    public void OnEnable()
    {
        SceneManager.LoadScene("Sam & Ella in Space");
        Time.timeScale = 1.0f;
    }

}

