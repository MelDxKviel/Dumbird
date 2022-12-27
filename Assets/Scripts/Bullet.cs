using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 direction;
    
    private float _bulletSpeed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CameraMovement cam = GameObject.Find("Game Manager").GetComponent<CameraMovement>();
        _bulletSpeed = cam.cameraSpeed + 15;
        Destroy(gameObject, 2.5f);
    }

    void Update()
    {
        rb.transform.position += new Vector3(direction.x * _bulletSpeed * Time.deltaTime, direction.y * Time.deltaTime, 0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") & other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}