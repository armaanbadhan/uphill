using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _momConvo;

    private readonly string _convo = "Char: Ugh. wha..t time is it \n\n" +
        "Mom(shouts) : It�s night time already and you wake up now!!!\nWhat did I tell you about sleeping Late huh?\n\n" +
        "Char: you say nothing , as you stare into the deep void , zoning out.\nIt was pretty late last night.\n\n" +
        "All the demons they don�t let me sleep, forget it mom won�t understand You glance around for georgie.\n\n" +
        "Char: Hey George! Where are you buddy?\n\nYou say as you walk out...";




    public IEnumerator TypeMomConvo()
    {
        foreach(char letter in _convo)
        {
            _momConvo.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(5);
    }
}
