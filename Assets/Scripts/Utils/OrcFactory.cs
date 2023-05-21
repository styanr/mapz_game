using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFactory : EnemyFactory
{
    [SerializeField] private Orc _orcPrefab;
    [SerializeField] private OrcWarrior _orcWarriorPrefab;
    [SerializeField] private OrcMage _orcMagePrefab;
    public override Enemy CreateEnemy(EnemyType enemyType = EnemyType.Default)
    {
        Enemy component = null;
        if (enemyType == EnemyType.Default)
        {
            GameObject orc = Instantiate(_orcPrefab.gameObject);
            Orc orcComponent = orc.GetComponent<Orc>();
            component = orcComponent;
        }
        if (enemyType == EnemyType.Warrior)
        {
            GameObject orcWarrior = Instantiate(_orcWarriorPrefab.gameObject);
            OrcWarrior orcWarriorComponent = orcWarrior.GetComponent<OrcWarrior>();
            
            component = orcWarriorComponent;
        }
        if (enemyType == EnemyType.Mage)
        {
            GameObject orcMage = Instantiate(_orcMagePrefab.gameObject);
            OrcMage orcMageComponent = orcMage.GetComponent<OrcMage>();
            
            component = orcMageComponent;
        }
        return component;
    }
}