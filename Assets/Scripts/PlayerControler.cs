using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControler : MonoBehaviour
{

    public GameObject blast_shot;
    public GameObject player;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    Animator animator;
    public GameObject ExplosionParticles;
    public GameObject HeartParticles;

    public GameObject Door1;   // ТЕСТОВОЕ ДЛЯ ОСВОБОЖДЕНИЕ БОТОВ ИЗ ВЛЕТКИ УБРАТЬ ПОТОМ
    public GameObject Door2;   // ТЕСТОВОЕ ДЛЯ ОСВОБОЖДЕНИЕ БОТОВ ИЗ ВЛЕТКИ УБРАТЬ ПОТОМ

    public float delayTime;

    bool canShoot = true;

    public int lives = 3;

    public static bool isDeath = false;

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
            Damage(EnemyBlastShot.Enemy_damage);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Damage(1);
        }

        if (other.gameObject.tag == "Heart")
        {
            Healing(1);

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "ButtonOpen") // ТЕСТОВОЕ ДЛЯ ОСВОБОЖДЕНИЕ БОТОВ ИЗ ВЛЕТКИ УБРАТЬ ПОТОМ
        {
            Door1.gameObject.SetActive(false);
            Door2.gameObject.SetActive(false);
        }
    }













    void Damage(int damage)
    {
        animator = GetComponent<Animator>();
        animator.Play("Damage");

        lives = lives - damage;

        if (lives == 2)
        {
            heart3.gameObject.SetActive(false);
        }

        if (lives == 1)
        {
            heart2.gameObject.SetActive(false);
        }

        if (lives <= 0)
        {
            heart1.gameObject.SetActive(false);

            isDeath = true;

            Instantiate(ExplosionParticles, transform.position, transform.rotation);
            Destroy(player.gameObject);
        }
    }

    void Healing(int healing)
    {
        Instantiate(HeartParticles, transform.position, transform.rotation);

        animator = GetComponent<Animator>();
        animator.Play("Heart");

        if (lives < 3)
            lives = lives + healing;

        if (lives == 3)
        {
            heart3.gameObject.SetActive(true);
        }

        if (lives == 2)
        {
            heart2.gameObject.SetActive(true);
        }
    }
}
