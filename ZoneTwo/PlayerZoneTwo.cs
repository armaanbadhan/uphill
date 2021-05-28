using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerZoneTwo : MonoBehaviour
{
    [SerializeField]
    private Image blackk;
    [SerializeField]
    private Animator animm;

    private Player _player;

    [SerializeField]
    private DialogueZoneTwo _DialogueManager;

    private bool _wizardHint = false;

    private void Start()
    {
        _player = GetComponent<Player>();
        _DialogueManager = GameObject.Find("MyDialogueManagerZ2").GetComponent<DialogueZoneTwo>();
        StartCoroutine(InitialMovement());
    }

    private void Update()
    {
        // stairs thing
        if (transform.position.x > 8.15f)
        {
            _player.playerMovement = false;
            transform.Translate(Vector3.up * 6f * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_wizardHint && other.tag is "hint4")
        {
            _player.playerMovement = false;
            _wizardHint = true;
            _DialogueManager.StartWizardConvo();
        }

        if (other.tag is "nextScene")
        {
            StartCoroutine(Fading());
        }
    }



    public IEnumerator InitialMovement()
    {
        while (transform.position.x < -8f)
        {
            transform.position = new Vector3(transform.position.x + 0.02f, _player.floorYCord, 0);
            yield return null;
        }
        SetMovementTrue();
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
