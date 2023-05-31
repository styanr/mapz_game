using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossState
{
    protected Boss _boss;
    protected IEnemyMovementStrategy _movementStrategy;
    public BossState(Boss boss)
    {
        _boss = boss;
    }
    public abstract void Update();
}

public class BossAttackState : BossState
{
    public BossAttackState(Boss boss) : base(boss)
    {
        _movementStrategy = new DefaultMovementStrategy();
    }

    public override void Update()
    {
        _movementStrategy.Move(_boss.transform, _boss.MoveSpeed, 1f);
    }
}

public class BossTeleportState : BossState
{
    private float _teleportDistance = 15f;
    private float _teleportTime = 1.5f;
    private float _fireTime = 0.7f;
    private float _speedMultiplier = 3f;
    
    private void Teleport()
    {
        var randAngle = Random.Range(0, 361);
        _boss.transform.position = Player.Instance.transform.position + 
                             new Vector3(Mathf.Cos(randAngle), Mathf.Sin(randAngle), 0) * _teleportDistance;
    }
    public BossTeleportState(Boss boss) : base(boss)
    {
        _movementStrategy = new DefaultMovementStrategy();
    }

    public override void Update()
    {
        _teleportTime -= Time.deltaTime;
        _fireTime -= Time.deltaTime;
        
        if(_teleportTime <= 0f)
        {
            Teleport();
            _teleportTime = Random.Range(1f, 1.5f);
        }
        
        if(_fireTime <= 0f)
        {
            _boss.Shoot();
            _fireTime = 1f;
        }
        
        _movementStrategy.Move(_boss.transform, _boss.MoveSpeed * _speedMultiplier, 1f);
    }
}

public class BossTurretState : BossState
{
    private float _speed;
    private Camera _mainCamera;
    private float _timer = 5f;
    private float _teleportTime = 4f;
    private float _fireTime = 3f;
    private float _fireRate = 0.1f;
    private float _fireTimer = 0f;
    public BossTurretState(Boss boss) : base(boss)
    {
        _speed = Player.Instance.MoveSpeed;
        _mainCamera = Camera.main;
    }
    
    public override void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _fireTime)
        {
            _fireTimer += Time.deltaTime;
            if (_fireTimer > _fireRate)
            {
                _boss.Shoot();
                _fireTimer = 0f;
            }    
        }
        else if(_timer > _teleportTime)
        {
            TeleportToRandomCorner();
            _fireTime = 3f;    
            _timer = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log(horizontal + " " + vertical);
        
        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        
        _boss.transform.Translate(direction * (_speed * Time.deltaTime));
    }
    
    private void TeleportToRandomCorner()
    {
        float padding = 0.1f;
        
        Vector2 bottomLeft = _mainCamera.ViewportToWorldPoint(new Vector3(0 + padding, 0 + padding, 0));
        Vector2 topRight = _mainCamera.ViewportToWorldPoint(new Vector3(1 - padding, 1 - padding, 0));
        Vector2 topLeft = _mainCamera.ViewportToWorldPoint(new Vector3(0 + padding, 1 - padding, 0));
        Vector2 bottomRight = _mainCamera.ViewportToWorldPoint(new Vector3(1 - padding, 0 + padding, 0));

        List<Vector2> corners = new List<Vector2>()
        {
            bottomLeft, 
            topRight, 
            topLeft, 
            bottomRight
        };
        var randomCorner = corners[Random.Range(0, corners.Count)];

        Vector3 newPos = new Vector3(randomCorner.x, randomCorner.y, 0f);
        _boss.transform.position = newPos;
    }
}
