using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject levelPanel; // pop up panel for levels 1-5
    public GameObject endlessPanel; // pop up panel for endless levels
    public GameObject recordsPanel; // pop up panel for records


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
    // Method to trigger the pop-up animation for the records button
    public void Records() 
    {

        recordsPanel.GetComponent<Animator>().SetTrigger("Pop");


    }
}