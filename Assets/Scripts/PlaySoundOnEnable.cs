using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script yang diberikan pada suatu gameobject yang dimana bila game object tersebut muncul di screen, soundeffectnya akan mulai
/// </summary>
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
