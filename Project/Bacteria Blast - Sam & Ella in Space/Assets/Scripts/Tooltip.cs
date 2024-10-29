using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private GameManager gameManager;
    public string message;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnMouseEnter() // Shows tooltip when mouse enters area

    {
        if (gameManager.gameStarted == true)
        {
            TooltipManager.instance.SetAndShowTooltip(message);
        }

    }

    private void OnMouseExit()
    {
        TooltipManager.instance.HideTooltip(); // Hides tooltip when mouse exits area
    }

    private void Update()
    {
        if (gameManager.gameOver == true) // Hides tooltip on game over

        {
            TooltipManager.instance.HideTooltip();

        }
    }
}
