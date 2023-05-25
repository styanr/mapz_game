using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    // Use a custom attribute to populate the array from the assets folder
    [SerializeField] private List<AudioClip> _audioClips;
    
    public AudioClip GetSound(string soundName)
    {
        return _audioClips.FirstOrDefault(clip => clip.name == soundName);
    }
}