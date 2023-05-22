using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelly : Enemy, ICloneable<Skelly>
{
    private void Awake()
    {
        _moveSpeed = 4;
        _health = 15;
        _damage = 3; 
    }
    
    public Skelly Clone()
    {
        return Instantiate(this);
    }
}
