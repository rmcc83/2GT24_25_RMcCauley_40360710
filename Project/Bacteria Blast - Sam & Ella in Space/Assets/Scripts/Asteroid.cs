using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates asteroid slowly
        transform.Rotate(30 * Time.deltaTime, 0, 0);
    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
           
        }


    }
}
