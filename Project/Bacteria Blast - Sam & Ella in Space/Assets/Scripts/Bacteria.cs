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
    public PlayerController playerController;
    public Color colour;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

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
        // If playing an endless game, score is increased by appropriate point value and that value is passed to player controller to display in floating text

        if (other.CompareTag("Player")) 
        {

            switch (bacteriaType)
            {
                case BacteriaType.Red:
                    gameManager.redRemaining -= 1;
                    gameManager.redCollected += 1;
                    if (gameManager.gameEndless == true)
                    {
                        gameManager.AddScore(pointValue);
                        playerController.ShowFloatingText(pointValue);

                    }
                    Destroy(gameObject);
                    break;

                case BacteriaType.Purple:
                    gameManager.purpleRemaining -= 1;
                    gameManager.purpleCollected += 1;
                    if (gameManager.gameEndless == true)
                    {
                        gameManager.AddScore(pointValue);
                        playerController.ShowFloatingText(pointValue);

                    }
                    Destroy(gameObject);
                    break;

                case BacteriaType.Blue:
                    gameManager.blueRemaining -= 1;
                    gameManager.blueCollected += 1;

                    if (gameManager.gameEndless == true)
                    {
                        gameManager.AddScore(pointValue);
                        playerController.ShowFloatingText(pointValue);

                    }

                    Destroy(gameObject);
                    break;               
            }
     
        }

        // If bacteria & powerup or virus spawn together, powerup or virus is destroyed

        if (other.gameObject.CompareTag("Fuel Large") || other.gameObject.CompareTag("Fuel Small") || other.gameObject.CompareTag("Sonic Blaster PowerUp") || other.gameObject.CompareTag("Virus"))
        {
            Destroy(other.gameObject);

        }


    }
}
