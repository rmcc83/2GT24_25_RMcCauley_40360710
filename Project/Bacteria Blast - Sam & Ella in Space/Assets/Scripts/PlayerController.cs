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
    public int skinEquipped;
    public GameObject spaceship1;
    public GameObject spaceship2;
    public GameObject spaceship3;
    public GameObject spaceship4;



    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        groundAudio = GameObject.Find("Ground").GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {

        //If game has started & is not over
        if (gameManager.gameStarted == true && gameManager.gameOver == false)
        {
            // If spacebar is pressed and player is below the maximum boost height and fuel is available,
            // constraint on player's Y position is removed, an upward force is applied to the player,
            // & fuel reduces by 5%.  Flame prefbas are also instantiated from bottom of spaceship & appropriate
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

            // Fire a sonic blast from the player and play sound if game has started & is not over & player has powerup, and right shift is pressed

            if (gameManager.gameStarted == true && gameManager.gameOver == false && hasPowerup == true && Input.GetKeyDown(KeyCode.RightShift))

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
        // If player collides with sonic blaster powerup, powerup disappears, sound is played, indicator appears around player,
        // weapon text changes from unarmed to armed, countdown routine begins 

        if (other.CompareTag("Sonic Blaster PowerUp"))
        {
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

        // if player collides with small fuel powerup, 20% is added to fuel amount & sound is played

        if (other.CompareTag("Fuel Small"))
        {
            Destroy(other.gameObject);

            gameManager.IncreaseFuel(20);
            playerAudio.PlayOneShot(fuelFill);
        }

        // if player collides with large fuel powerup, 50 % is added to fuel amount & sound is played

        if (other.CompareTag("Fuel Large"))
        {
            Destroy(other.gameObject);
            gameManager.IncreaseFuel(50);
            playerAudio.PlayOneShot(fuelFill);

        }

        // if player collides with blue bacterium, a scream is played

        if (other.CompareTag("Blue Bacterium")) 
        {
            playerAudio.PlayOneShot(scream1);

        }

        // if player collides with red bacterium, a second scream is played

        if (other.CompareTag("Red Bacterium"))
        {
            playerAudio.PlayOneShot(scream2);

        }

        // if player collides with red bacterium, a third scream is played

        if (other.CompareTag("Purple Bacterium"))
        {
            playerAudio.PlayOneShot(scream3);

        }

        // if player collides with a virus, a laugh is played

        if (other.CompareTag("Virus"))
        {
            playerAudio.PlayOneShot(laugh);

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

    public void SetSkinEquipped(int value)
    {
        skinEquipped = value;

    }

    public void SaveSkin()
    {
        if (gameManager.player1 == true)
        {
            PlayerPrefs.SetInt("SkinEquipped1", skinEquipped);
            PlayerPrefs.Save();
        }

        if (gameManager.player2 == true)
        {
            PlayerPrefs.SetInt("SkinEquipped2", skinEquipped);
            PlayerPrefs.Save();
        }

        if (gameManager.player3 == true)
        {
            PlayerPrefs.SetInt("SkinEquipped3", skinEquipped);
            PlayerPrefs.Save();
        }

    }

    public void LoadSkin()
    {
        if (gameManager.player1 == true)
        {
            skinEquipped = PlayerPrefs.GetInt("SkinEquipped1");

        }

        if (gameManager.player2 == true)
        {
            skinEquipped = PlayerPrefs.GetInt("SkinEquipped2");

        }

        if (gameManager.player3 == true)
        {
            skinEquipped = PlayerPrefs.GetInt("SkinEquipped3");

        }



        if (skinEquipped == 0)
        {
            spaceship1.SetActive(true);
            spaceship2.SetActive(false);
            spaceship3.SetActive(false);
            spaceship4.SetActive(false);
        }


        if (skinEquipped == 1)
        {
            spaceship1.SetActive(true);
            spaceship2.SetActive(false);
            spaceship3.SetActive(false);
            spaceship4.SetActive(false);
        }

        if (skinEquipped == 2)
        {
            spaceship1.SetActive(false);
            spaceship2.SetActive(true);
            spaceship3.SetActive(false);
            spaceship4.SetActive(false);
        }

        if (skinEquipped == 3)
        {
            spaceship1.SetActive(false);
            spaceship2.SetActive(false);
            spaceship3.SetActive(true);
            spaceship4.SetActive(false);
        }

        if (skinEquipped == 4)
        {
            spaceship1.SetActive(false);
            spaceship2.SetActive(false);
            spaceship3.SetActive(false);
            spaceship4.SetActive(true);
        }



    }

}
