using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _mousePosition;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    public float _moveSpeed = 4f;
    public int damage = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _direction = (_mousePosition - transform.position).normalized;
        Vector3 rotation = transform.position - _mousePosition;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        Vector2 newPosition = position + _direction * (_moveSpeed * Time.deltaTime);
        var Hits = Physics2D.LinecastAll(position, newPosition);
        foreach (var hit in Hits)
        {
            if (hit.collider.gameObject != gameObject && hit.collider.gameObject != PlayerSingleton.Instance.gameObject)
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        transform.position = newPosition;
    }
}
