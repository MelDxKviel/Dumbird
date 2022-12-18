using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemies;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawns;
    private float _timeToSpawn;
    public float spawnDelay;

    private bool _isSpawning = true;

    void Update()
    {
        if (Time.timeSinceLevelLoad <= spawnDelay) return;
        if (Time.time >= _timeToSpawn && _isSpawning)
        {
            Spawn();
            _timeToSpawn = Time.time + timeBetweenSpawns;
        }
    }
    

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position + spawnPosition, transform.rotation);
    }

    public void DisableSpawning()
    {
        _isSpawning = false;
    }

    public void DestroyAllEnemies()
    {
        GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in existingEnemies)
        {
            Destroy(enemy);
        }
    }
}