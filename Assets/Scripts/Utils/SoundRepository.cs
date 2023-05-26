using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundRepository : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips;
    private Dictionary<string, AudioClip> _audioClipDictionary;

    public void Awake()
    {
        _audioClipDictionary = new Dictionary<string, AudioClip>();
        foreach (var audioClip in _audioClips)
        {
            _audioClipDictionary.Add(audioClip.name, audioClip);
        }
    }

    public AudioClip GetSound(string soundName)
    {
        return _audioClipDictionary.TryGetValue(soundName, out var audioClip) ? audioClip : null;
    }
}