using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private SoundManager _soundManager;

    private void Awake()
    {
        _soundManager = SoundManager.GetInstance();
    }

    private void OnEnable()
    {
        _soundManager.PlaySpecificAudioClip(_audioClip);
    }
}
