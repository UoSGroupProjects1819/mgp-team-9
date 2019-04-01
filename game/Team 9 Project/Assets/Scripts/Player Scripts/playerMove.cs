﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    public playerDamage playerDamageScript;

    public Rigidbody2D playerRigidbody;
    public float moveModifier;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveModifier;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }

        playerAnimator.SetFloat("Speed", playerRigidbody.velocity.magnitude);
    }
}