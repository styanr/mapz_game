using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMage : Enemy
{
    // Start is called before the first frame update
    public int _teleportDistance;
    private void Awake()
    {
        _moveSpeed = 15;
        _health = 15;
        _damage = 2; 
    }
    protected override void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerSingleton.Instance.gameObject)
        {
            Attack();
            var randAngle = Random.Range(0, 361);
            transform.position = PlayerSingleton.Instance.transform.position + 
                                 new Vector3(Mathf.Cos(randAngle), Mathf.Sin(randAngle), 0) * _teleportDistance;
        }
    }
}
