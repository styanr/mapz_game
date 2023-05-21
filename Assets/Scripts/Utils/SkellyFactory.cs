using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyFactory : EnemyFactory
{
    [SerializeField] private Skelly _skellyPrefab;
    [SerializeField] private SkellyWarrior _skellyWarriorPrefab;
    [SerializeField] private SkellyMage _skellyMagePrefab;
    public override Enemy CreateEnemy(EnemyType enemyType = EnemyType.Default)
    {
        Enemy component = null;
        if (enemyType == EnemyType.Default)
        {
            GameObject skelly = Instantiate(_skellyPrefab.gameObject);
            Skelly skellyComponent = skelly.GetComponent<Skelly>();
            
            component = skellyComponent;
        }
        else if (enemyType == EnemyType.Warrior)
        {
            GameObject skellyWarrior = Instantiate(_skellyWarriorPrefab.gameObject);
            SkellyWarrior skellyWarriorComponent = skellyWarrior.GetComponent<SkellyWarrior>();
            
            component = skellyWarriorComponent;
        }
        else if (enemyType == EnemyType.Mage)
        {
            GameObject skellyMage = Instantiate(_skellyMagePrefab.gameObject);
            SkellyMage skellyMageComponent = skellyMage.GetComponent<SkellyMage>();
            
            component = skellyMageComponent;
        }
        
        return component;
    }
}
