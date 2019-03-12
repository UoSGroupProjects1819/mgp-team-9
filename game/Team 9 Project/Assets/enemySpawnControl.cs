using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnControl : MonoBehaviour
{

    public float numberOfWaves;
    public float enemiesPerWave;

    public enum spawnType
    {
        time,
        enemyCount,
    };

    public spawnType SpawnType;

    public float spawnTime;
    public int maxEnemyCount;
    public int enemyCount;
    public GameObject enemy;

    public GameObject[] spawnPoints;

    private bool canSpawnEnemy = true;

    // Start is called before the first frame update
    void Start()
    {
        if (SpawnType == spawnType.time)
        {
            StartCoroutine(countdownToNextWave());
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnType == spawnType.enemyCount)
        {
            if (enemyCount == 0)
            {
                if (canSpawnEnemy)
                {
                    spawnWave();
                    StartCoroutine(countdownToNextWave());
                }
            }
        }
        else if (canSpawnEnemy && enemyCount < maxEnemyCount)
        {
            StartCoroutine(countdownToNextWave());
        }
    }

    private void spawnEnemy()
    {
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        enemyCount += 1;
    }

    private void spawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            spawnEnemy();
        }
    }

    private IEnumerator countdownToNextWave()
    {
        canSpawnEnemy = false;
        yield return new WaitForSeconds(spawnTime);
        canSpawnEnemy = true;
    }
}
