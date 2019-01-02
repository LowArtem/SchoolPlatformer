using UnityEngine;

public class BlastShot : MonoBehaviour
{

    Rigidbody2D rb;

    public float force = 5f;

    [SerializeField]
    GameObject particle;

    public static int damage = 1;
    Vector3 test_direct;

    bool isRight = false;
    bool isLeft = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 directon = new Vector3(0, 0, 0);

        transform.localScale = (transform.localScale / 20);

        if (MoveShip.isRight)
        {
            directon = new Vector3(force, 0, 0);
        }
        else if (MoveShip.isLeft)
        {
            directon = new Vector3(-force, 0, 0);
        }
        else
        {
            directon = new Vector3(force, 0, 0);
        }

        rb.AddForce(directon, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            Instantiate(particle, transform.position, new Quaternion(0.0f, -1.0f, 0.0f, 0.0f));
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            damage = 1;
        }
        if (other.gameObject.tag == "black_ground")
        {
            if (transform.rotation.y == -1)  // left
            {
                test_direct = new Vector3(force * 2, 0, 0);
                isLeft = true;
                isRight = false;
            }
            else if (transform.rotation.y == 0) // right
            {
                test_direct = new Vector3(-force * 2, 0, 0);
                isRight = true;
                isLeft = false;
            }
            else
            {
                test_direct = new Vector3(-force * 2, 0, 0); // default (right)
                isRight = true;
                isLeft = false;
            }


            if (isRight)  // было right, станет left
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                isRight = false;
                isLeft = true;
            }
            else if (isLeft) // было left, станет right
            {
                isLeft = false;
                isRight = true;
                transform.rotation = Quaternion.Euler(0, 0, 360);
            }

            rb.AddForce(test_direct, ForceMode2D.Impulse);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
