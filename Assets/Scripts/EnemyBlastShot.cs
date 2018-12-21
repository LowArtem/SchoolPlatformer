using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlastShot : MonoBehaviour
{

    GameObject player;
    Rigidbody2D rb;
    private float force = 0.5f;
    public static int Enemy_damage = 1;

    [SerializeField]
    GameObject particle;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        transform.localScale = (transform.localScale / 20);

        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.Rotate(0, 0, angle);

            Vector2 BulletForce = new Vector2(dir.x, dir.y);

            rb.AddRelativeForce(BulletForce * force, ForceMode2D.Impulse);
        }
        else
            Destroy(gameObject);
    }

    /* void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        transform.localScale = (transform.localScale / 20);

        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 dir = player.transform.position - transform.position;

            Vector2 BulletForce = new Vector2(dir.x, dir.y);

            rb.AddRelativeForce(BulletForce * speed, ForceMode2D.Impulse);
        }
        else
            Destroy(gameObject);
    } */

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
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
