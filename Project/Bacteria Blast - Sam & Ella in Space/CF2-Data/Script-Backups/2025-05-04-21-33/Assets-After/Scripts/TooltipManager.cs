﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;
    public TextMeshProUGUI textComponent;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ControlFreak2.CFCursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ControlFreak2.CF2Input.mousePosition;
    }

    public void SetAndShowTooltip(string message)
    {
        gameObject.SetActive(true);
        textComponent.text = message;
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}
