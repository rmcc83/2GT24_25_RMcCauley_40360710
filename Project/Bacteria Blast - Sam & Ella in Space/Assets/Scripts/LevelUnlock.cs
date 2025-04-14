using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    private GameManager gameManager;
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        CheckLevelUnlockState();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnLockLevel()
    {
        switch (gameManager.currentLevel)
        {
            case 1:                 // if current level is level 1
                switch (gameManager.profileNumber)
                {
                    case 1:         //player profile 1
                        PlayerPrefs.SetInt("Timed1", 2);    // set Timed 1 in player prefs to be 2
                        break;
                    case 2:          //player profile 2
                        PlayerPrefs.SetInt("Timed2", 2);    // set Timed 2 in player prefs to be 2
                        break;
                    case 3:          //player profile 3
                        PlayerPrefs.SetInt("Timed3", 2);    // set Timed 3 in player prefs to be 2
                        break;
                }
                break;
            case 2:                 // if current level is level 2
                switch (gameManager.profileNumber)
                {
                    case 1:         //player profile 1
                        PlayerPrefs.SetInt("Timed1", 3);    // set Timed 1 in player prefs to be 3
                        break;
                    case 2:         //player profile 2
                        PlayerPrefs.SetInt("Timed2", 3);    // set Timed 2 in player prefs to be 3
                        break;
                    case 3:         //player profile 3
                        PlayerPrefs.SetInt("Timed3", 3);    // set Timed 3 in player prefs to be 3
                        break;
                }
                break;
            case 3:                 // if current level is level 3
                switch (gameManager.profileNumber)
                {
                    case 1:         //player profile 1
                        PlayerPrefs.SetInt("Timed1", 4);    // set Timed 1 in player prefs to be 4
                        break;
                    case 2:         //player profile 2
                        PlayerPrefs.SetInt("Timed2", 4);    // set Timed 2 in player prefs to be 4
                        break;
                    case 3:         //player profile 3
                        PlayerPrefs.SetInt("Timed3", 4);    // set Timed 3 in player prefs to be 4
                        break;
                }
                break;
            case 4:                 // if current level is level 4
                switch (gameManager.profileNumber)
                {
                    case 1:         //player profile 1
                        PlayerPrefs.SetInt("Timed1", 5);    // set Timed 1 in player prefs to be 5
                        break;
                    case 2:         //player profile 2
                        PlayerPrefs.SetInt("Timed2", 5);    // set Timed 2 in player prefs to be 5
                        break;
                    case 3:         //player profile 3
                        PlayerPrefs.SetInt("Timed3", 5);    // set Timed 3 in player prefs to be 5
                        break;
                }
                break;
            case 5:                 // if current level is level 5
                switch (gameManager.profileNumber)
                {
                    case 1:         //player profile 1
                        PlayerPrefs.SetInt("Timed1", 5);    // set Timed 1 in player prefs to be 5
                        break;
                    case 2:         //player profile 2
                        PlayerPrefs.SetInt("Timed2", 5);    // set Timed 2 in player prefs to be 5
                        break;
                    case 3:         //player profile 3
                        PlayerPrefs.SetInt("Timed3", 5);    // set Timed 3 in player prefs to be 5
                        break;
                }
                break;
        }
        PlayerPrefs.Save();
    }

    public void CheckLevelUnlockState()
    {
        switch (gameManager.profileNumber)
        {
            case 1:                 // if current profile is 1
                switch (PlayerPrefs.GetInt("Timed1"))
                {
                    case 1:         //if Timed 1 = 1
                        level1Button.interactable = true;
                        level2Button.interactable = false;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 2:          //if Timed 1 = 2
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 3:          //if Timed 1 = 3
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 4:         //if Timed 1 = 4
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = true;
                        level5Button.interactable = false;
                        break;
                    case 5:         //if Timed 1 = 5
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = true;
                        level5Button.interactable = true;
                        break;
                    default:        // if Timed 1 does not exist
                        level1Button.interactable = true;
                        level2Button.interactable = false;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                }
                break;
            case 2:                 // if current profile is 2
                switch (PlayerPrefs.GetInt("Timed2"))
                {
                    case 1:         //if Timed 2 = 1
                        level1Button.interactable = true;
                        level2Button.interactable = false;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 2:          //if Timed 2 = 2
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 3:          //if Timed 2 = 3
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 4:         //if Timed 2 = 4
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = true;
                        level5Button.interactable = false;
                        break;
                    case 5:         //if Timed 2 = 5
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = true;
                        level5Button.interactable = true;
                        break;
                    default:        // if Timed 2 does not exist
                        level1Button.interactable = true;
                        level2Button.interactable = false;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                }
                break;
            case 3:                 // if current profile is 3
                switch (PlayerPrefs.GetInt("Timed3"))
                {
                    case 1:         //if Timed 3 = 1
                        level1Button.interactable = true;
                        level2Button.interactable = false;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 2:          //if Timed 3 = 2
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 3:          //if Timed 3 = 3
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                    case 4:         //if Timed 3 = 4
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = true;
                        level5Button.interactable = false;
                        break;
                    case 5:         //if Timed 3 = 5
                        level1Button.interactable = true;
                        level2Button.interactable = true;
                        level3Button.interactable = true;
                        level4Button.interactable = true;
                        level5Button.interactable = true;
                        break;
                    default:        // if Timed 3 does not exist
                        level1Button.interactable = true;
                        level2Button.interactable = false;
                        level3Button.interactable = false;
                        level4Button.interactable = false;
                        level5Button.interactable = false;
                        break;
                }
                break;
                
        }

    }

    public void ResetLevels()
    {
        switch (gameManager.profileNumber)
        {
            case 1:     //if current profile is 1
                PlayerPrefs.SetInt("Timed1", 1);
                break;
            case 2:     //if current profile is 2
                PlayerPrefs.SetInt("Timed2", 1);
                break;
            case 3:     //if current profile is 3
                PlayerPrefs.SetInt("Timed3", 1);
                break;
        }
        PlayerPrefs.Save();
    }

        
}
