using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerController playerController;
    private GameManager gameManager;
    private float leftBound = -80;
    private float rightBound = -35;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if game has started & is is not over
        if (gameManager.gameStarted == true && gameManager.gameOver == false)
        {
            // if double speed is activated, move everything at double speed
            if (playerController.doubleSpeed)

            {
                if (gameObject.CompareTag("Sonic Blaster PowerUp") || gameObject.CompareTag("Fuel Large") || gameObject.CompareTag("Fuel Small") || gameObject.CompareTag("Asteroid") || gameObject.CompareTag("Background"))
                {
                    transform.Translate(Vector3.left * Time.deltaTime * (speed * 2));

                }

                // if gameobject is bacterium or virus, it gets moved to the right instead, due to its orientation
                if (gameObject.CompareTag("Blue Bacterium") || gameObject.CompareTag("Red Bacterium") || gameObject.CompareTag("Purple Bacterium") || gameObject.CompareTag("Virus"))
                {
                    transform.Translate(Vector3.right * Time.deltaTime * (speed * 2));
                }



                // moves projectile to the right
                if (gameObject.CompareTag("Projectile"))
                {

                    transform.Translate(Vector3.right * Time.deltaTime * (speed * 4));

                }

                

            }


            // otherwise, move everything at normal speed
            if (playerController.doubleSpeed == false)
            {
                if (gameObject.CompareTag("Sonic Blaster PowerUp") || gameObject.CompareTag("Fuel Large") || gameObject.CompareTag("Fuel Small") || gameObject.CompareTag("Asteroid") || gameObject.CompareTag("Background"))
                {

                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                }

                // once again, bacteria & virus move to their right
                if (gameObject.CompareTag("Blue Bacterium") || gameObject.CompareTag("Red Bacterium") || gameObject.CompareTag("Purple Bacterium") || gameObject.CompareTag("Virus"))
                {

                    transform.Translate(Vector3.right * Time.deltaTime * (speed));


                }

                // moves projectile to the right
                if (gameObject.CompareTag("Projectile"))
                {

                    transform.Translate(Vector3.right * Time.deltaTime * (speed * 2));

                }

            }

        }

        // Destroys items when they leave left hand side of screen
        if (transform.position.x < leftBound) 
        {
            if (gameObject.CompareTag("Blue Bacterium") || gameObject.CompareTag("Red Bacterium") || gameObject.CompareTag("Purple Bacterium") || gameObject.CompareTag("Sonic Blaster PowerUp") || gameObject.CompareTag("Fuel Large") || gameObject.CompareTag("Fuel Small") || gameObject.CompareTag("Asteroid") || gameObject.CompareTag("Virus"))

            {
                Destroy(gameObject);
            }

        }

        // Destroys projectiles when they leave right hand side of screen
        if (transform.position.x > rightBound)
        {
            if (gameObject.CompareTag("Projectile"))

            {
                Destroy(gameObject);
            }

        }







    }

}
