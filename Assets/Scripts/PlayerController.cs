using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 _moveDirection;
    private Vector2 _mousePos;
    
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(moveX, moveY).normalized;

        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.MovePosition(rb.position + _moveDirection * moveSpeed * Time.fixedDeltaTime);
        
        var lookDirection = _mousePos - rb.position;
        var mouseAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = mouseAngle;
    }
}
