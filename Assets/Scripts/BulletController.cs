using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject shooter;
    public GameObject hitEffect;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == shooter)
            return;
        
        var effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}
