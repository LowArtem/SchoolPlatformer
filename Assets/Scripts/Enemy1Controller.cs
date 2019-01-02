using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{

    Animator animator;

    public int Enemy_lives = 15;
    public GameObject ExplosionParticles;
    public GameObject blast_shot;
    public float delayTime = 0.6f;


    bool canShot = true;


    void Update()
    {
        if (canShot)
        {
            canShot = false;
            Instantiate(blast_shot, new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z), transform.rotation);
            StartCoroutine(NoFire());
        }
    }

    IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        canShot = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            animator = GetComponent<Animator>();
            animator.Play("Damage");

            Enemy_lives = Enemy_lives - BlastShot.damage;

            if (Enemy_lives <= 0)
            {
                Instantiate(ExplosionParticles, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
