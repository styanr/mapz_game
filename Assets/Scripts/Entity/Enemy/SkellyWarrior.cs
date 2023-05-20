using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyWarrior : Enemy
{
    // Start is called before the first frame update
    private void Awake()
    {
        _moveSpeed = 3;
        _health = 60;
        _damage = 7; 
    }
}
