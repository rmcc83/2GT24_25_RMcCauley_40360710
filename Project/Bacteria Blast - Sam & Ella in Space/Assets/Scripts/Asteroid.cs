using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AsteroidType
{ Small, Medium, Large }

public class Asteroid : MonoBehaviour
{
    //Audio
    private AudioSource playerAudio;
    public AudioClip bumpSound;


    public GameObject fractured; // for the fractured parts of the asteroids
    public GameObject repair; // spaceship repair kit
    private GameManager gameManager;
    public int damageAmount;
    


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AsteroidType asteroidType = AsteroidType.Small;

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
        // if projectile collides with asteroid, projectile is destroyed and asteroid breaks up, and repair spawn co-routine runs

        if (other.gameObject.CompareTag("Projectile"))
        {
            FractureObject();
            Destroy(other.gameObject);
            gameManager.asteroidsBlasted += 1;
            SpawnRepair();

        }


        // if the asteroid spawns too close to a fuel powerup, weapon powerup, or bacterium, the powerup or bacterium is destroyed
        if (other.gameObject.CompareTag("Fuel Large") || other.gameObject.CompareTag("Fuel Small") || other.gameObject.CompareTag("Sonic Blaster PowerUp") || other.gameObject.CompareTag("Blue Bacterium") || other.gameObject.CompareTag("Red Bacterium") || other.gameObject.CompareTag("Purple Bacterium"))
        {
            Destroy(other.gameObject);

        }


        // If player collides with asteroid, sound is played, asteroid is destroyed, player health is decreased by appropriate amount,
        // and appropriate hit count is increased.
        if (other.CompareTag("Player"))
        {

            switch (asteroidType)
            {   
                case AsteroidType.Small:                    
                    gameManager.smallAsteroidHit += 1;
                    break;

                case AsteroidType.Medium:                  
                    gameManager.mediumAsteroidHit += 1;
                    break;

                case AsteroidType.Large:                  
                    gameManager.largeAsteroidHit += 1;
                    break;
            }

            gameManager.DoDamage(damageAmount);
            playerAudio.PlayOneShot(bumpSound);
            FractureObject();

        }
    }

    public void FractureObject()
    {
        Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version of the asteroid
        Destroy(gameObject); //Destroy the object to stop it getting in the way - fractured parts will not impact the player as their layer does not interact with player layer
    }

    public void SpawnRepair() 
    {
        if (Random.Range(0f, 100f) < gameManager.repairDropChancePercentage) // if random number between 0 & 100 is less than the drop chance percentage
        { 
            Instantiate(repair, transform.position, repair.transform.rotation); //Spawn the spaceship repair kit
        
        }
        

    }

}
