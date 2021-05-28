using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerZoneOne : MonoBehaviour
{
    private Player _player;

    [SerializeField]
    private DialogueZoneOne _DialogueManager;

    private bool _dogHint = false;
    private bool _guardHint = false;
    private bool _kemptyConvo = false;

    private void Start()
    {
        _player = GetComponent<Player>();
        _DialogueManager = GameObject.Find("DialogueZ1").GetComponent<DialogueZoneOne>();
        StartCoroutine(InitialMovement());
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_dogHint && other.tag is "hint1")
        {
            _player.playerMovement = false;
            _dogHint = true;
            _DialogueManager.TypeDogConveOne();
        }

        if (!_guardHint && other.tag is "hint2")
        {
            _player.playerMovement = false;
            _guardHint = true;
            _DialogueManager.TypeGuardConvo();
        }

        if (!_kemptyConvo && other.tag is "hint3")
        {
            _player.playerMovement = false;
            _kemptyConvo = true;
            _DialogueManager.TypeKemptyConvo();
        }
    }


    public IEnumerator InitialMovement()
    {
        while (transform.position.x < -5.5f)
        {
            transform.position = new Vector3(transform.position.x + 0.02f, -2.7f, 0);
            yield return null;
        }
        SetMovementTrue();
    }

    public void SetMovementTrue()
    {
        _player.playerMovement = true;
    }
}
