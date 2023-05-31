using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossProjectile : Projectile
{
    void Start()
    {
        _moveSpeed = 30f;
        _ability = new DefaultProjectileAbility(10);
    }
    protected override void CalculateDirection()
    {
        _direction = (Player.Instance.transform.position - transform.position).normalized;
        Vector2 noise = Random.insideUnitCircle * 0.2f;
        _direction += noise;
    }
    
    protected override bool ShouldHitObject(Collider2D collider)
    {
        //Debug.Log(collider.gameObject);
        return collider.gameObject != gameObject;
    }

    protected override void OnHit(Collider2D collider)
    {
        var entity = collider.gameObject.GetComponent<IEntity>();
        if (entity == null) return;
        if (entity is Boss) return;
        
        _ability.Hit(entity);
        Destroy(gameObject);
    }
}
