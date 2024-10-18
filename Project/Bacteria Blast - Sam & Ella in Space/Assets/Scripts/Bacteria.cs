using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Available types of bacteria

public enum BacteriaType

{ Red, Purple, Blue }


public class Bacteria : MonoBehaviour

{
    private GameManager gameManager;
    public AudioSource bacteriaAudio;
    public int pointValue;
   


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //The type of this bacterium - set in inspector for each one
    public BacteriaType bacteriaType = BacteriaType.Red;


    private void OnTriggerEnter(Collider other) 

    {
        // If player & bacteria collide, bacterium is destroyed, appropriate remaining count is decreased and appropriate collected couunt is increased.
        // If playing an endless game, score is increased by appropriate point value

        if (other.CompareTag("Player")) 
        {
            if (bacteriaType == BacteriaType.Blue)
            {
                gameManager.blueRemaining -= 1;
                gameManager.blueCollected += 1;

                if (gameManager.gameEndless == true) 
                {
                    gameManager.AddScore(pointValue);

                }
                
                Destroy(gameObject);
            }

            if (bacteriaType == BacteriaType.Purple)
            {
                gameManager.purpleRemaining -= 1;
                gameManager.purpleCollected += 1;
                if (gameManager.gameEndless == true)
                {
                    gameManager.AddScore(pointValue);

                }
                Destroy(gameObject);
            }

            if (bacteriaType == BacteriaType.Red)
            {
                gameManager.redRemaining -= 1;
                gameManager.redCollected += 1;
                if (gameManager.gameEndless == true)
                {
                    gameManager.AddScore(pointValue);

                }
                Destroy(gameObject);
            }

        }

        // If bacteria & powerup or virus spawn together, powerup or virus is destroyed

        if (other.gameObject.CompareTag("Fuel Large") || other.gameObject.CompareTag("Fuel Small") || other.gameObject.CompareTag("Sonic Blaster PowerUp") || other.gameObject.CompareTag("Virus"))
        {
            Destroy(other.gameObject);


        }



    }
}
