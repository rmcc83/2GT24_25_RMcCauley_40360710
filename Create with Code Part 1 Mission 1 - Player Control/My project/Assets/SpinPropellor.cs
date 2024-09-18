using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate propellor around axis, 10 degrees per frame

        transform.Rotate(0, 0, 10);
    }
}
