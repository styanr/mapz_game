using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    public float MoveSpeed { get; private set; }
    public int MaxHealth { get; private set; }
    public int Damage { get; private set; }
    
    public IEnemyMovementStrategy MovementStrategy { get; private set; }

    public EnemyData(float moveSpeed, int maxHealth, int damage, IEnemyMovementStrategy movementStrategy)
    {
        MoveSpeed = moveSpeed;
        MaxHealth = maxHealth;
        Damage = damage;
        MovementStrategy = movementStrategy;
    }

    public override bool Equals(object obj)
    {
        var other = obj as EnemyData;
        if (other == null)
            return false;
        return this.MoveSpeed.Equals(other.MoveSpeed) &&
               this.MaxHealth.Equals(other.MaxHealth) &&
               this.Damage.Equals(other.Damage) &&
               this.MovementStrategy.GetType() == other.MovementStrategy.GetType();
    }
    
    public override int GetHashCode()
    {
        // use the HashCode.Combine() method to combine the hash codes of MoveSpeed, MaxHealth, Damage and MovementStrategy
        return HashCode.Combine(this.MoveSpeed, this.MaxHealth, this.Damage, this.MovementStrategy.GetType());
    }
}

class EnemyTypeFactory
{
    private static List<EnemyData> _enemyDatas = new List<EnemyData>();
    
    public static EnemyData GetEnemyData(float moveSpeed, int maxHealth, int damage, IEnemyMovementStrategy movementStrategy)
    {
        var enemyData = _enemyDatas.Find(data => data.Equals(new EnemyData(moveSpeed, maxHealth, damage, movementStrategy)));
        if (enemyData == null)
        {
            enemyData = new EnemyData(moveSpeed, maxHealth, damage, movementStrategy);
            _enemyDatas.Add(enemyData);
        }
        Debug.Log(_enemyDatas.Count.ToString());
        return enemyData;
    }
}
