using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float boostForce;
    public float boostMax;
    public float topBound;
    public bool doubleSpeed = false;
    public Transform projectileSpawnPoint;
   // public GameObject powerupIndicator;
    public bool hasPowerup = false;
    public GameObject sonicBlastPrefab;
    public GameManager gameManager;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

        // Ensure powerup Indicator appears at player position
      //  powerupIndicator.transform.position = transform.position;

        //If game has started & is not over
        if (gameManager.gameStarted == true && gameManager.gameOver == false)
        {
            // If spacebar is pressed and player is below the maximum boost height and fuel is available, and game is not over, an upward force is applied
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

            // Fire a sonic blast from the player if player has powerup

            if (gameManager.gameStarted == true && gameManager.gameOver == false && hasPowerup == true && Input.GetKey(KeyCode.RightShift))

            {
                Instantiate(sonicBlastPrefab, projectileSpawnPoint.position, sonicBlastPrefab.transform.rotation);
                
            }

        }
    }

    

    public void OnTriggerEnter(Collider other) 
    {
        // If player collides with sonic blaster powerup, icon disappears, indicator appears, countdown routine begins 

        if (other.CompareTag("Sonic Blaster PowerUp"))
        {
            hasPowerup = true;
         //   powerupIndicator.gameObject.SetActive(true);

            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        if (other.CompareTag("Ground") || other.CompareTag("Asteroid"))
        {
            gameManager.gameOver = true;
            Destroy(gameObject);
            Debug.Log("Game Over");
        }

    }

    // Player has powerup for 5 seconds, the indicator disappears & powerup switches off
    IEnumerator PowerupCountdownRoutine()
    {

        yield return new WaitForSeconds(5);
        hasPowerup = false;
     //   powerupIndicator.gameObject.SetActive(false);
        
    }


}
