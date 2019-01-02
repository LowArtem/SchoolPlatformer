using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleShot : MonoBehaviour {

	GameObject player;
    Rigidbody2D rb;
    private float force = 0.7f;
    public static int Enemy_damage = 1;


    Vector2 BulletForce;
    Vector3 test_direct;


	void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        transform.localScale = (transform.localScale / 20);

        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 dir = player.transform.position - transform.position;

            BulletForce = new Vector2(dir.x, dir.y);

            rb.AddRelativeForce(BulletForce * force, ForceMode2D.Impulse);
        }
        else
            Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
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
