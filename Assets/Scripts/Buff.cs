using UnityEngine;

public class Buff : MonoBehaviour
{
    public enum BuffType
    {
        MachineGun,
        Invulnerability,
        SizeReducing
    }
    
    public BuffType buffType;
    public Rigidbody2D rb;
    public float amp;
    private float _speed;
    private float _t;
    private float _offset;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CameraMovement cam = GameObject.Find("Game Manager").GetComponent<CameraMovement>();
        _speed = cam.cameraSpeed - 10;
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Border") )
            Destroy(gameObject);
    }

    private void Update()
    {
        _t += Time.deltaTime;
        _offset = Mathf.Sin(_t * 3) * amp;
        rb.transform.position += new Vector3(_speed * Time.deltaTime, _offset);
    }
}
