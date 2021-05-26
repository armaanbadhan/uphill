using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _hints;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_hints[0], new Vector3(-2, -3.2f, 0), Quaternion.identity);
    }
}
