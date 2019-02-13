﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBasic : MonoBehaviour
{
    private GameObject player;

    public Rigidbody enemyRigidbody;
    public float enemyMoveSpeed;

    private Vector3 vectorToPlayer;
    private bool chasingPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // possibly move this VV when there is an "aggro" (if it exists)
        vectorToPlayer = new Vector3(player.transform.position.x - this.transform.position.x, 0f, player.transform.position.z - this.transform.position.z);
        // move the enemy towards the player
        if (chasingPlayer)
        {
            enemyMove();
        }
        // aim AT the player
        enemyAim();
        // shoot bullet
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chasingPlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chasingPlayer = true;
        }
    }

    private void enemyMove()
    {
        // go to player
        enemyRigidbody.velocity = vectorToPlayer * enemyMoveSpeed;
        // hover around a radius of the player
        // circle the player?
    }

    private void enemyAim()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x - this.transform.position.x, 0f, player.transform.position.z - this.transform.position.z));
        Vector3 aimVector = vectorToPlayer;
    }
}