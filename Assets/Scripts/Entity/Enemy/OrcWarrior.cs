using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcWarrior : Enemy
{
    private void Awake()
    {
        SetEnemyData(EnemyTypeFactory.GetEnemyData(2f, 100, 10, new DefaultMovementStrategy()));
    }
    
    protected override void Update()
    {
        _moveSpeedMultiplier = Math.Clamp((_enemyData.MaxHealth / _health), 1f, 5f);
        base.Update();
    }
}
