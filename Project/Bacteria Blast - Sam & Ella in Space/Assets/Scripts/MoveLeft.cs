using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerController playerControllerScript;
    private GameManager gameManager;
    private float leftBound = -80;
    private float rightBound = -35;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if game has started & is is not over
        if (gameManager.gameStarted == true && gameManager.gameOver == false)
        {
            // if double speed is activated, move everything at double speed
            if (playerControllerScript.doubleSpeed)

            {
                transform.Translate(Vector3.left * Time.deltaTime * (speed * 2));

                if (gameObject.CompareTag("Bacterium") || gameObject.CompareTag("Virus"))
                {
                    transform.Translate(Vector3.right * Time.deltaTime * (speed * 2));
                }



                // moves projectile
                if (gameObject.CompareTag("Projectile"))
                {

                    transform.Translate(Vector3.right * Time.deltaTime * (speed * 4));

                }

            }


            // otherwise, move everything at normal speed
            if (playerControllerScript.doubleSpeed == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);

                if (gameObject.CompareTag("Bacterium") || gameObject.CompareTag("Virus"))
                {

                    transform.Translate(Vector3.right * Time.deltaTime * (speed * 2));


                }

                // moves projectile
                if (gameObject.CompareTag("Projectile"))
                {

                    transform.Translate(Vector3.right * Time.deltaTime * (speed * 2));

                }

            }

        }

        // Destroys items when they leave left hand side of screen
        if (transform.position.x < leftBound) 
        { 
            if (gameObject.CompareTag("Bacterium") || gameObject.CompareTag("Sonic Blaster PowerUp") || gameObject.CompareTag("Fuel Large") || gameObject.CompareTag("Fuel Small") || gameObject.CompareTag("Asteroid") || gameObject.CompareTag("Virus"))

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
