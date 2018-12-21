using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public GameObject blast_shot;
    public GameObject player;

    Animator animator;
    public GameObject ExplosionParticles;

    public float delayTime;

    bool canShoot = true;

    //[HideInInspector]
    public int lives = 3;

    public static bool isDeath = false;

    void Start()
    {
        lives = 3;
    }
    void Update()
    {
        if (canShoot && Input.GetMouseButton(0)) // левая мышь
        {
            canShoot = false;
            Instantiate(blast_shot, new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z), transform.rotation);
            StartCoroutine(NoFire());
        }
    }

    IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        canShoot = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            animator = GetComponent<Animator>();
            animator.Play("Damage");

            lives = lives - EnemyBlastShot.Enemy_damage;

            if (lives <= 0)
            {
                isDeath = true;

                Instantiate(ExplosionParticles, transform.position, transform.rotation);
                lives = 3;
                Destroy(player.gameObject);
            }
        }
    }
}
