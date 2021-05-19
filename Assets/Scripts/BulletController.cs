using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject hitEffect;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}
