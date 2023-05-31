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
        SetEnemyData(EnemyTypeFactory.GetEnemyData(7f, 15, 2, new AvoidPlayerMovementStrategy()));
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
