using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleFracture : MonoBehaviour
{
    public GameObject[] asteroids;
    public GameObject chonker;
    private int counter = 0;

    void Update()
    {
        //Code loops through asteroids and fractures them on space
        if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.Space))
        {
            asteroids[counter].GetComponent<Fracture>().FractureObject();
            counter++;
        }
        if (ControlFreak2.CF2Input.GetKey(KeyCode.I))
        {
            chonker.gameObject.SetActive(true);
        }

    }
}
