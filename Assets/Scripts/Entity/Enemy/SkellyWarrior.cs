using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyWarrior : Enemy
{
    // Start is called before the first frame update
    private void Awake()
    {
        SetEnemyData(EnemyTypeFactory.GetEnemyData(3f, 60, 7));
    }
}
