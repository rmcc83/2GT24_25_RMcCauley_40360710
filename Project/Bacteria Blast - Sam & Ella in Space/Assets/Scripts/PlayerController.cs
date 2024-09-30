using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float boostForce;
    public float boostMax;
    public float topBound;
    public bool gameOver = false;
    public bool doubleSpeed = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //If game is not over
        if (!gameOver) 
        {
            // If spacebar is pressed and player is below the maximum boost height, and game is not over, an upward force is applied
            if (Input.GetKeyDown(KeyCode.Space) && (transform.position.y < boostMax))
            {
                playerRb.AddForce(Vector3.up * boostForce, ForceMode.Impulse);
            }

            // Ensures player cannot go outside the top of the screen
            if (transform.position.y > topBound)
            {
                transform.position = new Vector3(transform.position.x, topBound, transform.position.z);

            }

            // when left shift is pressed, double speed is activated
            if (Input.GetKey(KeyCode.LeftShift))
            {
                doubleSpeed = true;
               
            }

            // otherwise, double speed is not activated
            else if (doubleSpeed)
            {

                doubleSpeed = false;
                
            }

        }

       

    }
}
