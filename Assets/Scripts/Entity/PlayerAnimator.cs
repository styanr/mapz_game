using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerMovement.direction.x != 0 || _playerMovement.direction.y != 0)
        {
            _animator.SetBool("Move", true);
            SpriteFlip();
        }
        else
        {
            _animator.SetBool("Move", false);
        }
    }
    
    void SpriteFlip()
    {
        if(_playerMovement.direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if(_playerMovement.direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
