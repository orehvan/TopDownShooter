using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothness = 0.1f;

    private Vector2 _velocity = Vector2.zero;

    void Update()
    {
        var playerPos = player.position;
        var cameraPos = new Vector2 {x = playerPos.x, y = playerPos.y};

        transform.position = Vector2.SmoothDamp(transform.position, cameraPos, ref _velocity, smoothness);
    }
}