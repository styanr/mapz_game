using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePosition;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    private float _lifetime = 3f;
    private float _timer = 0f;
    protected float _moveSpeed;
    protected int damage;
    
    // Start is called before the first frame update

    private void Awake()
    {
        InitialiseProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }
    private void InitialiseProjectile()
    {
        _mainCamera = Camera.main;
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _direction = (_mousePosition - transform.position).normalized;
        Vector3 rotation = transform.position - _mousePosition;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected virtual void MoveProjectile()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifetime)
        {
            Destroy(gameObject);
        }
        Vector2 position = transform.position;
        Vector2 newPosition = position + _direction * (_moveSpeed * Time.deltaTime);
        var Hits = Physics2D.LinecastAll(position, newPosition);
        foreach (var hit in Hits)
        {
            if (hit.collider.gameObject != gameObject && hit.collider.gameObject != PlayerSingleton.Instance.gameObject)
            {
                OnHit(hit.collider);
            }
        }
        transform.position = newPosition;
    }

    protected virtual void OnHit(Collider2D collider)
    {
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
