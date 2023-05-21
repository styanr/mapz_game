using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyMage : Enemy
{
    public int _safeDistance;
    private void Awake()
    {
        _moveSpeed = 6;
        _health = 15;
        _damage = 2;
    }
    public override void Move()
    {
        var distance = Vector2.Distance(transform.position, player.position);
        if (distance > _safeDistance)
        {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            transform.Translate(directionToPlayer.normalized * _moveSpeed * Time.deltaTime);
        }
        else if (distance < _safeDistance)
        {
            Vector2 directionFromPlayer = (transform.position - player.position).normalized;
            transform.Translate(directionFromPlayer.normalized * _moveSpeed * Time.deltaTime);
        }
    }
}
