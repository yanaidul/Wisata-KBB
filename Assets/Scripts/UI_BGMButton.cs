using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BGMButton : MonoBehaviour
{
    [SerializeField] private Sprite _activeButton, _inactiveButton;
    [SerializeField] private Image _bgmButton;
    //[SerializeField] private BGM _bgm;

    private bool isClicked = false;
    private BGM _bgm;

    private void Start()
    {
        _bgm = BGM.GetInstance();
    }

    public void OnClickBGMButton()
    {
        if (!isClicked) BGMButtonInactive();
        else BGMButtonActive();
    }

    private void BGMButtonActive()
    {

        isClicked = false;
        _bgm.PlayBGM();
        _bgmButton.sprite = _activeButton;
    }

    private void BGMButtonInactive()
    {
        isClicked = true;
        _bgm.PauseBGM();
        _bgmButton.sprite = _inactiveButton;
    }
}
