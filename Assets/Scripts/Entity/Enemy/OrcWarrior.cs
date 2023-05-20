using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcWarrior : Enemy
{
    // Start is called before the first frame update
    private void Awake()
    {
        _moveSpeed = 2;
        _health = 45;
        _damage = 10; 
    }
}
