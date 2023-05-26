using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IEntity
{
    protected float _moveSpeed;
    protected int _health;
    protected int _damage;
    
    protected Transform player;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.drag = 5f;
        _rigidbody2D.angularDrag = 5f;
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = Player.Instance.transform;
    }
    public void SetOnFire()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
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
            .MoveTowards(transform.position, player.position, _moveSpeed * Time.deltaTime);
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
            AudioManager.Instance.PlayClip("EnemyDeath");
        }
        else
        {
            AudioManager.Instance.PlayClip("EnemyHit");
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
        Debug.Log("Attack");
    }
    private void Flip()
    {
        if (transform.position.x > player.position.x)
        {
            _spriteRenderer.flipX = true;
        }
        else if (transform.position.x < player.position.x)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
