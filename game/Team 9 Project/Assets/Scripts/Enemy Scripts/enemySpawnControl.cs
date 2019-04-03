using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnControl : MonoBehaviour
{

    public float numberOfWaves;
    private float waveNumber = 0;
    public bool enemiesMustBeDead = true;
    public float enemiesPerWave;

    public enum spawnType
    {
        waves,
        enemyCount,
    };

    public spawnType SpawnType;

    public float spawnTime;
    public int maxEnemyCount;
    public int enemyCount;
    public GameObject enemy;

    public GameObject[] spawnPoints;

    private bool canSpawnEnemy = true;
    private BoxCollider2D roomArea;
    private bool roomEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        roomArea = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roomEntered)
        {
            if (SpawnType == spawnType.enemyCount)
            {
                if (enemyCount < maxEnemyCount)
                {
                    if (canSpawnEnemy)
                    {
                        spawnEnemy();
                        StartCoroutine(countdownToNextWave());
                    }
                }
            }
            else if (SpawnType == spawnType.waves)
            {
                if (enemiesMustBeDead)
                {
                    if (enemyCount != 0)
                    {
                        canSpawnEnemy = false;
                    }
                }
                if (canSpawnEnemy && waveNumber < numberOfWaves)
                {
                    spawnWave();
                    StartCoroutine(countdownToNextWave());
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered room");
            roomEntered = true;
        }
    }

    private void spawnEnemy()
    {
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        enemyCount += 1;
    }

    private void spawnWave()
    {
        waveNumber += 1;
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
