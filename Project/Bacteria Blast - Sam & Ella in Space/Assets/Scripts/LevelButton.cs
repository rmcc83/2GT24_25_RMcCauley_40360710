using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int level;


    // Start is called before the first frame update
    void Start()
    {

        button = GetComponent<Button>();
        button.onClick.AddListener(SetLevel); // When button is clicked, it communicates the programmed level
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Once level is selected, game manager start game routine begins
    void SetLevel()
    {
        // if level is 1-5, the StartGame method in Gamemanager is called and the level number programmed in to the button is sent to it
        if (level == 1 || level == 2 || level == 3 || level == 4 || level == 5) 
        {
            gameManager.StartGame(level);
        }

        // if level is 99/98/97, the StartGameEndless method in GameManager is called and the level number programmed in to the button is sent to it
        else if (level == 99 | level == 98 | level == 97)
       {
            gameManager.StartGameEndless(level);

       }

    }

}


