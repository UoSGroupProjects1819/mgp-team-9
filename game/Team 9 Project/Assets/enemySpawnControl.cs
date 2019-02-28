using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnControl : MonoBehaviour
{

    public float spawnTime;
    public int maxEnemyCount;
    public int enemyCount;
    public GameObject enemy;

    public GameObject[] spawnPoints;

    private bool canSpawnEnemy = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countdownToNextWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnEnemy && enemyCount < maxEnemyCount)
        {
            StartCoroutine(countdownToNextWave());
        }
    }

    private IEnumerator countdownToNextWave()
    {
        canSpawnEnemy = false;
        yield return new WaitForSeconds(spawnTime);
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        enemyCount += 1;
        canSpawnEnemy = true;
    }
}
