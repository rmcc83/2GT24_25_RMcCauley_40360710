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

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            gameManager.AddScore(pointValue);
            Destroy(gameObject);
           
        }



    }
}
