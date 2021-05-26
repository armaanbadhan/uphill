using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ContentScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;


    public void ShowCredits()
    {
        _text.text = "Made By:\n" +
            "* Armaan\n" +
            "* Rijul\n" +
            "* Manjot\n" +
            "* Munish?";
    }


    public void ShowAbout()
    {
        _text.text = "little chad wakes up and\nfinds out his little dog\ngorge is missing\n" +
            "follow him along in this\nadventure and find george";
    }

    public void HideContent()
    {
        _text.text = "";
    }
}
