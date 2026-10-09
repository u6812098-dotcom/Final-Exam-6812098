using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        //float spawnPosX = Random.Range(-spawnRange, spawnRange);
        //float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        //Instantiate(enemyPrefab, new Vector3(spawnPosX, 1, spawnPosZ), enemyPrefab.transform.rotation);
        //Instantiate(enemyPrefab, GenerateSpawnPosition(),enemyPrefab.transform.rotation);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos= new Vector3(spawnPosX, 1, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiestospawn)
    {
        for(int i = 0; i < enemiestospawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
