using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float horsePower;
    [SerializeField] float turnSpeed;
    [SerializeField] float speed;
    [SerializeField] float rpm;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get input from player

        forwardInput = Input.GetAxis("Vertical");       
        horizontalInput = Input.GetAxis("Horizontal");


        
        if (IsOnGround()) 
        {
            //Move vehicle forward
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

            // Turn vehicle 
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            //print speed
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + "mph");

            //print rpm
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }

        
    }

    bool IsOnGround() 
    
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels) 
        {
            if (wheel.isGrounded) 
            {
                wheelsOnGround++;
            
            }
        
        
        }

        if (wheelsOnGround == 4)
        {
            return true;

        }
        else 
        {
            return false;
        }
    
    
    }

    
}
