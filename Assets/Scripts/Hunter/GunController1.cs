using Assets.Scripts.Hunter;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GunController1 : MonoBehaviour
{
    private float sensitivity = 100f;
    private float verticalRange = 45f;
    private float horizontalRange = 15f;


    private float verticalAngle = 45f;  // ��������� ����
    private float horizontalAngle = 15;  // ��������� ����
    private Quaternion camera_rotation;

    [Header("Crosshair")]
    public bool isZoom = false;

    private void Start()
    {
        Quaternion old_camera_rotation = camera_rotation;
        Input.ResetInputAxes();
        Cursor.lockState = CursorLockMode.Locked;   // �������� ������ � ������ ������.
        Cursor.visible = false;                     // �������� ������.
    }

    private void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.visible = false;                 // ��������� ��� ������ �������.
            Cursor.lockState = CursorLockMode.Locked; // �������� ��������� ������.
        }


        // �������� �������� ����
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // ��������� �������������� �������� ���� � �������� ����
        float newRotationY = transform.localEulerAngles.y + mouseX;
        float newRotationZ = transform.localEulerAngles.y + mouseX;

        // ��������� ������������ �������� ���� � �������� ����, � ������ �����������
        verticalAngle -= mouseY;
        verticalAngle = Mathf.Clamp(verticalAngle, -verticalRange, verticalRange);
        horizontalAngle = Mathf.Clamp(horizontalAngle, -horizontalRange, horizontalRange);
 

        // ��������� ����������� �� ��� Y
        if (newRotationY > 180f)
        {
            newRotationY -= 360f;
        }

        // ��������� ����������� �� ��� Y
        newRotationY = Mathf.Clamp(newRotationY, -verticalRange, verticalRange);
        newRotationZ = Mathf.Clamp(newRotationZ, -horizontalRange, horizontalRange);

        // ��������� ��������
        transform.localEulerAngles = new Vector3(0f, newRotationY, newRotationZ);

        // ����� ������
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
