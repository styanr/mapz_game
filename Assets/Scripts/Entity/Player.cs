using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>, IEntity
{
    protected float _moveSpeed;
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
                break;
            case 1:
                _projectileAbility = new FireProjectileAbility(_projectileAbility);
                break;
            case 2:
                //_projectileAbility = new FreezeProjectileAbility(_projectileAbility);
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
        if (Input.GetKeyDown("1"))
        {
            SetDecorator(0);
        }
        if (Input.GetKeyDown("2"))
        {
            SetDecorator(1);
        }
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if(timer >= _fireRate) {
                Attack();
                timer = 0;
            }
        }
    }
    
    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
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
}
