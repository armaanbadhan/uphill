using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MomConvoManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _momConvo;

    [SerializeField]
    private TextMeshProUGUI _continueButton;

    public readonly string convoOne = "Chad: Ugh. wha..t time is it \n\n" +
    "Mom(shouts) : It’s night time already and you wake up now!!!\nWhat did I tell you about sleeping Late huh?\n\n" +
    "you say nothing, as you stare into the deep void, zoning out.\nIt was pretty late last night.\n\n" +
    "All the demons they don’t let me sleep, forget it mom won’t understand You glance around for georgie.\n\n" +
    "Chad: Hey George! Where are you buddy?\n\nYou say as you walk out...";


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeMomConvo());
    }


    IEnumerator TypeMomConvo()
    {
        foreach (char letter in convoOne)
        {
            _momConvo.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.05f);
        _continueButton.text = "CONTINUE";
    }


    public void ClickContinue()
    {
        SceneManager.LoadScene("GamePlayMain");
    }
}
