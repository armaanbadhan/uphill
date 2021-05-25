using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isRunning = false;

    [SerializeField]
    private UIManager _UIManager;

    [SerializeField]
    private Player _Player;

    [SerializeField]
    private DialogueManager _DialogueManager;

    [SerializeField]
    private ButtonScript _buttons;

    [SerializeField]
    private ContentScript _content;


    [SerializeField]
    private TextMeshProUGUI _momConvo;

    void Start()
    {
        _UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _Player = GameObject.Find("Player").GetComponent<Player>();
        _DialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        _buttons = GameObject.Find("ButtonManager").GetComponent<ButtonScript>();
        _content = GameObject.Find("ContentManager").GetComponent<ContentScript>();

        _UIManager.ShowTitleScreen();
        _buttons.ShowAllHideEscape();
    }


    void Update()
    {
        if (!isRunning && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }


    public void ClickEscape()
    {
        _content.HideContent();
        _buttons.ShowAllHideEscape();
    }

    public void ClickAbout()
    {
        _content.ShowAbout();
        _buttons.HideAllShowEscape();
    }

    public void ClickCredits()
    {
        _content.ShowCredits();
        _buttons.HideAllShowEscape();
    }


    public void StartGame()
    {
        isRunning = true;
        _UIManager.HideTitleScreen();
        _content.HideContent();
        _buttons.HideAllButtons();
        StartCoroutine(TypeMomConvoAndStart());
    }

    
    IEnumerator TypeMomConvoAndStart()
    {
        foreach (char letter in _DialogueManager.convoOne)
        {
            _momConvo.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.5f);
        _momConvo.text = "";
        _UIManager.HideBlackBG();
        _Player.StartCoroutine(_Player.InitialMovement());
    }
}
