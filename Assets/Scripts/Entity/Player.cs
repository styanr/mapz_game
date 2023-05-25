using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float timer;
    [SerializeField] private Projectile projectile;
    
    private void Awake()
    {
        _moveSpeed = 5;
        _health = 100;
        _damage = 10;       
    }
    
    public override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(horizontal, vertical) * (_moveSpeed * Time.deltaTime));
    }
    
    public override void Attack()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        GameManager.Instance.ShootArrow();
    }
    
    public void HandleInput()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if(timer >= _fireRate) {
                Attack();
                timer = 0;
            }
        }
    }
    
    public override void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
    
    public override void Die()
    {
        throw new System.NotImplementedException();
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
