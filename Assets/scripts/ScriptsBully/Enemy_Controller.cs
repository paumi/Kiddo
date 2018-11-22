﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

    public float maxSpeed = 1f;
    public float speed = 1f;
    public Animator animator;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);


        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f){
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        }

        if (speed > 0) {

            transform.localScale = new Vector3(2.356135f, 2.286112f, 1.354422f);

        }
        else if (speed < 0) {
            transform.localScale = new Vector3(-2.356135f, 2.286112f, 1.354422f);

        }

    }


}
