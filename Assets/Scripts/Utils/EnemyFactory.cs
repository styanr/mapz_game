using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Default,
    Warrior,
    Mage
}
public abstract class EnemyFactory : MonoBehaviour
{
    public abstract Enemy CreateEnemy(EnemyType enemyType = EnemyType.Default);
}
