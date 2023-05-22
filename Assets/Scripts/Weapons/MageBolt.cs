using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MageBolt : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        _moveSpeed = 20f;
        damage = 0;
    }

    private GameObject FindNearestSkelly()
    {
        GameObject[] skellies = GameObject.FindGameObjectsWithTag("Skelly");
        GameObject closestSkelly = null;
        float closestDistanceToSkelly = Mathf.Infinity;
        
        foreach (GameObject skelly in skellies)
        {
            float distanceToSkelly = Vector2.Distance(transform.position, skelly.transform.position);
            if (distanceToSkelly < closestDistanceToSkelly)
            {
                closestDistanceToSkelly = distanceToSkelly;
                closestSkelly = skelly;
            }

        }
        return closestSkelly;
    }
    protected override void CalculateDirection()
    {
        GameObject closestSkelly = FindNearestSkelly();
        if (closestSkelly != null)
        {
            _direction = (closestSkelly.transform.position - transform.position).normalized;
        }
        else Destroy(gameObject);
    }
    protected override void InitialiseProjectile()
    {
        CalculateDirection();
        SetRotation();
    }

    protected override void OnHit(Collider2D collider)
    {
        Skelly skelly = collider.GetComponent<Skelly>();
        if (skelly != null)
        {
            CloneSkelly(skelly);
            Destroy(gameObject);
        }
    }

    private void CloneSkelly(Skelly skelly)
    {
        Skelly clonedSkelly = skelly.Clone();
        clonedSkelly.transform.position = skelly.transform.position;
    }
}
