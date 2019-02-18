using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public float shootDelay;
    private float timeSinceLastShot;
    public GameObject[] bullets;

    public bool shooting;

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
            shooting = true;
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
                    tempBullet.transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 90f);
                    Debug.Log(transform.rotation.eulerAngles.z);
                    tempBullet.transform.position = transform.position;
                    tempBullet.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<enemyBasic>().vectorToPlayer;
                }
            }
            timeSinceLastShot = 0f;
        }


        timeSinceLastShot += Time.deltaTime;
    }
}
