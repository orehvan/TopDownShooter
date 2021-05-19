using System.Threading;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private void Update()
    {
        if (!Input.GetButtonDown("Fire1"))
            return;
        foreach (var point in firePoints)
            Shoot(point);
    }

    private void Shoot(Transform point)
    {
        var bullet = Instantiate(bulletPrefab, point.position, point.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(point.up * bulletForce, ForceMode2D.Impulse);
    }

}
