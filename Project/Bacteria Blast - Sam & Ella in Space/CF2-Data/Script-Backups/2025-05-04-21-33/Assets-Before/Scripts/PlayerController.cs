using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Audio
    private AudioSource groundAudio;
    private AudioSource playerAudio;
    public AudioClip lowFuelSound;
    public AudioClip weaponSound;
    public AudioClip boostSound;
    public AudioClip crashSound;
    public AudioClip scream1;
    public AudioClip scream2;
    public AudioClip scream3;
    public AudioClip laugh;
    public AudioClip fuelFill;
    public AudioClip weaponArm;
    public AudioClip repair;
    public AudioClip cheatChime;

    // Player-related
    private Rigidbody playerRb;
    public float boostForce;
    public float speed;
    public float fuelDrain;
    public GameObject powerupIndicator;
    

    // Bools
    public bool fastFuelDrain = false;
    public bool doubleSpeed = false;
    public bool fuelAnim = false;
    public bool hasPowerup = false;

    // Projectile spaawn locations
    public Transform projectileSpawnPoint1;
    public Transform projectileSpawnPoint2;
    public Transform projectileSpawnPoint3;
    public Transform projectileSpawnPoint4;

    // Thruster positions
    public Transform thrustPosition1;
    public Transform thrustPosition2;

    // Prefabs
    public GameObject sonicBlastPrefab;
    public GameObject flamePrefab;
    public GameObject explosion;
    public GameObject escapePod;

    // Floating Text
    public Color textColour;
    public GameObject FloatingText;

    public CumulativeStatsHandler cumulativeStatsHandler;
    public GameManager gameManager;
    public SpawnManager spawnManager;   
    public PlayerController playerController;
    public float topBound;
    public float playerLimitLeft;
    public float playerLimitRight;



    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        groundAudio = GameObject.Find("Ground").GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        cumulativeStatsHandler = GameObject.Find("CumulativeStatsHandler").GetComponent<CumulativeStatsHandler>();
        
    }

    void Update()
    {
        // Destroy player object & play explosion visuals & sound when health reaches 0
        if (gameManager.gameStarted == true && gameManager.health == 0)
        {
            SpaceshipExplode();

        }



        //If game has started & is not over
        if (gameManager.gameStarted == true && gameManager.gameOver == false)
        {
            if (gameManager.fuel < 30 && gameManager.fuel > 29)
            {
                playerAudio.PlayOneShot(lowFuelSound);

            } 

            // If W is pressed and fuel is available,
            // constraint on player's Y position is removed, an upward force is applied to the player,
            // & fuel reduces by the amount set by fuelDrain each second.  Flame prefabs are also instantiated from bottom of spaceship
            if (Input.GetKey(KeyCode.W) && gameManager.fuel > 0)
            {

                playerRb.constraints &= ~RigidbodyConstraints.FreezePositionY;
                playerRb.AddForce(Vector3.up * boostForce);
                gameManager.fuel -= fuelDrain * Time.deltaTime;
                    
                if (fastFuelDrain == true)
                {
                   gameManager.fuel -= (2 * fuelDrain) * Time.deltaTime;
                }

                                         
                if (gameManager.cheatActive == 3)       // if unlimited fuel cheat is active, fuel drain is 0;
                {
                    fuelDrain = 0f;
  
                }

                Instantiate(flamePrefab, thrustPosition1.position, flamePrefab.transform.rotation);
                Instantiate(flamePrefab, thrustPosition2.position, flamePrefab.transform.rotation);
                
            }

            if (gameManager.altControlSlider.value == 1)    // if alternate control scheme is in use
            {
                if (gameManager.fuel > 0)   // gravity is off as long as there is fuel
                {
                    playerRb.useGravity = false;

                }
                else playerRb.useGravity = true;       // once fuel is 0, gravity switches on & spaceship falls
                

                if (Input.GetKey(KeyCode.S) && gameManager.fuel > 0)    // controls down movement when alt controls in use
                {
                    playerRb.constraints &= ~RigidbodyConstraints.FreezePositionY;
                    playerRb.AddForce(Vector3.down * boostForce);
                    gameManager.fuel -= fuelDrain * Time.deltaTime;

                    if (fastFuelDrain == true)
                    {
                        gameManager.fuel -= (2 * fuelDrain) * Time.deltaTime;
                    }

                    if (gameManager.cheatActive == 3)   // no fuel drain if unlimited fuel cheat is active
                    {
                        
                        fuelDrain = 0f;

                    }
                    Instantiate(flamePrefab, thrustPosition1.position, flamePrefab.transform.rotation);
                    Instantiate(flamePrefab, thrustPosition2.position, flamePrefab.transform.rotation);
                }

                if (Input.GetKey(KeyCode.D) && gameManager.fuel > 0)    // controls down movement when alt controls in use
                {
                    playerRb.constraints &= ~RigidbodyConstraints.FreezePositionX;
                    playerRb.AddForce(Vector3.right * boostForce);
                    gameManager.fuel -= fuelDrain * Time.deltaTime;

                    if (fastFuelDrain == true)
                    {
                        gameManager.fuel -= (2 * fuelDrain) * Time.deltaTime;
                    }

                    if (gameManager.cheatActive == 3)   // no fuel drain if unlimited fuel cheat is active
                    {

                        fuelDrain = 0f;

                    }
                    Instantiate(flamePrefab, thrustPosition1.position, flamePrefab.transform.rotation);
                    Instantiate(flamePrefab, thrustPosition2.position, flamePrefab.transform.rotation);
                }

                if (Input.GetKey(KeyCode.A) && gameManager.fuel > 0)    // controls down movement when alt controls in use
                {
                    playerRb.constraints &= ~RigidbodyConstraints.FreezePositionX;
                    playerRb.AddForce(Vector3.left * boostForce);
                    gameManager.fuel -= fuelDrain * Time.deltaTime;

                    if (fastFuelDrain == true)
                    {
                        gameManager.fuel -= (2 * fuelDrain) * Time.deltaTime;
                    }

                    if (gameManager.cheatActive == 3)   // no fuel drain if unlimited fuel cheat is active
                    {

                        fuelDrain = 0f;

                    }
                    Instantiate(flamePrefab, thrustPosition1.position, flamePrefab.transform.rotation);
                    Instantiate(flamePrefab, thrustPosition2.position, flamePrefab.transform.rotation);
                }

            }


            // spaceship engine sound is played when W is pressed down, having it playing continuously sounds unpleasant
            
            if (Input.GetKeyDown(KeyCode.W) && gameManager.fuel > 0) 
            {

                playerAudio.PlayOneShot(boostSound);
            }

            // if alt controls are in use, spaceship engine sound is played when S, D or A is pressed down

            if (gameManager.altControlSlider.value == 1 && gameManager.fuel > 0)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                {
                    playerAudio.PlayOneShot(boostSound);
                }
            }

            // movement stops when movement key is released

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                playerRb.velocity = Vector3.zero;

            }

            // Ensures player cannot go outside the top of the screen
            if (transform.position.y > topBound)
            {
                transform.position = new Vector3(transform.position.x, topBound, transform.position.z);

            }

            // Ensures player cannot go outside the left of the screen
            if (transform.position.x < playerLimitLeft)
            {
                transform.position = new Vector3(playerLimitLeft, transform.position.y, transform.position.z);

            }

            // Ensures player cannot go outside the right of the screen
            if (transform.position.x > playerLimitRight)
            {
                transform.position = new Vector3(playerLimitRight, transform.position.y, transform.position.z);

            }


            // when left control is pressed, double speed is activated, which doubles fuelDrain
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                doubleSpeed = true;
                fastFuelDrain = true;
            }

            // when left control key is released double speed is deactivated
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                doubleSpeed = false;
                fastFuelDrain = false;
            }

            // Fire a sonic blast from the player and play sound if game has started & is not over & player has powerup, and space is pressed

            if (gameManager.gameStarted == true && gameManager.gameOver == false && hasPowerup == true && Input.GetKeyDown(KeyCode.Space))

            {
                playerAudio.PlayOneShot(weaponSound);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint1.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint2.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint3.position, sonicBlastPrefab.transform.rotation);
                Instantiate(sonicBlastPrefab, projectileSpawnPoint4.position, sonicBlastPrefab.transform.rotation);

            }

            // Fire sonic blast if ammo cheat code has been entered & space is pressed
            if (gameManager.cheatActive == 1)
            {
                hasPowerup = true;
                powerupIndicator.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerAudio.PlayOneShot(weaponSound);
                    Instantiate(sonicBlastPrefab, projectileSpawnPoint1.position, sonicBlastPrefab.transform.rotation);
                    Instantiate(sonicBlastPrefab, projectileSpawnPoint2.position, sonicBlastPrefab.transform.rotation);
                    Instantiate(sonicBlastPrefab, projectileSpawnPoint3.position, sonicBlastPrefab.transform.rotation);
                    Instantiate(sonicBlastPrefab, projectileSpawnPoint4.position, sonicBlastPrefab.transform.rotation);


                }
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
            gameManager.armedText.gameObject.SetActive(true);
            gameManager.unArmedText.gameObject.SetActive(false);
            gameManager.armedTextEndless.gameObject.SetActive(true);
            gameManager.unArmedTextEndless.gameObject.SetActive(false);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }

        // if player collides with ground, player is destroyed, explosion visuals are instantiated at impact point,
        // crash sound is played, and game is over.  What happens at this point (ie what gamemanger method is called) depends on 
        // whether an endless mode level is being played or not.
        if (other.CompareTag("Ground"))
        {
            SpaceshipExplode();
            cumulativeStatsHandler.GroundCrash();
        
            if (gameManager.gameEndless != true) 
            {
                gameManager.GameLose();

            }

            if (gameManager.gameEndless == true)
            {
                gameManager.GameOverCrash();

            }

        }

        

        // if player collides with small fuel powerup, 20% is added to fuel amount, sound is played, indicator animates briefly (then bool is reset)

        if (other.CompareTag("Fuel Small"))
        {
            Destroy(other.gameObject);
            gameManager.smallFuelCollected += 1;
            gameManager.IncreaseFuel(20);
            playerAudio.PlayOneShot(fuelFill);
            fuelAnim = true;
            StartCoroutine(FuelAnimationCountdownRoutine());
        }

        // if player collides with large fuel powerup, 50 % is added to fuel amount, sound is played, indicator animates briefly (then bool is reset)

        if (other.CompareTag("Fuel Large"))
        {
            Destroy(other.gameObject);
            gameManager.largeFuelCollected += 1;
            gameManager.IncreaseFuel(50);
            playerAudio.PlayOneShot(fuelFill);
            fuelAnim = true;
            StartCoroutine(FuelAnimationCountdownRoutine());

        }

        // if player collides with repair powerup, spaceship health is inceased by 1 if it is not already at max

        if (other.CompareTag("Repair"))
        {
            playerAudio.PlayOneShot(repair);
            Destroy(other.gameObject);
            gameManager.repairCollected += 1;
            gameManager.Repair(1);
            
            
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
        gameManager.armedText.gameObject.SetActive(false);
        gameManager.unArmedText.gameObject.SetActive(true);
        gameManager.armedTextEndless.gameObject.SetActive(false);
        gameManager.unArmedTextEndless.gameObject.SetActive(true);


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

    // Animates fuel indicator when fuel powerup is collected
    IEnumerator FuelAnimationCountdownRoutine() 
    {
        yield return new WaitForSeconds(2);
        fuelAnim = false;

    }

    public void SpaceshipExplode() 
    {
        
        Vector3 expSpawnpos = new(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(explosion, expSpawnpos, explosion.transform.rotation);
        Instantiate(escapePod, expSpawnpos, escapePod.transform.rotation);
        groundAudio.PlayOneShot(crashSound);
        Destroy(gameObject);

    }

    
}
