using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coin;

    [Header("Spawn position settings")]
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    
    [Header("Spawn time settings")]
    public float timeBetweenSpawnsMin;
    public float timeBetweenSpawnsMax;
    public float spawnDelay;
    
    private float _timeToSpawn;
    
    void Update()
    {
        if (Time.timeSinceLevelLoad <= spawnDelay) return;
        if (Time.time >= _timeToSpawn)
        {
            Spawn();
            _timeToSpawn = Time.time + Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax);
        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Instantiate(coin, spawnPosition + transform.position, Quaternion.identity);
    }
}
