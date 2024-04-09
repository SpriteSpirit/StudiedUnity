using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] float speed = 30f;

    void Start()
    {
        
    }

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal"); // left -1| right 1
        float yAxis = Input.GetAxis("Vertical");

        Vector3 position = transform.position; // ��������� �������� ������� �������
        position.x += xAxis * speed * Time.deltaTime; // �������� ������� ������� �� ��������� ���*��������
        position.y += yAxis * speed * Time.deltaTime;
        transform.position = position;
        
    }
}
