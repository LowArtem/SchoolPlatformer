using UnityEngine;

public class BlastShot : MonoBehaviour
{

    Rigidbody2D rb;

    public float force = 5f;

    [SerializeField]
    GameObject particle;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 directon = new Vector3(0, 0, 0);

        if (MoveShip.isRight)
        {
            directon = new Vector3(force, 0, 0);
            transform.localScale = (transform.localScale / 20);
        }
        else if (MoveShip.isLeft)
        {
            directon = new Vector3(-force, 0, 0);
            transform.localScale = (transform.localScale / 20);
        }
        else
        {
            directon = new Vector3(force, 0, 0);
            transform.localScale = (transform.localScale / 20);
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
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
