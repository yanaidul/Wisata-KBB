using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _audioSource;
    private bool _isPlay;

    private void Awake()
    {
        base.Awake();
        if (!TryGetComponent<AudioSource>(out AudioSource audioSource)) return;
        _audioSource = audioSource;
    }

    private void Start()
    {
        _isPlay = false;
    }

    private void Update()
    {
        if (!_isPlay) return;
        if(!_audioSource.isPlaying)
        {
            _isPlay = false;
        }
    }

    public void SwitchAudioClip(AudioClip audioClip)
    {
        _isPlay = false;
        StopAudioClip();
        _audioSource.clip = audioClip;
    }

    public void PauseAudioClip()
    {
        if (!_isPlay) return;
        _audioSource.Pause();
    }

    public void PlayAudioClip()
    {
        if (!_isPlay)
        {
            _isPlay = true;
            _audioSource.Play();
        } 
        else UnpauseAudioClip();
    }

    public void UnpauseAudioClip()
    {
        _audioSource.UnPause();
    }

    public void StopAudioClip()
    {
        if (!_isPlay) return;
        _isPlay = false;
        _audioSource.Stop();
    }

    public void PlaySpecificAudioClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}
