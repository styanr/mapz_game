using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory[] _enemyFactories;
    [SerializeField] private float _spawnDelay = 1f;
    private Camera _mainCamera;
    private float _spawnTimer = 0f;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnDelay)
        {
            _spawnTimer = 0f;
            var _enemyFactory = _enemyFactories[Random.Range(0, _enemyFactories.Length)]; 
            Enemy enemy = _enemyFactory.CreateEnemy();
            enemy.transform.position = GetSpawnPosition();
            enemy.transform.parent = transform;
        }
    }
    
    private Vector3 GetSpawnPosition()
{
    var leftTop = _mainCamera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f));
    var leftBottom = _mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
    var rightBottom = _mainCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));
    var rightTop = _mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

    // Define an offset distance to spawn enemies outside the viewport
    float offsetDistance = 2f;

    // Calculate the perimeter of the rectangle
    float perimeter = 2 * (Vector3.Distance(leftTop, leftBottom) + Vector3.Distance(leftBottom, rightBottom));

    // Calculate the number of segments based on the perimeter
    int numSegments = Mathf.RoundToInt(perimeter / offsetDistance);

    // Calculate the length of each segment
    float segmentLength = perimeter / numSegments;

    // Calculate the spawn position along a random segment
    float randomDistance = Random.Range(0f, segmentLength);
    int randomSegment = Random.Range(0, numSegments);
    Vector3 spawnPosition;

    if (randomSegment < numSegments / 4)
    {
        // Spawn along the left edge
        spawnPosition = Vector3.Lerp(leftTop, leftBottom, randomDistance / segmentLength);
        spawnPosition += Vector3.left * offsetDistance;
    }
    else if (randomSegment < numSegments / 2)
    {
        // Spawn along the bottom edge
        spawnPosition = Vector3.Lerp(leftBottom, rightBottom, randomDistance / segmentLength);
        spawnPosition += Vector3.down * offsetDistance;
    }
    else if (randomSegment < numSegments * 3 / 4)
    {
        // Spawn along the right edge
        spawnPosition = Vector3.Lerp(rightBottom, rightTop, randomDistance / segmentLength);
        spawnPosition += Vector3.right * offsetDistance;
    }
    else
    {
        // Spawn along the top edge
        spawnPosition = Vector3.Lerp(rightTop, leftTop, randomDistance / segmentLength);
        spawnPosition += Vector3.up * offsetDistance;
    }

    return spawnPosition;
}


}
