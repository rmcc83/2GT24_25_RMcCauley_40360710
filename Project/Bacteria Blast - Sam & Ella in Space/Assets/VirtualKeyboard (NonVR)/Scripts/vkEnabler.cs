using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class vkEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
    // Method which is called when virtual keyboard is required - keyboard is shown and acts on a particular inputfield
	public void ShowVirtualKeyboard()
    {
		TNVirtualKeyboard.instance.ShowVirtualKeyboard();
		TNVirtualKeyboard.instance.targetText = gameObject.GetComponent<TMP_InputField>();
	}
}
