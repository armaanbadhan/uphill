using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooMuchMusicTheseDays : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
