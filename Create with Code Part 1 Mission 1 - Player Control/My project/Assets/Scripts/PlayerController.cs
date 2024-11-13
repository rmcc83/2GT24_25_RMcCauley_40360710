using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float horsePower;
    [SerializeField] float turnSpeed;
    [SerializeField] float speed;
    [SerializeField] float rpm;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
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

    private void Update()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
    }
}
