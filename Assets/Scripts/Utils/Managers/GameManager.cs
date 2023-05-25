using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] AudioManager _audioManager;
    private Sounds _sounds;
    //private UIManager _uiManager;

    private void Start()
    {
        _sounds = GetComponent<Sounds>();
        //_uiManager = GetComponent<UIManager>();
    }
    public void ShootArrow()
    {
        _audioManager.PlayOneShot(_sounds.GetSound("laserShoot"));
    }

    public void Hit()
    {
        _audioManager.PlayOneShot(_sounds.GetSound("hitHurt"));
    }

    public void EnemyDeath()
    {
        _audioManager.PlayOneShot(_sounds.GetSound("enemyDeath"));
    }
}
