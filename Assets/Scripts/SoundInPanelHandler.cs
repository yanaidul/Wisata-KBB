using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundInPanelHandler : MonoBehaviour
{
    [Header("AudioClips")]
    [SerializeField] private AudioClip[] _audioClips;
    [Header("Gameobject Reference")]
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _previousButton;

    private SoundManager _soundManager;
    private PageSwitcher _pageSwitcher;

    private void Awake()
    {
        if (!TryGetComponent<PageSwitcher>(out PageSwitcher pageswitcher)) return;
        _pageSwitcher = pageswitcher;
        _soundManager = SoundManager.GetInstance();
    }

    private void Start()
    {
        if (!_nextButton.TryGetComponent<Button>(out Button nextButton)) return;
        nextButton.onClick.AddListener(OnChangeClipAccordingToPageIndex);
        if (!_previousButton.TryGetComponent<Button>(out Button prevButton)) return;
        prevButton.onClick.AddListener(OnChangeClipAccordingToPageIndex);
    }

    private void OnEnable()
    {
        _soundManager.SwitchAudioClip(_audioClips[0]);
    }

    private void OnDisable()
    {
        _soundManager.StopAudioClip();
    }

    public void OnChangeClipAccordingToPageIndex()
    {
        _soundManager.SwitchAudioClip(_audioClips[_pageSwitcher.CurrentPageIndex]);
    }
}
