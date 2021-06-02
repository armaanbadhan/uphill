using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// last scene
public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _content;

    [SerializeField]
    private TextMeshProUGUI _backButton;

    private bool _backShow = false;


    readonly private string _famousLastWords = "You spend the night sitting there with george,\n" +
        "observing the magnificent scenery and taking in\n" +
        "the cold air..breathe...it feels good to be alive.";


    void Start()
    {
        StartCoroutine(TypeFamousLastWords());
    }

    private void Update()
    {
        if (_backShow && Input.GetKeyDown(KeyCode.Space))
        {
            ClickBack();
        }
    }


    IEnumerator TypeFamousLastWords()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in _famousLastWords)
        {
            _content.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        ShowBackButton();
    }


    private void ShowBackButton()
    {
        _backButton.text = "press space bitch";
        _backShow = true;
    }

    public void ClickBack()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        yield return null;
        SceneManager.LoadScene("MainMenu");
    }
}
