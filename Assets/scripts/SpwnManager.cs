using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpwnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject powerUp;
    private float spawnPosX = 6f;
    private float spawnPosZ = 9f;
    private float timeDelay = 7;
    private float startDelay = 2;
    private int enemiesInScene;
    private int enemiesPerWave = 1;


    private Vector3 RandomSpawnPos()
    {
        float randomX = Random.Range(spawnPosX, -spawnPosX);
        float randomZ = Random.Range(spawnPosZ, -spawnPosZ);

        return new Vector3(randomX, 0, randomZ);
        
    }

    private void SpawnEnemiesWave(int enemiestoSpawn)
    {
        for (int i = 0; i < enemiestoSpawn; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, RandomSpawnPos(), Quaternion.identity);
        enemiesInScene++;
    }

    public void EnemmyDestry()
    {
        enemiesInScene--;
    }

     private void SpawnPowerUp()
    {
        Instantiate(powerUp, RandomSpawnPos(), Quaternion.identity);
    }
    //----------------------------------------------
    private void Start()
    {
        SpawnEnemiesWave(enemiesPerWave);
        InvokeRepeating("SpawnPowerUp", startDelay, timeDelay);
    }
    private void Update()
    {
        if (enemiesInScene <= 0)
        {
            enemiesPerWave++;
            SpawnEnemiesWave(enemiesPerWave);

        }
    }








}
