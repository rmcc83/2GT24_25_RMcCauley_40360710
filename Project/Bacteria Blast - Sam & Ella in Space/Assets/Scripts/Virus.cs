using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{

    private GameManager gameManager;
  
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)

    {
        // If virus hits player, virus is destroyed & player loses a life.  

        if (other.CompareTag("Player"))
        {
            gameManager.AddLives(-1);
            gameManager.virusEncountered += 1;
            Destroy(gameObject);
        }

    }
}
