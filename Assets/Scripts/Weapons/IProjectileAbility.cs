using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public interface IProjectileAbility
{
    public void Hit(IEntity entity);
}

public class DefaultProjectileAbility : IProjectileAbility
{
    private int _damage;

    public DefaultProjectileAbility(int damage)
    {
        _damage = damage;
    }

    public void Hit(IEntity entity)
    {
        entity.TakeDamage(_damage);
    }
}
public abstract class ProjectileAbilityDecorator : IProjectileAbility
{
    protected IProjectileAbility _projectileAbility;
    public ProjectileAbilityDecorator(IProjectileAbility projectileAbility)
    {
        _projectileAbility = projectileAbility;
    }
    public abstract void Hit(IEntity entity);
}

public class FireProjectileAbility : ProjectileAbilityDecorator
{
    public FireProjectileAbility(IProjectileAbility projectileAbility) : base(projectileAbility)
    {
    }
    public override void Hit(IEntity entity)
    {
        _projectileAbility.Hit(entity);
        entity.SetOnFire();
    }
}

public class FreezeProjectileAbility : ProjectileAbilityDecorator
{
    public FreezeProjectileAbility(IProjectileAbility projectileAbility) : base(projectileAbility)
    {
    }
    public override void Hit(IEntity entity)
    {
        _projectileAbility.Hit(entity);
        entity.Freeze();
    }
}

