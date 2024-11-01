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
    public TextMeshProUGUI armedTextEndless;
    public TextMeshProUGUI unarmedTextEndless;
    public bool hasPowerup = true;
    public GameObject sonicBlastPrefab;
    public GameObject flamePrefab;
    public GameObject explosion;
    public CumulativeStatsHandler cumulativeStatsHandler;
    public GameManager gameManager;
    public SpawnManager spawnManager;
    public AudioClip weaponSound;
    public AudioClip boostSound;
    public AudioClip crashSound;
    public AudioClip scream1;
    public AudioClip scream2;
    public AudioClip scream3;
    public AudioClip laugh;
    public AudioClip fuelFill;
    public AudioClip weaponArm;
    public PlayerController playerController;
    public GameObject FloatingText;
    public Color textColour;






    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        groundAudio = GameObject.Find("Ground").GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        cumulativeStatsHandler = GameObject.Find("CumulativeStatsHandler").GetComponent<CumulativeStatsHandler>();


    }

    void Update()
    {

        //If game has started & is not over
        if (gameManager.gameStarted == true && gameManager.gameOver == false)
        {
            // If spacebar is pressed and player is below the maximum boost height and fuel is available,
            // constraint on player's Y position is removed, an upward force is applied to the player,
            // & fuel reduces by 5%.  Flame prefabs are also instantiated from bottom of spaceship & appropriate
            // sound is played
            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < boostMax && gameManager.fuel >= 5)
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

            // when left control is pressed, double speed is activated
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                doubleSpeed = true;

            }

            // when left control key is released double speed is deactivated
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                doubleSpeed = false;

            }

            // Fire a sonic blast from the player and play sound if game has started & is not over & player has powerup, and left alt is pressed

            if (gameManager.gameStarted == true && gameManager.gameOver == false && hasPowerup == true && Input.GetKeyDown(KeyCode.LeftAlt))

            {
                playerAudio.PlayOneShot(weaponSound);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint1.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint2.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint3.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint4.position, sonicBlastPrefab.transform.rotation);

            }

        }

        if (gameManager.gameStarted == true && gameManager.gameOver == true && gameManager.gameWin == true) 
        {

            playerRb.constraints = RigidbodyConstraints.FreezeAll; // constrains player motion at game win, so player does not crash (and thus lose as well as win)

        }


    }

    

    public void OnTriggerEnter(Collider other) 
    {
        // If player collides with sonic blaster powerup, powerup disappears, sound is played, indicator appears around player,
        // weapon text changes from unarmed to armed, countdown routine begins 

        if (other.CompareTag("Sonic Blaster PowerUp"))
        {
            gameManager.weaponCollected += 1;
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            playerAudio.PlayOneShot(weaponArm);
            armedText.gameObject.SetActive(true);
            unarmedText.gameObject.SetActive(false);
            armedTextEndless.gameObject.SetActive(true);
            unarmedTextEndless.gameObject.SetActive(false);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        // if player collides with ground or asteroid, player is destroyed, explosion visuals are instantiated at impact point,
        // crash sound is played, and game is over.  What happens at this point (ie what gamemanger method is called) depends on 
        // whether an endless mode level is being played or not.
        if (other.CompareTag("Ground") || other.CompareTag("Asteroid"))
        {

            Vector3 expSpawnpos = new(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(explosion, expSpawnpos, explosion.transform.rotation);
            groundAudio.PlayOneShot(crashSound);
            Destroy(gameObject);

            if (gameManager.gameEndless != true) 
            {
                gameManager.GameLose();

            }

            if (gameManager.gameEndless == true)
            {
                gameManager.GameOverCrash();

            }

        }

        if (other.CompareTag("Ground")) // updates ground crash stats if collision is with ground
        {

 
           cumulativeStatsHandler.GroundCrash();

        }

        if (other.CompareTag("Asteroid")) // updates ground crash stats if collision is with asteroid
        {

            
            cumulativeStatsHandler.AsteroidCrash();

        }



        // if player collides with small fuel powerup, 20% is added to fuel amount & sound is played

        if (other.CompareTag("Fuel Small"))
        {
            Destroy(other.gameObject);
            gameManager.smallFuelCollected += 1;
            gameManager.IncreaseFuel(20);
            playerAudio.PlayOneShot(fuelFill);
        }

        // if player collides with large fuel powerup, 50 % is added to fuel amount & sound is played

        if (other.CompareTag("Fuel Large"))
        {
            Destroy(other.gameObject);
            gameManager.largeFuelCollected += 1;
            gameManager.IncreaseFuel(50);
            playerAudio.PlayOneShot(fuelFill);

        }

        // if player collides with blue bacterium, a scream is played & floating text colour is set to blue

        if (other.CompareTag("Blue Bacterium")) 
        {

            playerAudio.PlayOneShot(scream1);
            textColour = Color.blue;


        }

        // if player collides with red bacterium, a second scream is played & floating text colour is set to red


        if (other.CompareTag("Red Bacterium"))
        {
            playerAudio.PlayOneShot(scream2);
            textColour = Color.red;


        }

        // if player collides with purple bacterium, a third scream is played & floating text colour is set to purple


        if (other.CompareTag("Purple Bacterium"))
        {
            playerAudio.PlayOneShot(scream3);
            textColour = Color.magenta;

        }

        // if player collides with a virus, a laugh is played

        if (other.CompareTag("Virus"))
        {
            playerAudio.PlayOneShot(laugh);
            ShowFloatingText2();

        }


    }

    // Player has powerup for 5 seconds, after which the indicator around the player disappears, weapon text changes
    // from armed to unarmed, & right shift no longer caused a projectile to be emitted
    IEnumerator PowerupCountdownRoutine()
    {

        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        armedText.gameObject.SetActive(false);
        unarmedText.gameObject.SetActive(true);
        armedTextEndless.gameObject.SetActive(false);
        unarmedTextEndless.gameObject.SetActive(true);


    }

    // Instantiates floating Text showing point value passed from bacteria script, in colour set earlier
   public void ShowFloatingText(int pointValue)
    {
       
        var go = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().color = textColour;
        go.GetComponent<TextMesh>().text = pointValue.ToString();

    }

    // Floating Text showing green X for virus collection
   public void ShowFloatingText2()
    {
        var go = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().color = Color.green;
        go.GetComponent<TextMesh>().text = "X";
    }



}
