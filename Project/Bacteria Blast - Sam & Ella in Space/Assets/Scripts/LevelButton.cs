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
        button.onClick.AddListener(SetLevel);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Once level is selected, game manager start game routine begins
    void SetLevel()
    {

        gameManager.StartGame(level);

    }

    public void NextLevel() 
    { 
        gameManager.StartGame(level + 1);
    
    
    }
}

