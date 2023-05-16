using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFactory : EnemyFactory
{
    [SerializeField] private Orc _orcPrefab;
    public override Enemy CreateEnemy()
    {
        GameObject orc = Instantiate(_orcPrefab.gameObject);
        Orc orcComponent = orc.GetComponent<Orc>();
        
        return orcComponent;
    }
}