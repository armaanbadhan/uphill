using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerZoneThree : MonoBehaviour
{
    [SerializeField]
    private Image blackk;
    [SerializeField]
    private Animator animm;

    private Player _player;

    private bool _initialDone = false;
    private bool _auntChat = false;

    [SerializeField]
    private DialogueZoneThree _dialogueManager;


    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _dialogueManager = GameObject.Find("DialogueZ3").GetComponent<DialogueZoneThree>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_initialDone && transform.position.y < _player.floorYCord)
        {
            transform.Translate(Vector3.up * 2.5f * Time.deltaTime);
        }
        else if (!_initialDone)
        {
            _initialDone = true;
            SetMovementTrue();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_auntChat && other.tag is "hint5")
        {
            _player.playerMovement = false;
            _auntChat = true;
            _dialogueManager.StartAuntConvo();
        }

        if (other.tag is "nextScene")
        {
            StartCoroutine(Fading());
        }
    }


    public void SetMovementTrue()
    {
        _player.playerMovement = true;
    }

    IEnumerator Fading()
    {
        animm.SetBool("Fade", true);
        yield return new WaitUntil(() => blackk.color.a == 1);
        SceneManager.LoadScene("ZoneThree");
    }
}
