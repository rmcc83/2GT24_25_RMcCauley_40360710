using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SelfDestruct() 
    {
        if (gameObject.CompareTag("Explosion")) 
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Flame"))
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Fragment"))
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }

    }



}
