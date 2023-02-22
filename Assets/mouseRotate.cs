using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRotate : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
       transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

    }
}
