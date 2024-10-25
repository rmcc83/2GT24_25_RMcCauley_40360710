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
    private void OnMouseEnter()

    {
        if (gameManager.gameStarted == true)
        {
            TooltipManager.instance.SetAndShowTooltip(message);
        }

    }

    private void OnMouseExit()
    {
        TooltipManager.instance.HideTooltip();
    }

    private void Update()
    {
        if (gameManager.gameOver == true)

        {
            TooltipManager.instance.HideTooltip();

        }
    }
}
