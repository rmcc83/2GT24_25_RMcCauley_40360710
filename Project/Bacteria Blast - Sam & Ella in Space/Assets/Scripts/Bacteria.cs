using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Available types of bacteria

public enum BacteriaType

{ Red, Purple, Blue }


public class Bacteria : MonoBehaviour

{
    private GameManager gameManager;
    public int pointValue;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //The type of this bacterium
    public BacteriaType bacteriaType = BacteriaType.Red;


    private void OnTriggerEnter(Collider other) 

    {
        // If Player & Bacteria Collide, bacterium is destroyed & appropriate count is incremented

        if (other.CompareTag("Player")) 
        {
            if (bacteriaType == BacteriaType.Blue)
            {
                gameManager.blueRemaining -= 1;
                Destroy(gameObject);
            }

            if (bacteriaType == BacteriaType.Purple)
            {
                gameManager.purpleRemaining -= 1;
                Destroy(gameObject);
            }

            if (bacteriaType == BacteriaType.Red)
            {
                gameManager.redRemaining -= 1;
                Destroy(gameObject);
            }

        }

        // If bacteria & powerup or virus spawn together, powerup or virus is destroyed

        if (other.gameObject.CompareTag("Fuel Large") || other.gameObject.CompareTag("Fuel Small") || other.gameObject.CompareTag("Sonic Blaster PowerUp") || other.gameObject.CompareTag("Virus"))
        {
            Destroy(other.gameObject);


        }



    }
}
