using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{

    Animator animator;

    public int Enemy_lives;
    GameObject player;
    public GameObject ExplosionParticles;
    public GameObject blast_shot;
    public float delayTime = 0.6f;

    
    bool canShot = true;
    float speed = 4.3f;


    void Update()
    {
        if (canShot)
        {
            canShot = false;
            Instantiate(blast_shot, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            StartCoroutine(NoFire());
        }

        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector2 vectorToPlayer = player.transform.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector2.right, vectorToPlayer);
            transform.position += transform.right * speed * Time.deltaTime;
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
