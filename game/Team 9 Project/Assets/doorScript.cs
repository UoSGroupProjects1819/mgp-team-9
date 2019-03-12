using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public bool open;
    public enemySpawnControl EnemySpawnControl;
    public BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnControl = GameObject.Find("Spawner").GetComponent<enemySpawnControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            boxCollider.enabled = false;
            // change the sprite
        }
        else
        {
            StartCoroutine(checkIfWavesEnded());
        }
    }

    private IEnumerator checkIfWavesEnded()
    {
        yield return new WaitForSeconds(0.5f);
        if(EnemySpawnControl.enemyCount == 0)
        {
            open = true;
        }
    }
}