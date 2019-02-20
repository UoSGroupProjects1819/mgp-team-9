using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public float shootDelay;
    private float timeSinceLastShot;
    public GameObject[] bullets;

    public bool shooting = false;
    private bool canShoot = true;

    public int shootCount;
    private int bulletsShot;

    private GameObject tempBullet;

    public GameObject shootLocation;

    private int bulletPoolLength;

    void Start()
    {
        timeSinceLastShot = 0f;
        bulletPoolLength = bullets.Length;
    }

    void FixedUpdate()
    {
        if (timeSinceLastShot >= shootDelay)
        {
            // shoot the bullet

            // check object pool for available bullets
            for (int i = 0; i < bulletPoolLength; i++)
            {
                if (bullets[i].gameObject.activeSelf == false && bulletsShot < shootCount)
                {
                    bulletsShot += 1;
                    // now we have found a bullet so shoot, let the other script know we are shooting
                    shooting = true;
                    // grab the bullet instance so we can apply all the correct transform and velocity to ITself
                    tempBullet = bullets[i].gameObject;
                    Debug.Log("bullet go shoot");
                    tempBullet.SetActive(true);
                    // give the bullet the correct velocity
                    tempBullet.transform.localEulerAngles = new Vector3(shootLocation.transform.rotation.eulerAngles.x, shootLocation.transform.rotation.eulerAngles.y, shootLocation.transform.rotation.eulerAngles.z - 90f);
                    tempBullet.transform.position = shootLocation.transform.position;
                    tempBullet.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<enemyBasic>().vectorToPlayer;
                }
            }
            bulletsShot = 0;
            timeSinceLastShot = 0f;
        }
        timeSinceLastShot += Time.deltaTime;
    }
}