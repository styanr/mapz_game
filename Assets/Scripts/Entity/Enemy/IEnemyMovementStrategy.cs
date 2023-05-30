using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovementStrategy
{
    public void Move(Transform enemyTransform, float moveSpeed, float moveSpeedMultiplier);
}

public class DefaultMovementStrategy : IEnemyMovementStrategy
{
    public void Move(Transform enemyTransform, float moveSpeed, float moveSpeedMultiplier)
    {
        enemyTransform.position = Vector2
            .MoveTowards(enemyTransform.position, Player.Instance.GetPosition(), 
                moveSpeed * moveSpeedMultiplier * Time.deltaTime);
    }
}

public class FrenzyMovementStrategy : IEnemyMovementStrategy
{
    private float _changeDirectionTimer;
    private float _timer = 0.2f;
    private Vector2 _direction;
    
    private void SetNewTimer()
    {
        _changeDirectionTimer = Random.Range(0.1f, 0.4f);
    }
    public void Move(Transform enemyTransform, float moveSpeed, float moveSpeedMultiplier)
    {
        _timer += Time.deltaTime;
        if(_timer >= _changeDirectionTimer)
        {
            _timer = 0f;
            _direction = Random.insideUnitCircle;
            SetNewTimer();
        }
        enemyTransform.position = Vector2
            .MoveTowards(enemyTransform.position, _direction + (Vector2)enemyTransform.position, 
                moveSpeed * moveSpeedMultiplier * Time.deltaTime);
    }
}