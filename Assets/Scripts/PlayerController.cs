using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;
    public float currentAmmo;
    public float maxAmmo = 20;
    public float moveSpeed;
    
    public Rigidbody2D rb;
    public Camera cam;
    public FillBar healthBar;
    public FillBar ammoBar;
    public GameObject enemyProjectile;

    private BulletSpawner shooter;
    private Vector2 moveDirection;
    private Vector2 mousePos;

    private void Start()
    {
        shooter = GetComponent<BulletSpawner>();
        
        currentHealth = maxHealth;
        healthBar.SetMaxValue(maxHealth);

        currentAmmo = maxAmmo;
        ammoBar.SetMaxValue(maxAmmo);
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == enemyProjectile)
            TakeDamage(10);
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetValue(currentHealth);
    }

    #region Controls
    
    private void ProcessInputs()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            Debug.Log(currentHealth);
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        transform.position = rb.position;
    }

    private void Rotate()
    {
        var lookDirection = mousePos;
        var mouseAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = mouseAngle;
    }
    
    #endregion
}
