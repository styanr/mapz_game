using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMage : Enemy
{
    // Start is called before the first frame update
    public int _teleportDistance;
    private void Awake()
    {
        SetEnemyData(EnemyTypeFactory.GetEnemyData(15f, 15, 2, new DefaultMovementStrategy()));
    }
    protected override void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Attack();
            var randAngle = Random.Range(0, 361);
            transform.position = Player.Instance.transform.position + 
                                 new Vector3(Mathf.Cos(randAngle), Mathf.Sin(randAngle), 0) * _teleportDistance;
        }
    }
}
