using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

    public void LoadDrivingScene() 
    {

        SceneManager.LoadScene("Driving");


    }

    public void LoadPlaneGame()
    {

        SceneManager.LoadScene("Plane");

    }
}
