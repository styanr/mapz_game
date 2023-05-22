using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SkellyMage : Enemy
{
    public int _safeRadius;
    public GameObject _projectile;
    public float _fireRate;
    private float _timer = 0f;
    private void Awake()
    {
        _moveSpeed = 7;
        _health = 15;
        _damage = 2;
    }
    public override void Move()
    {
        var distance = Vector2.Distance(transform.position, player.position);
        if (distance > _safeRadius)
        {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            transform.Translate(directionToPlayer.normalized * _moveSpeed * Time.deltaTime);
        }
        else if (distance <= _safeRadius)
        {
            Vector2 directionFromPlayer = (transform.position - player.position).normalized;
            transform.Translate(directionFromPlayer * _moveSpeed * Time.deltaTime);
        }
    }
    
    protected override void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _fireRate)
        {
            Attack();
            _timer = 0f;
        }
        base.Update();
    }
    
    public override void Attack()
    {
        Instantiate(_projectile, transform.position, Quaternion.identity);
    }
}
