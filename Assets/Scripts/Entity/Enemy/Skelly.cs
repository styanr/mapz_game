using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelly : Enemy, ICloneable<Skelly>
{
    private void Awake()
    {
        SetEnemyData(EnemyTypeFactory.GetEnemyData(4f, 15, 3));
    }
    
    public Skelly Clone()
    {
        return Instantiate(this);
    }
}
