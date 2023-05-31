using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : Singleton<Player>, IEntity
{
    protected float _moveSpeed;
    public float MoveSpeed => _moveSpeed;
    
    protected int _health;
    protected int _damage;
    private IProjectileAbility _projectileAbility;
    
    [SerializeField] private float _fireRate;
    [SerializeField] private float timer;
    [SerializeField] private Projectile projectile;
    
    private void Start()
    {
        _moveSpeed = 5;
        _health = 100;
        _damage = 15;     
        SetDecorator(0);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public void SetDecorator(int ability)
    {
        switch (ability)
        {
            case 0:
                _projectileAbility = new DefaultProjectileAbility(_damage);
                Debug.Log("Default");
                break;
            case 1:
                _projectileAbility = new FireProjectileAbility(new DefaultProjectileAbility(_damage));
                Debug.Log("Fire");
                break;
            case 2:
                _projectileAbility = new FreezeProjectileAbility(new DefaultProjectileAbility(_damage));
                Debug.Log("Freeze");
                break;
        }
    }
    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(horizontal, vertical) * (_moveSpeed * Time.deltaTime));
    }
    
    public void Attack()
    {
        Projectile newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.SetDecorator(_projectileAbility);
        AudioManager.Instance.PlaySoundEffect("PlayerShootArrow");
    }
    
    public void HandleInput()
    {
        timer += Time.deltaTime;
        
        if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0) 
                                  || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            var inputKey = Input.inputString[0];
            if (char.IsDigit(inputKey))
            {
                SetDecorator(int.TryParse(inputKey.ToString(), out var ability) ? ability : 0);
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                if(timer >= _fireRate) {
                    Attack();
                    timer = 0;
                }
            }    
        }
        
    }
    
    public void TakeDamage(int damage)
    {
        Debug.Log("Ouch!");
    }
    
    public void Die()
    {
        throw new System.NotImplementedException();
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
    
    public void Freeze()
    {
        throw new System.NotImplementedException();
    }

    public void SetOnFire()
    {
        throw new System.NotImplementedException();
    }
}
