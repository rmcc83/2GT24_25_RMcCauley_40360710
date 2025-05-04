using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
    private GameManager gameManager;
    private string cheatCodeAmmo = "up,down,left,right,b,a";
    private string cheatCodeInvincible = "9,9,9,";
    private string cheatCodeFuel = "f,u,e,l";
    private string currentKeySequence = "";
    private PlayerController playerController;
    public GameObject cheatWarning;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStarted == true)
        {
            CheatCheck();
        }
        


    }

    public void CheatCheck() 
    {
        if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentKeySequence += "up,";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentKeySequence += "down,";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentKeySequence += "left,";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentKeySequence += "right,";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.B))
        {
            currentKeySequence += "b,";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.A))
        {
            currentKeySequence += "a";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.F))
        {
            currentKeySequence += "f,";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.U))
        {
            currentKeySequence += "u,";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.E))
        {
            currentKeySequence += "e,";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.L))
        {
            currentKeySequence += "l";
        }
        else if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.Alpha9))
        {
            currentKeySequence += "9,";
        }


        if (gameManager.cheatActive == 0 && currentKeySequence.Contains(cheatCodeAmmo))
        {
            gameManager.cheatActive = 1;
            CheatActive();
        }
        if (gameManager.cheatActive == 0 && currentKeySequence.Contains(cheatCodeInvincible))
        {
            gameManager.cheatActive = 2;
            CheatActive();
        }
        if (gameManager.cheatActive == 0 && currentKeySequence.Contains(cheatCodeFuel)) 
        {
            gameManager.cheatActive = 3;
            CheatActive();
        }

    }

    public void CheatActive() 
    {
        Debug.Log("Cheat Code Activated!");
        cheatWarning.gameObject.SetActive(true);
        gameManager.CheatOn();

    }

    public void CheatCancel()
    {
        currentKeySequence = "";
        gameManager.cheatActive = 0;
        Debug.Log("Cheat Code InActive");
        gameManager.CheatOff();
        cheatWarning.gameObject.SetActive(false);
    }


}
