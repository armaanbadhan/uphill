using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    void Update()
    {
        if (transform.position.y > -3.33f)
        {
            transform.Translate(Vector3.down * 3 * Time.deltaTime);
        }
        else
        {
            Die();
        }       
    }


    private void Die()
    {
        transform.eulerAngles = new Vector3(0, 0, 90);
    }
}
