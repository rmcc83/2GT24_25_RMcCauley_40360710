using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameVersion : MonoBehaviour
{
    public TextMeshProUGUI gameVersion;

    // Start is called before the first frame update
    void Start()
    {
        gameVersion.text = "Game Version: " + Application.version; // displays game version as set in player settings
    }

    // Update is called once per frame
    void Update()
    {

    }
}
