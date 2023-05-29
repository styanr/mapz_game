using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SFXManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayClip(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    public void PlayClip(string clipName)
    {
        var clip = Resources.Load<AudioClip>(clipName);
        if (clip != null)
        {
            PlayClip(clip);
        }
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