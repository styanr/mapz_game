using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
      
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.loop = true;
      
        _audioSource.Play();
    }
   
    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
    
    public float GetVolume()
    {
        return _audioSource.volume;
    }
    public void Pause()
    {
        _audioSource.Pause();
    }

    public void Play()
    {
        _audioSource.Play();
    }
}