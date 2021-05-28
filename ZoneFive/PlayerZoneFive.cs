using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerZoneFive : MonoBehaviour
{
    [SerializeField]
    private Image blackk;
    [SerializeField]
    private Animator animm;

    private Player _player;

    private bool _initialDone = false;

    [SerializeField]
    private DialogueZoneFive _dialogueManager;


    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _dialogueManager = GameObject.Find("DialogueZ5").GetComponent<DialogueZoneFive>();
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
            _dialogueManager.ShowExclamation();
            SetMovementTrue();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag is "kutta")
        {
            _player.playerMovement = false;
            _dialogueManager.StartDogConvo();
        }
    }


    public void SetMovementTrue()
    {
        _player.playerMovement = true;
    }

    public void LastRites()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        yield return new WaitForSeconds(1.5f);
        animm.SetBool("Fade", true);
        yield return new WaitUntil(() => blackk.color.a == 1);
        SceneManager.LoadScene("HappyEnding");
    }
}
