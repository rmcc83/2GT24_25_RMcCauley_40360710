using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{

    public GameObject fractured; // for the fractured parts of the asteroids
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision) 
    {
        // if asteroid spawns on the ground, it is destroyed
        if (collision.gameObject.CompareTag("Ground"))

        {
            Destroy(gameObject);
           
        }


    }

    
    public void OnTriggerEnter(Collider other) 
    {
        // if projectile collides with asteroid, projectile is destroyed and asteroid breaks up

        if (other.gameObject.CompareTag("Projectile"))
        {
            FractureObject();
            Destroy(other.gameObject);
            gameManager.asteroidsBlasted += 1;

        }


        // if the asteroid spawns too close to a fuel powerup, weapon powerup, or bacterium, the powerup or bacterium is destroyed
        if (other.gameObject.CompareTag("Fuel Large") || other.gameObject.CompareTag("Fuel Small") || other.gameObject.CompareTag("Sonic Blaster PowerUp") || other.gameObject.CompareTag("Blue Bacterium") || other.gameObject.CompareTag("Red Bacterium") || other.gameObject.CompareTag("Purple Bacterium"))
        {
            Destroy(other.gameObject);

        }

    }

    public void FractureObject()
    {
        Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version of the asteroid
        Destroy(gameObject); //Destroy the object to stop it getting in the way - fractured parts will not impact the player as their layer does not interact with player layer
    }

}
