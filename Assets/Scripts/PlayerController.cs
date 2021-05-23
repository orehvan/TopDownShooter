using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 _moveDirection;
    private Vector2 _mousePos;

    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void ProcessInputs()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(moveX, moveY).normalized;

        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move() =>
        rb.MovePosition(rb.position + _moveDirection * moveSpeed * Time.fixedDeltaTime);

    private void Rotate()
    {
        var lookDirection = _mousePos;
        var mouseAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = mouseAngle;
    }
}
