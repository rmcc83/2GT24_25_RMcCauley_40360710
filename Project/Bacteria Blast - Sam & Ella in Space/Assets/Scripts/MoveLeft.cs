using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerController playerControllerScript;
    private float leftBound = -70;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if game is not over
        if (playerControllerScript.gameOver == false)
        {
            // if double speed is activated, move everything at double speed
            if (playerControllerScript.doubleSpeed)

            {
                transform.Translate(Vector3.left * Time.deltaTime * (speed * 2));
            }

            // otherwise, move everything at normal speed
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            }

        }

        if (transform.position.x < leftBound) 
        { 
            if (gameObject.CompareTag("Bacterium") || gameObject.CompareTag("PowerUp") || gameObject.CompareTag("Asteroid") || gameObject.CompareTag("Virus"))

            {
                Destroy(gameObject);
            }

        }
         
    }

}
