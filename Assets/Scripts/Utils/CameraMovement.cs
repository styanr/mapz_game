using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public Transform target;
    public Vector3 offset;
    
    private float _smoothSpeed = 0.125f;
    private Vector3 _velocity = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, _smoothSpeed);
    }
}
