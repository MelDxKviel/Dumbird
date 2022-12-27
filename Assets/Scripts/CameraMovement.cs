using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public float speedUp;

    public float timeBetweenSpeedUp;
    private float _timeToSpeedUp;


    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        if (Time.time >= _timeToSpeedUp)
        {
            cameraSpeed += speedUp;
            _timeToSpeedUp = Time.time + timeBetweenSpeedUp;
        }
    }
    
    private void Start()
    {
        _timeToSpeedUp = timeBetweenSpeedUp;
    }

}