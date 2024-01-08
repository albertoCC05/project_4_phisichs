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


    private Vector3 RandomSpawnPos()
    {
        float randomX = Random.Range(spawnPosX, -spawnPosX);
        float randomZ = Random.Range(spawnPosZ, -spawnPosZ);

        return new Vector3(randomX, 0, randomZ);
        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, RandomSpawnPos(), Quaternion.identity);
    }
     private void SpawnPowerUp()
    {
        Instantiate(powerUp, RandomSpawnPos(), Quaternion.identity);
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, timeDelay);
        InvokeRepeating("SpawnPowerUp", startDelay, timeDelay);
    }




}
