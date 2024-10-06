using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    // Start is called before the first frame update

    private GameManager gameManager;
    public PlayerController playerController;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)

    {
        // If virus hits player, player loses a life.  

        if (other.CompareTag("Player"))
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }


    }
}
