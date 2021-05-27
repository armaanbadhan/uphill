using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerZoneOne : MonoBehaviour
{
    readonly private float _horizontalSpeed = 6f;
    public bool playerMovement = false;

    private Rigidbody2D _rigidBody;
    readonly private float _velocity = 10;
    private bool _canJump = true;

    [SerializeField]
    private Image blackk;
    [SerializeField]
    private Animator animm;

    [SerializeField]
    private DialogueZoneOne _DialogueManager;

    private bool _dogHint = false;
    private bool _guardHint = false;
    private bool _kemptyConvo = false;

    private void Start()
    {
        _DialogueManager = GameObject.Find("DialogueZ1").GetComponent<DialogueZoneOne>();
        _rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(InitialMovement());
    }

    private void Update()
    {
        if (playerMovement)
        {
            Movement();
        }

        // after jump when touches ground
        if (!_canJump && transform.position.y < -2.7f)
        {
            _canJump = true;
            _rigidBody.gravityScale = 0;
            _rigidBody.velocity = new Vector2(0, 0);
            transform.position = new Vector3(transform.position.x, -2.7f, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_dogHint && other.tag is "hint1")
        {
            playerMovement = false;
            _dogHint = true;
            _DialogueManager.TypeDogConveOne();
        }

        if (!_guardHint && other.tag is "hint2")
        {
            playerMovement = false;
            _guardHint = true;
            _DialogueManager.TypeGuardConvo();
        }

        if (!_kemptyConvo && other.tag is "hint3")
        {
            playerMovement = false;
            _kemptyConvo = true;
            _DialogueManager.TypeKemptyConvo();
        }

        if (other.tag is "nextScene")
        {
            StartCoroutine(Fading());
        }
    }



    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // check for boundaries
        if (transform.position.x < -8.5f)
        {
            if (horizontalInput < 0)
            {
                horizontalInput = 0;
            }
        }
        else if (transform.position.x > 8.5f)
        {
            if (horizontalInput > 0)
            {
                horizontalInput = 0;
            }
        }

        // flip the sprite if in opposite direction
        if (horizontalInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontalInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            horizontalInput *= -1;
        }

        transform.Translate(Vector3.right * _horizontalSpeed * horizontalInput * Time.deltaTime);

        // jump
        if (_canJump && Input.GetKeyDown(KeyCode.W))
        {
            _rigidBody.gravityScale = 2.75f;
            _canJump = false;
            _rigidBody.velocity = new Vector2(0, _velocity);
        }
    }


    public IEnumerator InitialMovement()
    {
        while (transform.position.x < -5.5f)
        {
            transform.position = new Vector3(transform.position.x + 0.02f, -2.7f, 0);
            yield return null;
        }
        playerMovement = true;
    }


    IEnumerator Fading()
    {
        animm.SetBool("Fade", true);
        yield return new WaitUntil(() => blackk.color.a == 1);
        SceneManager.LoadScene("ZoneTwo");
    }
}
