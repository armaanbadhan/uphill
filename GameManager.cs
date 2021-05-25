using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isRunning = false;
    public bool playerMovement = false;

    [SerializeField]
    private UIManager _UIManager;

    [SerializeField]
    private SpawnManager _SpawnManager;

    [SerializeField]
    private DialogueManager _DialogueManager;

    [SerializeField]
    private TextMeshProUGUI _momConvo;

    void Start()
    {
        _UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _DialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }


    void Update()
    {
        if (!isRunning && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        isRunning = true;
        Debug.Log("starting convo");
        StartCoroutine(TypeMomConvo());
        Debug.Log("hidebg called");
        _UIManager.HideBlackBG();
        _SpawnManager.SpawnPlayer();
    }


    IEnumerator TypeMomConvo()
    {
        Debug.Log("convo starts");
        foreach (char letter in _DialogueManager.convoOne)
        {
            _momConvo.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(5);
        Debug.Log("convo ends");
    }
}
