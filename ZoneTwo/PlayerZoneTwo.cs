using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerZoneTwo : MonoBehaviour
{
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
    }



    public IEnumerator InitialMovement()
    {
        while (transform.position.x < -5.5f)
        {
            transform.position = new Vector3(transform.position.x + 0.02f, -2.33f, 0);
            yield return null;
        }
        SetMovementTrue();
    }

    public void SetMovementTrue()
    {
        _player.playerMovement = true;
    }
}
