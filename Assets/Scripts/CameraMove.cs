using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Ship;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Ship.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Ship.transform.position + offset;
    }
}