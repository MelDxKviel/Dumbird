using UnityEngine;


public class Player : MonoBehaviour
{
    public float playerSpeed;
    [SerializeField] private GameObject bullet;
    public Rigidbody2D rb;
    public Vector2 playerDirection;
    public Joystick joystick;
    public float fireRate;
    private GameOver gameOverManager;
    private bool _shootCooldown;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameOverManager = GameObject.Find("Game Manager").GetComponent<GameOver>();
    }
    
    void Update()
    {
        float directionY = joystick.Vertical;
        playerDirection = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            gameOverManager.OnGameOver();
        }
    }

    public void Shoot()
    {
        if (!_shootCooldown)
        {
            Vector3 position = transform.position;
            position.x += 1;
            Instantiate(bullet, position, Quaternion.identity);
            _shootCooldown = true;
            Invoke(nameof(ResetShootCooldown), fireRate);
        }
    }
    
    public void ResetShootCooldown()
    {
        _shootCooldown = false;
    }
}