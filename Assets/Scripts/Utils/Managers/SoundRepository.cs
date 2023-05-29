using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundRepository : MonoBehaviour
{
    [SerializeField] private List<AudioClip> Effects;
    [SerializeField] private List<AudioClip> Music;
    private Dictionary<string, AudioClip> EffectsDictionary;
    private Dictionary<string, AudioClip> MusicDictionary;

    public void Awake()
    {
        EffectsDictionary = new Dictionary<string, AudioClip>();
        foreach (var audioClip in Effects)
        {
            EffectsDictionary.Add(audioClip.name, audioClip);
        }
        MusicDictionary = new Dictionary<string, AudioClip>();
        foreach (var audioClip in Music)
        {
            MusicDictionary.Add(audioClip.name, audioClip);
        }
    }

    public AudioClip GetEffect(string soundName)
    {
        return EffectsDictionary.TryGetValue(soundName, out var audioClip) ? audioClip : null;
    }
    
    public AudioClip GetMusic(string soundName)
    {
        return MusicDictionary.TryGetValue(soundName, out var audioClip) ? audioClip : null;
    }
}