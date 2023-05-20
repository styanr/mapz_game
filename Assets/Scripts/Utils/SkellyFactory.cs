using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyFactory : EnemyFactory
{
    [SerializeField] private Skelly _skellyPrefab;
    [SerializeField] private SkellyWarrior _skellyWarriorPrefab;
    public override Enemy CreateEnemy()
    {
        GameObject skelly = Instantiate(_skellyPrefab.gameObject);
        Skelly skellyComponent = skelly.GetComponent<Skelly>();
        
        return skellyComponent;
    }
    public override Enemy CreateWarriorEnemy()
    {
        GameObject skellyWarrior = Instantiate(_skellyWarriorPrefab.gameObject);
        SkellyWarrior skellyWarriorComponent = skellyWarrior.GetComponent<SkellyWarrior>();
        
        return skellyWarriorComponent;
    }
}
