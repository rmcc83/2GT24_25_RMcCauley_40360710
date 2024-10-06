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
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }



}
