using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject levelPanel; // pop up panel for levels 1-5
    public GameObject endlessPanel; // pop up panel for endless levels
    public GameObject recordsPanel; // pop up panel for records
    public GameObject helpPanel; // pop up panel for help
    public GameObject helpButton; // Button which displays help screen
    public GameObject highscoreButton; // Button which displays highscore screen
    public GameObject level1Button; // Button which starts level 1


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

    // Method to trigger pop-up animation for the help button
    public void Help()
    {

        helpPanel.GetComponent<Animator>().SetTrigger("Pop");


    }

    // Method used to check if the help button is active in the scene.  This is called when another
    // button (eg records) is pressed - it essentially checks if the help panel is open, and if it is, it closes it
    public void CheckHelpPanel() 
    {
        if (helpButton.activeInHierarchy == true)
        {
            helpPanel.GetComponent<Animator>().SetTrigger("Pop");

        }
    
    
    }
    // Method used to check if the highscores button is active in the scene.  This is called when another
    // button (eg help) is pressed - it essentially checks if the records panel is open, and if it is, it closes it
    public void CheckRecordsPanel()
    {
        if (highscoreButton.activeInHierarchy == true)
        {
            recordsPanel.GetComponent<Animator>().SetTrigger("Pop");

        }


    }
    // Method used to check if the level 1 button is active in the scene.  This is called when another
    // button (eg help) is pressed - it essentially checks if the level panel is open, and if it is, it closes it
    public void CheckLevelPanel()
    {
        if (level1Button.activeInHierarchy == true)
        {
            levelPanel.GetComponent<Animator>().SetTrigger("Pop");
            endlessPanel.GetComponent<Animator>().SetTrigger("Pop");
        }


    }



}