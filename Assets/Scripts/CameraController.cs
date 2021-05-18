using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothness = 0.1f;

    private Vector3 _velocity = Vector3.zero;

    void Update()
    {
        var playerPos = player.position;
        var cameraPos = new Vector3 {x = playerPos.x, y = playerPos.y, z = playerPos.z - 10};

        transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref _velocity, smoothness);
    }
}