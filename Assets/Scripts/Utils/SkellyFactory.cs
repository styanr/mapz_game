using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyFactory : EnemyFactory
{
    [SerializeField] private Skelly _skellyPrefab;
    public override Enemy CreateEnemy()
    {
        GameObject skelly = Instantiate(_skellyPrefab.gameObject);
        Skelly skellyComponent = skelly.GetComponent<Skelly>();
        
        return skellyComponent;
    }
}
