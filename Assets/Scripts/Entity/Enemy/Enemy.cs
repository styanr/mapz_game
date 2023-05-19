using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    private Transform player;
    
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = PlayerSingleton.Instance.transform;
    }

    private void Update()
    {
        Move();
        Flip();
    }

    public override void Move()
    {
        transform.position = Vector2
            .MoveTowards(transform.position, player.position, _moveSpeed * Time.deltaTime);
    }
    
    public override void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerSingleton.Instance.gameObject)
        {
            Attack();
        }
    }

    public override void Attack()
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
