using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickhandlerCharacter : MonoBehaviour
{
    public KeyCode KeyFwd;
    public KeyCode KeyBack;
    public Button buttonFwd;
    public Button buttonBack;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyFwd)) // if keyboard key set in inspector as keyfwd is pressed, run fwd method
        {

            Fwd();

        }

        if(Input.GetKeyDown(KeyBack)) // if keyboard key set in inspector as keyfwd is pressed, run back method

        {

            Back();

        }


    }

    public void Fwd() // invokes everything set to run when the UI button buttonFwd is clicked
    {

        buttonFwd.onClick.Invoke();
    }

    public void Back() // invokes everything set to run when the UI button buttonBack is clicked
    {

        buttonBack.onClick.Invoke();
    }

}
