﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBlastShotSimple : MonoBehaviour
{

    GameObject player;
    Rigidbody2D rb;
    private float force = 3f;
    public static int Enemy_damage = 1;

    [SerializeField]
    GameObject particle;


    Vector2 BulletForce;
    Vector3 test_direct;
    bool isRight = false;
    bool isLeft = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        transform.localScale = (transform.localScale / 20);

        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 dir = player.transform.position - transform.position;



            if (dir.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                BulletForce = new Vector3(-force, 0, 0);

            }
            else if (dir.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 360);
                BulletForce = new Vector3(force, 0, 0);

            }



            rb.AddForce(BulletForce * force, ForceMode2D.Impulse);
        }
        else
            Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            Instantiate(particle, transform.position, new Quaternion(0.0f, -1.0f, 0.0f, 0.0f));
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "black_ground")
        {
            if (transform.rotation.y == -1)  // left
            {
                test_direct = new Vector3(force * BulletForce.x * 2, 0, 0);
                isLeft = true;
                isRight = false;
            }
            else if (transform.rotation.y == 0) // right
            {
                test_direct = new Vector3(-force * BulletForce.x * 2, 0, 0);
                isRight = true;
                isLeft = false;
            }
            else
            {
                test_direct = new Vector3(-force * BulletForce.x * 2, 0, 0); // default (right)
                isRight = true;
                isLeft = false;
            }


            if (isRight)  // было right, станет left
            {
                transform.rotation = Quaternion.Euler(0, 0, 360);
                isRight = false;
                isLeft = true;
            }
            else if (isLeft) // было left, станет right
            {
                isLeft = false;
                isRight = true;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            rb.AddForce(test_direct, ForceMode2D.Impulse);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
