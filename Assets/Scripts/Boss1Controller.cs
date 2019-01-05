using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour
{

    Animator animator;

    public double Enemy_lives = 26;
    public GameObject ExplosionParticles;

    public GameObject blast_shot;
    public GameObject Simple_BlastShot;
    public GameObject Circle_BlastShot;
    public float delayTimeSimple = 0.6f;
    public float delayTimeSecond = 0.84f;
    public float delayTimeThird = 0.25f;


    double ConstLives;

    bool canShotSimple = true;
    bool canShotSecond = false;
    bool canShotThird = false;
    bool secondPhase = false;
    bool thirdPhase = false;
    bool isLeft = true;
    bool isRight = false;
    
    private float speed = 2.5f;
    private float Speed_vibration = 2.5f; // Скорость вибрации по синусоиде
    private float magnitude = 2.2f; // Высота синусоиды

    private Vector3 axis; // вектор движения по вертикали
    private Vector3 pos; // вектор движения по горизонтали



    void Start()
    {
        ConstLives = Enemy_lives;

        pos = transform.position;
        axis = transform.up;
    }

    void Update()
    {
        Move();

        if (canShotSimple && !secondPhase && !thirdPhase)
        {
            canShotSimple = false;
            Instantiate(Simple_BlastShot, new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z), transform.rotation);
            StartCoroutine(NoFireSimple());
        }

        if (canShotSecond && secondPhase && !thirdPhase)
        {
            canShotSecond = false;
            Instantiate(blast_shot, new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z), transform.rotation);
            StartCoroutine(NoFireSecond());
        }

        if (canShotThird && thirdPhase && !secondPhase)
        {
            canShotThird = false;
            Instantiate(Circle_BlastShot, new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z), Circle_BlastShot.transform.rotation);
            StartCoroutine(NoFireThird());
        }
    }

    IEnumerator NoFireSimple()
    {
        yield return new WaitForSeconds(delayTimeSimple);
        canShotSimple = true;
    }

    IEnumerator NoFireSecond()
    {
        yield return new WaitForSeconds(delayTimeSecond);
        canShotSecond = true;
    }

    IEnumerator NoFireThird()
    {
        yield return new WaitForSeconds(delayTimeThird);
        canShotThird = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            animator = GetComponent<Animator>();
            animator.Play("Damage");

            Enemy_lives = Enemy_lives - BlastShot.damage;

            if (Enemy_lives <= (ConstLives * 2 / 3))
            {
                secondPhase = true;
                canShotSecond = true;
            }

            if (Enemy_lives <= (ConstLives * 1 / 3))
            {
                secondPhase = false;
                canShotSecond = false;
                thirdPhase = true;
                canShotThird = true;
            }

            if (Enemy_lives <= 0)
            {
                Instantiate(ExplosionParticles, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }



    void Move()
    {
        if (!isRight)
        {
            pos += transform.right * Time.deltaTime * speed;
            transform.position = pos + axis * Mathf.Sin(Time.time * Speed_vibration) * magnitude;

            if (transform.localPosition.x >= 4405)
            {
                isRight = true;
                isLeft = false;
            }
        }

        if (!isLeft)
        {
            pos -= transform.right * Time.deltaTime * speed;
            transform.position = pos + axis * Mathf.Sin(Time.time * Speed_vibration) * magnitude;

            if (transform.localPosition.x <= 2300)
            {
                isLeft = true;
                isRight = false;
            }
        }
    }
}
