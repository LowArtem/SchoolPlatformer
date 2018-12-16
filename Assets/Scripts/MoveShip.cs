using UnityEngine;

public class MoveShip : MonoBehaviour
{

    public GameObject Ship;

    public float speed = 4.2f;

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
        }

        if (Input.GetKey(KeyCode.D))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x + speed * Time.deltaTime, Ship.transform.position.y, Ship.transform.position.z);
            Ship.transform.rotation = Quaternion.Euler(0, 0, 0);
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
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Ship.transform.position = new Vector3(Ship.transform.position.x + speed * Time.deltaTime, Ship.transform.position.y, Ship.transform.position.z);
        }
        #endregion
    }
}
