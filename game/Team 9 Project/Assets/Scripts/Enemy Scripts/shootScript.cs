using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public float shootDelay;
    [Range(0, 1)]
    public float shootChancePerFrame;
    public float shootSpeed;
    private float timeSinceLastShot;
    private List<GameObject> bullets = new List<GameObject>();

    public enum BulletType
    {
        regular,
        rebound
    };

    public BulletType bulletType;

    [HideInInspector]
    public bool shooting = false;
    [HideInInspector]
    public bool canShoot = true;

    public int shootCount;
    private int bulletsShot;

    private GameObject tempBullet;

    public GameObject shootLocation;

    private int bulletPoolLength;

    void Start()
    {
        timeSinceLastShot = 0f;
        bulletType = BulletType.regular;
        getBulletPool();
        bulletPoolLength = bullets.Count;
    }

    void FixedUpdate()
    {
        // Random Shooting
        if (!canShoot)
        {
            if (Random.Range(0, 100) < shootChancePerFrame)
            {
                shootBullet();
            }
        }

        if (timeSinceLastShot >= shootDelay && canShoot)
        {
            // shoot the bullet
            shootBullet();
        }       
    }

    private void shootBullet()
    {
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
                //Debug.Log("bullet go shoot");
                tempBullet.SetActive(true);
                // give the bullet the correct velocity
                tempBullet.transform.localEulerAngles = new Vector3(shootLocation.transform.rotation.eulerAngles.x, shootLocation.transform.rotation.eulerAngles.y, shootLocation.transform.rotation.eulerAngles.z - 90f);
                tempBullet.transform.position = shootLocation.transform.position;
                tempBullet.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<enemyBasic>().vectorToPlayer.normalized * shootSpeed;
            }
        }
        bulletsShot = 0;
        timeSinceLastShot = 0f;
        timeSinceLastShot += Time.deltaTime;
    }

    private void getBulletPool()
    {
        if (bulletType == BulletType.regular)
        {
            bullets = GameObject.Find("Regular Bullet Pool").GetComponent<bulletPool>().buildBulletPool();
        }
    }
}