using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; // starting position
    private float repeatWidth;

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x/ 2; //repeat width is hald the size of the box collider around the background image
    }

    void Update()
    {
        // Repeats background once it has scrolled past
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
