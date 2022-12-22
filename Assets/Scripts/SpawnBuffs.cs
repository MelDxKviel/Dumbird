using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBuffs : MonoBehaviour
{
    public List<GameObject> buffs;

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
            _timeToSpawn = Time.time + Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax);
            Spawn();
        }
    }
    

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Instantiate(buffs[Random.Range(0, buffs.Count)], transform.position + spawnPosition, Quaternion.identity);
    }
}
