using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BGM : Singleton<BGM>
{
    [SerializeField] private AudioClip _bgmClip;
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private float _bgmVolume;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _bgmSource.clip = _bgmClip;
        _bgmSource.loop = true;
        SetBGMVolume(_bgmVolume);

        _bgmSource.Play();
    }


    public void SetBGMVolume(float volume)
    {
        _bgmSource.volume = volume;
    }

    public void PauseBGM()
    {
        _bgmSource.Pause();
    }

    public void PlayBGM()
    {
        _bgmSource.Play();
    }

    public void UnpauseBGM()
    {

        _bgmSource.UnPause();
    }

    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    public void DestroyBGMGameObject()
    {
        Destroy(gameObject);
    }
}