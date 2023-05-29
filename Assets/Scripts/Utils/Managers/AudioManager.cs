using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private SFXManager _sfxManager;
    [SerializeField] private MusicManager _musicManager;
    [SerializeField] private SoundRepository _soundRepository;

    public void PlaySoundEffect(string clipName)
    {
        var clip = _soundRepository.GetEffect(clipName);
        if (clip != null)
        {
            _sfxManager.PlayClip(clip);
        }
    }
   
    public void PlayMusic(string clipName)
    {
        var clip = _soundRepository.GetMusic(clipName);
        if (clip != null)
        {
            _musicManager.PlayMusic(clip);
        }
    }
   
    public void SetVolume(float volume)
    {
        _sfxManager.SetVolume(volume);
        _musicManager.SetVolume(volume);
    }

    public float GetVolume()
    {
        return _sfxManager.GetVolume();
    }

    public void Pause()
    {
        _sfxManager.Pause();
        _musicManager.Pause();
    }
   
    public void Play()
    {
        _sfxManager.Play();
        _musicManager.Play();
    }
}
