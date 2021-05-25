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
        _text.text = "Made With LOB By:\n" +
            "* Armaan\n" +
            "* Rijul\n" +
            "* Manjit\n" +
            "* Monish?";
    }


    public void ShowAbout()
    {
        _text.text = "little chad wakes up and\nfinds out his little dog\ngorge is missing\n" +
            "follow him along in this\nadventure and find the kutta";
    }

    public void HideContent()
    {
        _text.text = "";
    }
}
