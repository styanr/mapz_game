using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    [HideInInspector]
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }
    
    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(moveX, moveY).normalized;
        //Debug.Log(direction.x + " " + direction.y);
    }

    void Move()
    {
        rb.velocity = new Vector2(direction.x * MoveSpeed, direction.y * MoveSpeed);
        //Debug.Log(rb.velocity.x + " " + rb.velocity.y);
    }
}
