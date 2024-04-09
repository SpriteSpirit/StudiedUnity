using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformShake : MonoBehaviour
{
    public float shakeIntensity = 0.1f; // ������������� ������ ���������
    public float shakeDuration = 0.5f; // ������������ ������ ���������
    public float fallForce = 100f; // ����, � ������� ��������� ����� ������������

    private bool shaking = false; // ����, �����������, �������� �� ��� ���������

    private Vector3 initialPosition; // �������� ������� ���������

    void Start()
    {
        initialPosition = transform.position; // ��������� �������� ������� ���������
    }

    void Update()
    {
        if (shaking)
        {
            // ���������� ��������� �������� � �������� ������������� ������
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;

            // ��������� �������� � ������� ���������
            transform.position = initialPosition + shakeOffset;

            // ��������� ������������ ������ � ������ �����������
            shakeDuration -= Time.deltaTime;

            // ���� ������ �����������, ��������� ������ � ���������� ���������
            if (shakeDuration <= 0f)
            {
                shaking = false;
                Fall();
            }
        }
    }

    void Fall()
    {
        // ��������� ��������� ���������
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;

        // ��������� ����, ����� ��������� ����������
        GetComponent<Rigidbody>().AddForce(Vector3.down * fallForce);
    }

    public void Shake()
    {
        if (!shaking)
        {
            shaking = true;
            initialPosition = transform.position; // ��������� ������� ������� ��������� ����� �������
        }
    }
}