using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float MoveSpeed = 0;
    
    private Transform player;
    
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
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

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, MoveSpeed * Time.deltaTime);
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
