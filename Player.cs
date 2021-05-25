using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly private float _horizontalSpeed = 7.5f;
    public bool playerMovement = false;


    private void Update()
    {
        if (playerMovement)
        {
            Movement();
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
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
        transform.Translate(Vector3.right * _horizontalSpeed * horizontalInput * Time.deltaTime);
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
