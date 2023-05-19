using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected float _moveSpeed;
    protected int _health;
    protected int _damage;
    public abstract void Move();
    public abstract void Attack();
    public abstract void TakeDamage(int damage);
    public abstract void Die();
}
