using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IEntity
{
    protected float _moveSpeedMultiplier = 1f;
    protected EnemyData _enemyData;
    protected int _health;
    
    protected Player player;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer spriteRenderer;
    
    public void SetEnemyData(EnemyData enemyData)
    {
        _enemyData = enemyData;
        _health = enemyData.MaxHealth;
    }
    private void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.drag = 5f;
        _rigidbody2D.angularDrag = 5f;
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = Player.Instance;
    }
    public void SetOnFire()
    {
        spriteRenderer.color = Color.red;
    }

    public void Freeze()
    {
        spriteRenderer.color = Color.blue;
        _moveSpeedMultiplier = 0.1f;
    }
    protected virtual void Update()
    {
        Move();
        Flip();
    }
    // use movement strategy pattern
    public virtual void Move()
    {
        transform.position = Vector2
            .MoveTowards(transform.position, player.GetPosition(), 
                _enemyData.MoveSpeed * _moveSpeedMultiplier * Time.deltaTime);
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
