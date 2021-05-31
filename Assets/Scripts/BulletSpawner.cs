using System;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private bool isOnPlayer;
    private float ammo;
    private float maxAmmo;

    private void Start()
    {
        if (GetComponentInParent<PlayerController>() != null)
            isOnPlayer = true;
    }

    private void Update()
    {
        if (ammo <= 0)
        {
            
        }
        
        if (isOnPlayer)
        {
            if (!Input.GetButtonDown("Fire1")) return;
            foreach (var point in firePoints)
            {
                Shoot(point);
                ammo--;
            }
        }
        else
        {
            Invoke(nameof(BotShooting), 5f);
        }
        
    }

    private void Shoot(Transform point)
    {
        var bullet = Instantiate(bulletPrefab, point.position, point.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(point.up * bulletForce, ForceMode2D.Impulse);
    }

    private void BotShooting()
    {
        foreach (var point in firePoints)
            Shoot(point);
    }
    
    public void SetAmmoMaxCapacity(int capacity)
    {
        maxAmmo = capacity;
        SetCurrentAmmo(capacity);
    }

    public void SetCurrentAmmo(int current)
    {
        ammo = current;
    }
}
