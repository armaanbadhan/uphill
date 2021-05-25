using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _blackBG;


    public void HideBlackBG()
    {
        _blackBG.SetActive(false);
    }
}
