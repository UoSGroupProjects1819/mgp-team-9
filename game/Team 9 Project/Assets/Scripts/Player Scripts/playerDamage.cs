using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    private UIControl UIcontrol;

    void Start()
    {
        currentHealth = maxHealth;
        UIcontrol = GameObject.Find("UIControl").GetComponent<UIControl>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("player dead");
            // to be removed VV only so the console doesn't annoy me too much
            // kill the player, set back to start of level
            UIcontrol.Death();
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