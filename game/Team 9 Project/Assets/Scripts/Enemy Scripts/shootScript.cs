using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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

    public AudioClip shootSound;
    private AudioSource source;

    void Start()
    {
        timeSinceLastShot = 0f;
        bulletType = BulletType.regular;
        getBulletPool();
        bulletPoolLength = bullets.Count;
        source = gameObject.GetComponent<AudioSource>();
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
        timeSinceLastShot += Time.deltaTime;
    }

    private void shootBullet()
    {
        source.PlayOneShot(shootSound);
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
                tempBullet.transform.localEulerAngles = new Vector3(shootLocation.transform.rotation.eulerAngles.x, shootLocation.transform.rotation.eulerAngles.y, shootLocation.transform.rotation.eulerAngles.z);
                tempBullet.transform.position = shootLocation.transform.position;
                tempBullet.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<enemyBasic>().vectorToPlayer.normalized * shootSpeed;
            }
        }
        bulletsShot = 0;
        timeSinceLastShot = 0f - Random.Range(0f, 1f);
    }

    private void getBulletPool()
    {
        if (bulletType == BulletType.regular)
        {
            bullets = GameObject.Find("Regular Bullet Pool").GetComponent<bulletPool>().buildBulletPool();
        }
    }
}