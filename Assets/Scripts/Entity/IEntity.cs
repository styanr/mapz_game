using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public void Move();
    public void Attack();
    public void TakeDamage(int damage);
    public void Die();
    public void Freeze();
    public void SetOnFire();
}