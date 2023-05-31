using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private BossState _currentState;
    public Projectile _projectile;
    private IProjectileAbility _projectileAbility;
    private int _damage = 30;
    public float MoveSpeed => _enemyData.MoveSpeed;
    
    protected void Awake()
    {
        SetEnemyData(EnemyTypeFactory.GetEnemyData(3f, 2000, 30, new DefaultMovementStrategy()));
        _currentState = new BossAttackState(this);
        _projectileAbility = new DefaultProjectileAbility(_damage);
    }

    private void CheckHealth()
    {
        var ratio = (float)_health / (float)_enemyData.MaxHealth;
        Debug.Log(_health.ToString().ToString() + " " + _enemyData.MaxHealth.ToString() + " " + ratio.ToString());
        
        if(ratio < 0.5f && ratio > 0.25f && _currentState.GetType() != typeof(BossTeleportState))
        {
            _currentState = new BossTeleportState(this);
        }
        else if(ratio < 0.25f && _currentState.GetType() != typeof(BossTurretState))
        {
            _currentState = new BossTurretState(this);
        }
    }
    protected override void Update()
    {
        _currentState.Update();
        Flip();
    }
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        CheckHealth();
    }
    
    public void Shoot()
    {
        Projectile newProjectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        newProjectile.SetDecorator(_projectileAbility);
    }
}