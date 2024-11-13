using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   [SerializeField] float horsePower;
   [SerializeField] float turnSpeed = 45.0f;
   [SerializeField] GameObject centerOfMass;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the vehicle forward when keys pressed

        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

        // Turn vehicle left & right when keys pressed
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
