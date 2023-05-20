using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public Projectile projectile;
    // Start is called before the first frame update
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
        Debug.Log("Attack");
        Instantiate(projectile, transform.position, Quaternion.identity);
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
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
}
