using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public float shootDelay;
    private float timeSinceLastShot;
    public GameObject[] bullets;

    private GameObject tempBullet;

    private int bulletPoolLength;

    void Start()
    {
        timeSinceLastShot = 0f;
        bulletPoolLength = bullets.Length;
    }

    void Update()
    {
        if (timeSinceLastShot >= shootDelay)
        {
            // shoot the bullet

            // check object pool for available bullets
            for (int i = 0; i < bulletPoolLength; i++)
            {
                if (bullets[i].gameObject.activeSelf == false)
                {
                    tempBullet = bullets[i].gameObject;
                    Debug.Log("bullet go shoot");
                    tempBullet.SetActive(true);
                    // give the bullet the correct velocity
                    tempBullet.transform.rotation = transform.rotation;
                    tempBullet.transform.position = transform.position;
                    tempBullet.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<enemyBasic>().vectorToPlayer;
                }
            }
            timeSinceLastShot = 0f;
        }


        timeSinceLastShot += Time.deltaTime;
    }
}
