using UnityEngine;

public class RGBColorChange : MonoBehaviour
{
    float redSpeed = 1f; // �������� ��������� �������� �����.
    float greenSpeed = 1f; // �������� ��������� �������� �����.
    float blueSpeed = 1f; // �������� ��������� ������ �����.

    private Camera camera; // ������ �� ������.

    private void Start()
    {
        camera = GetComponent<Camera>(); // �������� ��������� Camera �� �������.
    }

    private void Update()
    {
        // �������� ���������� RGB ����� ����.
        float red = Mathf.Sin(Time.time * redSpeed) / 2f + 0.5f;
        float green = Mathf.Sin(Time.time * greenSpeed + Mathf.PI * 2f / 3f) / 2f + 0.5f;
        float blue = Mathf.Sin(Time.time * blueSpeed + Mathf.PI * 4f / 3f) / 2f + 0.5f;

        // ������������� ����� ���� ����.
        camera.backgroundColor = new Color(red, green, blue);

        // �������� �������� ��������� ����������� RGB ����� ����.
        redSpeed += Input.GetAxisRaw("Vertical");
        greenSpeed += Input.GetAxisRaw("Vertical");
        blueSpeed += Input.GetAxisRaw("Vertical");
    }
}