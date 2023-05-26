using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public interface IProjectileAbility
{
    public void Hit(Enemy enemy);
}

public class DefaultProjectileAbility : IProjectileAbility
{
    private int _damage;

    public DefaultProjectileAbility(int damage)
    {
        _damage = damage;
    }

    public void Hit(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }
}
public abstract class ProjectileAbilityDecorator : IProjectileAbility
{
    protected IProjectileAbility _projectileAbility;
    public ProjectileAbilityDecorator(IProjectileAbility projectileAbility)
    {
        _projectileAbility = projectileAbility;
    }
    public abstract void Hit(Enemy enemy);
}

public class FireProjectileAbility : ProjectileAbilityDecorator
{
    public FireProjectileAbility(IProjectileAbility projectileAbility) : base(projectileAbility)
    {
    }
    public override void Hit(Enemy enemy)
    {
        _projectileAbility.Hit(enemy);
        enemy.SetOnFire();
    }
}

