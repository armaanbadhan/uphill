using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private ButtonScript _buttons;

    [SerializeField]
    private ContentScript _content;

    private bool _isEscapeActive = false;

    private void Start()
    {
        _buttons = GameObject.Find("ButtonsManager").GetComponent<ButtonScript>();
        _content = GameObject.Find("ContentManager").GetComponent<ContentScript>();

        _buttons.ShowAllHideEscape();
    }


    private void Update()
    {
        if (_isEscapeActive && Input.GetKeyDown(KeyCode.Escape))
        {
            ClickEscape();
        }
    }


    public void ClickStart()
    {
        _content.HideContent();
        _buttons.HideAllButtons();
        SceneManager.LoadScene("MOMConvo");
    }


    public void ClickEscape()
    {
        _isEscapeActive = false;
        _content.HideContent();
        _buttons.ShowAllHideEscape();
    }

    public void ClickAbout()
    {
        _content.ShowAbout();
        _buttons.HideAllShowEscape();
        _isEscapeActive = true;
    }

    public void ClickCredits()
    {
        _content.ShowCredits();
        _buttons.HideAllShowEscape();
        _isEscapeActive = true;
    }
}
