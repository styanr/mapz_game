using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DebuffType
{
    None,
    Fire,
    Freeze
}
public abstract class Enemy : MonoBehaviour, IEntity
{
    protected float _moveSpeedMultiplier = 1f;
    protected EnemyData _enemyData;
    protected int _health;
    
    protected Player player;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private IEnemyMovementStrategy _movementStrategy;
    
    private float _debuffTimer = 0f;
    private DebuffType _debuffType = DebuffType.None;
    public void SetEnemyData(EnemyData enemyData)
    {
        _enemyData = enemyData;
        _health = enemyData.MaxHealth;
    }
    private void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
        _movementStrategy = new DefaultMovementStrategy();
         
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.drag = 5f;
        _rigidbody2D.angularDrag = 5f;
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = Player.Instance;
    }
    public void SetOnFire()
    {
        spriteRenderer.color = Color.red;
        _movementStrategy = new FrenzyMovementStrategy();
        _moveSpeedMultiplier = 5f;
        
        if(_debuffType == DebuffType.Fire)
            _debuffTimer += 5f;
        else
            _debuffTimer = 5f;
        
        _debuffType = DebuffType.Fire;
    }
    
    public void CheckDebuffTimer()
    {
        if (_debuffTimer > 0f)
        {
            _debuffTimer -= Time.deltaTime;
        }
        else
        {
            _debuffTimer = 0f;
            _movementStrategy = new DefaultMovementStrategy();
            _moveSpeedMultiplier = 1f;
            spriteRenderer.color = Color.white;
        }
    } 
    public void Freeze()
    {
        _debuffTimer += 5f;
        spriteRenderer.color = Color.blue;
        _moveSpeedMultiplier = 0.1f;
        
        if(_debuffType == DebuffType.Freeze)
            _debuffTimer += 5f;
        else
            _debuffTimer = 5f;
        
        _debuffType = DebuffType.Freeze;
    }
    protected virtual void Update()
    {
        Move();
        Flip();
        CheckDebuffTimer();
    }
    // use movement strategy pattern
    public virtual void Move()
    {
        _movementStrategy.Move(transform, _enemyData.MoveSpeed, _moveSpeedMultiplier);
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
            AudioManager.Instance.PlaySoundEffect("EnemyDeath");
        }
        else
        {
            AudioManager.Instance.PlaySoundEffect("EnemyHit");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        //Debug.Log("Attack");
    }
    private void Flip()
    {
        if (transform.position.x > player.GetPosition().x)
        {
            _spriteRenderer.flipX = true;
        }
        else if (transform.position.x < player.GetPosition().x)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
