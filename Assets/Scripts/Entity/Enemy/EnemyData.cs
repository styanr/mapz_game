using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    public float MoveSpeed { get; private set; }
    public int MaxHealth { get; private set; }
    public int Damage { get; private set; }

    public EnemyData(float moveSpeed, int maxHealth, int damage)
    {
        MoveSpeed = moveSpeed;
        MaxHealth = maxHealth;
        Damage = damage;
    }
}

class EnemyTypeFactory
{
    private static List<EnemyData> _enemyDatas = new List<EnemyData>();
    
    public static EnemyData GetEnemyData(float moveSpeed, int maxHealth, int damage)
    {
        var enemyData = _enemyDatas.Find(data => data.Equals(new EnemyData(moveSpeed, maxHealth, damage)));
        if (enemyData == null)
        {
            enemyData = new EnemyData(moveSpeed, maxHealth, damage);
            _enemyDatas.Add(enemyData);
        }

        foreach (var enemyDataa in _enemyDatas)
        {
            Debug.Log(enemyDataa);
        }
        return enemyData;
    }
}
