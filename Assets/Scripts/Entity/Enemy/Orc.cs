using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    // Start is called before the first frame update
    protected void Awake()
    {
        SetEnemyData(EnemyTypeFactory.GetEnemyData(4f, 30, 5, new DefaultMovementStrategy()));
    }
}
