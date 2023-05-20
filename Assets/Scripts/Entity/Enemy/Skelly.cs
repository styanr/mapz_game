using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelly : Enemy
{
    private void Awake()
    {
        _moveSpeed = 4;
        _health = 15;
        _damage = 3; 
    }
}
