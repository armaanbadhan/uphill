using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _dialogue;

    [SerializeField]
    private TextMeshProUGUI _continueButton;

    [SerializeField]
    private Player _player;

    readonly private string _convoOne= "chad (to himself): those are george's footsteps. he must be up ahead.";

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void TypeDogConveOne()
    {
        StartCoroutine(TypeConvo(_convoOne));
    }

    IEnumerator TypeConvo(string whatToType)
    {
        foreach (char letter in whatToType)
        {
            _dialogue.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.05f);
        _continueButton.text = "CONTINUE";
    }

    public void ClickContinue()
    {
        _continueButton.text = "";
        _dialogue.text = "";
        _player.playerMovement = true;
    }
}
