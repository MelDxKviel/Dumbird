using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Player move settings")]
    public float playerSpeed;
    public Rigidbody2D rb;
    public Vector2 playerDirection;
    public Joystick joystick;
    
    [Header("Player shoot settings")]
    public float fireRate;
    [SerializeField] private GameObject bullet;
    
    [Space(10)]
    [SerializeField] private GameObject bubble;
    [SerializeField] private AudioClip deathSound;
    
    private GameOver _gameOverManager;
    private bool _shootCooldown;
    private bool _machineGunBuff;
    private bool _invulnerable;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _gameOverManager = GameObject.Find("Game Manager").GetComponent<GameOver>();
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
        if (col.gameObject.CompareTag("Enemy") && !_invulnerable)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(GameObject.FindWithTag("Audio"));
            _gameOverManager.OnGameOver();
        }
        
        if (col.gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<Score>().IncreaseScore(3);
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.CompareTag("Buff"))
        {
            var buff = col.gameObject.GetComponent<Buff>();
            if (buff.buffType == Buff.BuffType.MachineGun)
            {
                _machineGunBuff = true; 
                fireRate = 0.1f;
            }
            if (buff.buffType == Buff.BuffType.SizeReducing)
            {
                var size = transform.localScale * 0.5f;
                gameObject.transform.localScale = size;
            }
            if (buff.buffType == Buff.BuffType.Invulnerability)
            {
                bubble.SetActive(true);
                _invulnerable = true;
            }
            StartCoroutine(ResetBuff(buff.buffType));
            Destroy(col.gameObject);
            
            if (buff.buffSound)
            {
                AudioSource.PlayClipAtPoint(buff.buffSound, transform.position);
            }
        }
    }

    public void Shoot()
    {
        if (_shootCooldown) return;
        
        var position = transform.position;
        position.x += gameObject.transform.localScale.x;
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
        if (buffType == Buff.BuffType.Invulnerability)
        {
            _invulnerable = false;
            bubble.SetActive(false);
        }
    }

    
}