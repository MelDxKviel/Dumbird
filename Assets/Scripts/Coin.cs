using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _coinSpeed;
    public Rigidbody2D rb;

    public Vector2 bulletDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CameraMovement cam = GameObject.Find("Game Manager").GetComponent<CameraMovement>();
        _coinSpeed = cam.cameraSpeed - 8;
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        rb.transform.position += new Vector3(bulletDirection.x * _coinSpeed * Time.deltaTime, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Border") )
            Destroy(gameObject);
    }
}
