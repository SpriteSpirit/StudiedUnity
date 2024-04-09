using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 2f; // �������� ����������� ���������

    private PlatformShake platformShake; // ������ �� ������ PlatformShake

    void Start()
    {
        platformShake = GetComponent<PlatformShake>(); // �������� ������ �� ������ PlatformShake
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); // ����������� ��������� �����
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            platformShake.Shake(); // �������� ������� ������ ���������
        }
    }
}