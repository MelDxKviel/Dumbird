using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Enemy prefabs")]
    public List<GameObject> enemies;
    public GameObject boss;
    public int countToAddBoss;

    [Header("Spawn position settings")]
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    
    [Header("Spawn time settings")]
    public float timeBetweenSpawns;
    public float spawnDelay;
    
    private float _timeToSpawn;
    private int _spawnedEnemiesCount;
    private bool _bossSpawned;
    private bool _isSpawning = true;

    void Update()
    {
        if (Time.timeSinceLevelLoad <= spawnDelay) return;
        if (Time.time >= _timeToSpawn && _isSpawning)
        {
            Spawn();
            _spawnedEnemiesCount++;
            _timeToSpawn = Time.time + timeBetweenSpawns;
        }
        if (_spawnedEnemiesCount == countToAddBoss && !_bossSpawned)
        {
            enemies.Add(boss);
            _bossSpawned = true;
        }
    }
    
    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position + spawnPosition, Quaternion.identity);
    }

    public void DisableSpawning()
    {
        _isSpawning = false;
    }
}