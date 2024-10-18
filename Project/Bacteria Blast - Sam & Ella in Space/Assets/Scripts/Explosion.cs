using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct()); // Initiates self-destruct co-routine as soon as script starts.  This script is used for timed events 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SelfDestruct() 
    {
        if (gameObject.CompareTag("Explosion")) // if the script is on the explosion object, destroy it after 2 seconds
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Flame")) // if the script is on the flame (spaceship booster rocket) object, destroy it after 0.3 seconds
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Fragment")) // if the script is on the asteroid fragment object, destroy it after 1 second
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }

    }



}
