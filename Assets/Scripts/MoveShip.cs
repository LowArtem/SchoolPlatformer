using UnityEngine;

public class MoveShip : MonoBehaviour
{

    public GameObject Ship;

    public float speed = 4.2f;

    public static bool isRight = false;
    
    public static bool isLeft = false;


    void Update()
    {

        #region WASD
        if (Input.GetKey(KeyCode.W))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x, Ship.transform.position.y + (speed - 1.5f) * Time.deltaTime, Ship.transform.position.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x, Ship.transform.position.y - (speed - 1.5f) * Time.deltaTime, Ship.transform.position.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x - speed * Time.deltaTime, Ship.transform.position.y, Ship.transform.position.z);
            Ship.transform.rotation = Quaternion.Euler(0, 180, 0);
            isLeft = true;
            isRight = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x + speed * Time.deltaTime, Ship.transform.position.y, Ship.transform.position.z);
            Ship.transform.rotation = Quaternion.Euler(0, 0, 0);
            isRight = true;
            isLeft = false;
        }
        #endregion


        #region ARROW
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x, Ship.transform.position.y + (speed - 1.5f) * Time.deltaTime, Ship.transform.position.z);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x, Ship.transform.position.y - (speed - 1.5f) * Time.deltaTime, Ship.transform.position.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x - speed * Time.deltaTime, Ship.transform.position.y, Ship.transform.position.z);
            Ship.transform.rotation = Quaternion.Euler(0, 180, 0);
<<<<<<< HEAD
            isLeft = true;
            isRight = false;
=======
>>>>>>> 89e05ef5524f4cd764b428225e909acaf6e95b71
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x + speed * Time.deltaTime, Ship.transform.position.y, Ship.transform.position.z);
            Ship.transform.rotation = Quaternion.Euler(0, 0, 0);
<<<<<<< HEAD
            isRight = true;
            isLeft = false;
=======
>>>>>>> 89e05ef5524f4cd764b428225e909acaf6e95b71
        }
        #endregion
    }
}
