using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    // Start is called before the first frame update
    private void Awake()
    {
        _moveSpeed = 4;
        _health = 50;
        _damage = 5; 
    }
}
