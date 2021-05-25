using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;


    public void SpawnPlayer()
    {
        Instantiate(_player, new Vector3(0, 3, 0), Quaternion.identity);
    }
}
