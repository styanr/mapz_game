using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePosition;
    protected Vector2 _direction;
    protected float _lifetime = 3f;
    private float _timer = 0f;
    protected float _moveSpeed;
    private IProjectileAbility _ability;

    public void SetDecorator(IProjectileAbility ability)
    {
        _ability = ability;
    }
    
    private void Awake()
    {
        InitialiseProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }
    protected virtual void InitialiseProjectile()
    {
        _mainCamera = Camera.main;
        SetMousePosition();
        CalculateDirection();
        SetRotation();
    }

    protected virtual void SetMousePosition()
    {
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void CalculateDirection()
    {
        _mousePosition.z = 0;
        _direction = (_mousePosition - transform.position).normalized;
        //Debug.Log(_direction.x + " " + _direction.y + " ");
    }

    protected virtual void SetRotation()
    {
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 180f);
    }

    protected virtual void MoveProjectile()
    {
        CheckTimeToLive();
        Vector2 position = transform.position;
        Vector2 newPosition = CalculateNewPosition(position);
        CheckCollision(position, newPosition);
        transform.position = newPosition;
    }
    
    protected void CheckTimeToLive()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifetime)
        {
            Destroy(gameObject);
        }
    }

    protected Vector2 CalculateNewPosition(Vector2 currentPosition)
    {
        return currentPosition + _direction * (_moveSpeed * Time.deltaTime);
    }

    protected void CheckCollision(Vector2 startPosition, Vector2 endPosition)
    {
        var hits = Physics2D.LinecastAll(startPosition, endPosition);
        foreach (var hit in hits)
        {
            if (ShouldHitObject(hit.collider))
            {
                OnHit(hit.collider);
                return; // Stop checking for further collisions
            }
        }
    }

    protected virtual bool ShouldHitObject(Collider2D collider)
    {
        return collider.gameObject != gameObject && collider.gameObject != Player.Instance.gameObject;
    }

    protected virtual void OnHit(Collider2D collider)
    {
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            _ability.Hit(enemy);
        }

        Destroy(gameObject);
    }
}
