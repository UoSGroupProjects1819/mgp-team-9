using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    private UIControl UIcontrol;

    public AudioClip deathSound;
    private AudioSource source;

    void Start()
    {
        currentHealth = maxHealth;
        UIcontrol = GameObject.Find("UIControl").GetComponent<UIControl>();
        source = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            // kill the player, set back to start of level
            UIcontrol.Death();
            source.PlayOneShot(deathSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // take health away from the player
            currentHealth -= collision.gameObject.GetComponent<bulletScript>().bulletDamage;
        }
    }
}