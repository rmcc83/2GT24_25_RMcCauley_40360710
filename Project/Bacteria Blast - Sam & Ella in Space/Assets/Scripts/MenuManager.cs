using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject levelPanel; // pop up panel for levels 1-5
    public GameObject endlessPanel; // pop up panel for endless levels


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to trigger the pop-up animation for the level select button
    public void LevelSelect()
    {
        levelPanel.GetComponent<Animator>().SetTrigger("Pop");
        endlessPanel.GetComponent<Animator>().SetTrigger("Pop");

    }
}