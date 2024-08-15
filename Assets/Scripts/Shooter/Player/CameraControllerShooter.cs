using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerShooter : MonoBehaviour
{
    private float horizontalSpeed = 9f;
    private float verticalSpeed = 9f;

    private float verticalMinAngle = -45f;
    private float verticalMaxAngle = 45f;

    private float rotationX;
    private float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * verticalSpeed;
        rotationX = Mathf.Clamp(rotationX, verticalMinAngle, verticalMaxAngle);

        float delta = Input.GetAxis("Mouse X") * horizontalSpeed;
        rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
