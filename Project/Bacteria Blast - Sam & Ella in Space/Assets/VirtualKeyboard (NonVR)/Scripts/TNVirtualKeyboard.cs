using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TNVirtualKeyboard : MonoBehaviour
{
	
	public static TNVirtualKeyboard instance;
	
	public string words = "";
	
	public GameObject vkCanvas;
	
	public TMP_InputField targetText;
	
	
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
		HideVirtualKeyboard();
		
    }

    // Update is called once per frame
    void Update()

    {
		// If virtual keyboard is visible, but enter is pressed on physical keyboard, virtual keyboard will switch off
        if (vkCanvas != null && Input.GetKeyDown(KeyCode.Return))
        {
            HideVirtualKeyboard();

        }

		
    }
	
	public void KeyPress(string k){
		words += k;
		targetText.text = words;	
	}
	
	public void Del(){
		words = words.Remove(words.Length - 1, 1);
		targetText.text = words;	
	}
	
	public void ShowVirtualKeyboard(){
		vkCanvas.SetActive(true);
	}
	
	public void HideVirtualKeyboard(){
		vkCanvas.SetActive(false);
	}

	public void ClearWords() 
	{
		words = "";
	
	}



   


}