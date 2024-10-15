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
        if (playerName.text == "")
        {
            playerName.text = "A Biotic";
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (playerName.text == "")
        {
            playerName.text = "A Biotic";
        }
    }
}
