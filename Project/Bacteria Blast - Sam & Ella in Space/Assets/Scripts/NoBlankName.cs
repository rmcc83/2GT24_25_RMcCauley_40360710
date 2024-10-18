using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoBlankField : MonoBehaviour
{

    public TMP_InputField playerName;
    // Start is called before the first frame update
    void Start()
    {
        // if player name is blank, the default of A Biotic is entered so the field is not blank
        if (playerName.text == "") 
        {
            playerName.text = "A Biotic";
        }


    }

    // Update is called once per frame
    void Update()
    {
        // if player name is blank, the default of A Biotic is entered so the field is not blank
        if (playerName.text == "")
        {
            playerName.text = "A Biotic";
        }
    }
}
