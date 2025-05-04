using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject touchControls;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager.gameStarted == true)
        { 
            touchControls.SetActive(true);
        
        }

        else touchControls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStarted == true)
        {
            touchControls.SetActive(true);

        }

        else touchControls.SetActive(false);

    }
}
