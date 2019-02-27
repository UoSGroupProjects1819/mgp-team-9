using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float bulletDamage;


    public float bulletLifeTime;
    private float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        Debug.Log("bullet is moving");
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime >= bulletLifeTime)
        {
            bulletDie();
        }
        else if (this.gameObject.activeSelf == true)
        {
            lifeTime += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))
        {
            bulletDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shield"))
        {
            Debug.Log("hitting shield");
            flipDirection();
        }
    }

    private void flipDirection()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity *= -1;
    }

    private void bulletDie()
    {
        this.gameObject.SetActive(false);
        lifeTime = 0f;
    }
}