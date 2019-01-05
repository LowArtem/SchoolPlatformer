using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Controller : MonoBehaviour
{
    Animator animator;
    public GameObject ExplosionParticles;
    public GameObject Boss2;
    public GameObject blast_shot;
    public float delayTime = 0.6f;
    bool canShot = true;
    bool isUp = false;
    bool isDown = true;

    public int Enemy_lives = 20;

    public static float speed = 2.5f;

    void Update()
    {
        if (canShot)
        {
            canShot = false;
            Instantiate(blast_shot, new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z), transform.rotation);
            StartCoroutine(NoFire());
        }

        Move();
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
                Destroy(Boss2.gameObject);
            }
        }
    }



    void Move()
    {
        if (!isUp)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            if (transform.position.y >= 14)
            {
                isUp = true;
                isDown = false;
            }
        }
        
        if (!isDown)
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            if (transform.position.y <= - 14)
            {
                isDown = true;
                isUp = false;
            }
        }
    }
}
