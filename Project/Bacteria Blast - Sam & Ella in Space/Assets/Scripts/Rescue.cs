using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{
    public GameObject sam;
    public GameObject ella;
    public Vector3 samOffset;
    public Vector3 ellaOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)  // Cause Sam & Ella to appear when pod hits ground
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(sam, transform.position + samOffset, sam.transform.rotation);
            Instantiate(ella, transform.position + ellaOffset, ella.transform.rotation);

            
        }
        
    }
}
