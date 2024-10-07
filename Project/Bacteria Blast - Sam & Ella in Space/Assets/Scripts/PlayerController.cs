using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private AudioSource groundAudio;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    public float gravityModifier;
    public float boostForce;
    public float boostMax;
    public float topBound;
    public bool doubleSpeed = false;
    public Transform projectileSpawnPoint1;
    public Transform projectileSpawnPoint2;
    public Transform projectileSpawnPoint3;
    public Transform projectileSpawnPoint4;
    public Transform thrustPosition1;
    public Transform thrustPosition2;
    public GameObject powerupIndicator;
    public TextMeshProUGUI armedText;
    public TextMeshProUGUI unarmedText;
    public bool hasPowerup = true;
    public GameObject sonicBlastPrefab;
    public GameObject flamePrefab;
    public GameObject explosion;
    public GameManager gameManager;
    public SpawnManager spawnManager;
    public AudioClip weaponSound;
    public AudioClip boostSound;
    public AudioClip crashSound;



    void Start()
    {
        groundAudio = GameObject.Find("Ground").GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        Physics.gravity *= gravityModifier;

    }

    void Update()
    {

        //If game has started & is not over
        if (gameManager.gameStarted == true && gameManager.gameOver == false)
        {
            // If spacebar is pressed and player is below the maximum boost height and fuel is available, and game is not over, an upward force is applied & fuel reduces by 5%
            if (Input.GetKeyDown(KeyCode.Space) && (transform.position.y < boostMax) && gameManager.fuel >= 5)
            {
                playerRb.constraints &= ~RigidbodyConstraints.FreezePositionY;
                playerRb.AddForce(Vector3.up * boostForce, ForceMode.Impulse);
                gameManager.IncreaseFuel(-5);
                Instantiate(flamePrefab, thrustPosition1.position, flamePrefab.transform.rotation);
                Instantiate(flamePrefab, thrustPosition2.position, flamePrefab.transform.rotation);
                playerAudio.PlayOneShot(boostSound);

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

            // Fire a sonic blast from the player if player has powerup, and play sound

            if (gameManager.gameStarted == true && gameManager.gameOver == false && hasPowerup == true && Input.GetKey(KeyCode.RightShift))

            {
                playerAudio.PlayOneShot(weaponSound);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint1.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint2.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint3.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint4.position, sonicBlastPrefab.transform.rotation);



            }

        }
    }

    

    public void OnTriggerEnter(Collider other) 
    {
        // If player collides with sonic blaster powerup, icon disappears, indicator appears, text changes, countdown routine begins 

        if (other.CompareTag("Sonic Blaster PowerUp"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            armedText.gameObject.SetActive(true);
            unarmedText.gameObject.SetActive(false);

            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        // if player collides with ground or asteroid, player is destroyed, explosion visuals & sound occur, and game is over
        if (other.CompareTag("Ground") || other.CompareTag("Asteroid"))
        {
            gameManager.gameOver = true;
            Vector3 expSpawnpos = new(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(explosion, expSpawnpos, explosion.transform.rotation);
            Destroy(gameObject);
            groundAudio.PlayOneShot(crashSound);
            Debug.Log("Game Over");
        }

        // if player collides with small fuel powerup, 20% is added to fuel amount

        if (other.CompareTag("Fuel Small"))
        {
            Destroy(other.gameObject);
            gameManager.IncreaseFuel(20);

        }

        // if player collides with large fuel powerup, 50 % is added to fuel amount

        if (other.CompareTag("Fuel Large"))
        {
            Destroy(other.gameObject);
            gameManager.IncreaseFuel(50);;

        }

    }

    // Player has powerup for 5 seconds, the indicator disappears, text changes & powerup switches off
    IEnumerator PowerupCountdownRoutine()
    {

        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        armedText.gameObject.SetActive(false);
        unarmedText.gameObject.SetActive(true);

    }

    






}
