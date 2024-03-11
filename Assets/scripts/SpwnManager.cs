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
    public int enemiesInScene;
    public int enemiesPerWave = 1;
    private PlayerController gameOverScript;
    private UImanager UimanagerScript;


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
        UimanagerScript.UpdateEnemiesText(enemiestoSpawn, enemiestoSpawn);
        SpawnPowerUp();
        Debug.Log(enemiestoSpawn);
       
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
        if(gameOverScript.isGameOver == false && gameOverScript.hasPowerUp == false )
        {
            Instantiate(powerUp, RandomSpawnPos(), Quaternion.identity);
        }

        
    }
    //----------------------------------------------
    private void Start()
    {
       
       
        //InvokeRepeating("SpawnPowerUp", startDelay, timeDelay);
        gameOverScript = FindObjectOfType<PlayerController>();
        SpawnEnemiesWave(enemiesPerWave);
        UimanagerScript = FindObjectOfType<UImanager>();
    }
    private void Update()
    {
        if (enemiesInScene <= 0)
        {
            enemiesPerWave++;
            SpawnEnemiesWave(enemiesPerWave);

        }
    }


    public void actuazilarTexto()
    {
        Debug.Log(enemiesInScene);
        Debug.Log(enemiesPerWave);

        UimanagerScript.UpdateEnemiesText(enemiesInScene, enemiesPerWave);

    }





}
