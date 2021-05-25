using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _blackBG;

    [SerializeField]
    private GameObject _titleScreen;


    public void HideBlackBG()
    {
        _blackBG.SetActive(false);
    }

    public void ShowBlackBG()
    {
        _blackBG.SetActive(true);
    }


    public void ShowTitleScreen()
    {
        _titleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        _titleScreen.SetActive(false);
    }
}
