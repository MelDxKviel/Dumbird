using System.Collections;
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
    private bool _machineGunBuff;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameOverManager = GameObject.Find("Game Manager").GetComponent<GameOver>();
    }
    
    void Update()
    {
        float directionY = joystick.Vertical;
        playerDirection = new Vector2(0, directionY).normalized;
        if (_machineGunBuff)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
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
        
        if (col.gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<Score>().IncreaseScore(3);
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.CompareTag("Buff"))
        {
            var buffType = col.gameObject.GetComponent<Buff>().buffType;
            if (buffType == Buff.BuffType.MachineGun)
            {
                _machineGunBuff = true; 
                fireRate = 0.1f;
                
            }
            if (buffType == Buff.BuffType.SizeReducing)
            {
                var size = transform.localScale * 0.5f;
                gameObject.transform.localScale = size;
            }
            StartCoroutine(ResetBuff(buffType));
            Destroy(col.gameObject);
        }
    }

    public void Shoot()
    {
        if (_shootCooldown) return;
        
        var position = transform.position;
        position.x += 1;
        Instantiate(bullet, position, Quaternion.identity);
        _shootCooldown = true;
        Invoke(nameof(ResetShootCooldown), fireRate);
    }
    
    public void ResetShootCooldown()
    {
        _shootCooldown = false;
    }
    
    IEnumerator ResetBuff(Buff.BuffType buffType)
    {
        yield return new WaitForSeconds(10);
        if (buffType == Buff.BuffType.MachineGun)
        {
            _machineGunBuff = false;
            fireRate = 0.5f;
        }
        if (buffType == Buff.BuffType.SizeReducing)
        {
            var size = transform.localScale * 2f;
            gameObject.transform.localScale = size;
        }
    }

    
}