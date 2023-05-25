using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   private AudioSource _audioSource;
   public void Awake()
   {
      _audioSource = GetComponent<AudioSource>();
   }
   
   public void PlayOneShot(AudioClip clip)
   {
      if (clip != null)
      {
         _audioSource.PlayOneShot(clip);
      }
   }
   
   public void SetVolume(float volume)
   {
      _audioSource.volume = volume;
   }
   
}
