using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 _moveDirection;

    private void Update()
    {
        // _moveDirection = Vector2.down * moveSpeed;
        // rb.velocity = _moveDirection;
    }
}
