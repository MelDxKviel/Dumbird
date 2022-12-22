using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coin;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawnsMin;
    public float timeBetweenSpawnsMax;
    private float _timeToSpawn;
    public float spawnDelay;
    
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
