using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly private float _horizontalSpeed = 6f;
    public bool playerMovement = false;

    private Rigidbody2D _rigidBody;
    readonly private float _velocity = 10;
    private bool _canJump = true;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerMovement)
        {
            Movement();
        }

        if (!_canJump && transform.position.y < -2.7f)
        {
            _canJump = true;
            _rigidBody.gravityScale = 0;
            _rigidBody.velocity = new Vector2(0, 0);
            transform.position = new Vector3(transform.position.x, -2.7f, 0);
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
}
