using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Asteroid : MonoBehaviour
{

    public GameObject fractured;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates asteroid slowly
      // transform.Rotate(10 * Time.deltaTime, 0, 0, Space.Self);
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

        }


        // if the asteroid spawns near a powerup or bacterium, the powerup or bacterium is destroyed
        if (other.gameObject.CompareTag("Fuel Large") || other.gameObject.CompareTag("Fuel Small") || other.gameObject.CompareTag("Sonic Blaster PowerUp") || other.gameObject.CompareTag("Bacterium"))
        {
            Destroy(other.gameObject);

        }

    }

    public void FractureObject()
    {
        Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        Destroy(gameObject); //Destroy the object to stop it getting in the way
    }

}
