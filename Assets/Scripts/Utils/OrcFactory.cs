using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFactory : EnemyFactory
{
    [SerializeField] private Orc _orcPrefab;
    [SerializeField] private OrcWarrior _orcWarriorPrefab;
    public override Enemy CreateEnemy()
    {
        GameObject orc = Instantiate(_orcPrefab.gameObject);
        Orc orcComponent = orc.GetComponent<Orc>();
        
        return orcComponent;
    }
    public override Enemy CreateWarriorEnemy()
    {
        GameObject orcWarrior = Instantiate(_orcWarriorPrefab.gameObject);
        OrcWarrior orcWarriorComponent = orcWarrior.GetComponent<OrcWarrior>();
        
        return orcWarriorComponent;
    }
}