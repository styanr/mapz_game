using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
   private AudioSource _audioSource;
   private SoundRepository _soundRepository;
   public void Start()
   {
      _audioSource = GetComponent<AudioSource>();
      _soundRepository = GetComponent<SoundRepository>();
   }
   
   public void PlayClip(string clipName)
   {
      var clip = _soundRepository.GetSound(clipName);
      if (clip != null)
      {
         _audioSource.PlayOneShot(clip);
      }
   }
}
