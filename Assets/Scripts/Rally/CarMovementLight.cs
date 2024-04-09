using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovementLight : MonoBehaviour // ���������� ������ CarMovement, ������������ MonoBehaviour
{
    public float speed; // ��������� ���� ��� �������� ������
    public float maxSpeed; // ������������ �������� ������
    private float rotationSpeed = 100f; // ��������� ���� ��� �������� �������� ������

    [HideInInspector]
    public float acceleration = 20f; // �������� ��������� ��� �������� ������
    public float deceleration = 10f; // �������� ���������� ��� ������� ���������
    public float maxReverseSpeed = -20f; // ������������ �������� �����
    //public float brakeSpeed = 20f; // ���������� �� ������ ���������


    // step2 - check circle
    public GameManager manager;


    public Text textField;


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
        {
            // ���������� � ������������ �������� ������������ ���������
            speed = Mathf.MoveTowards(speed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // ��� ������ �������� �������� 0, �������� ��������� �����
            speed = Mathf.MoveTowards(speed, maxReverseSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // ������� ���������� ��� ���������� ������
            speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
        }



        // ������� ����������
        transform.Rotate(Vector3.up, moveHorizontal * rotationSpeed * Time.deltaTime);
        // ����������� � ��������
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        // ��������� ��������� ���� �� ���������
        textField.text = "SPEED: " + Mathf.Abs((int)speed);

    }

    void OnTriggerEnter(Collider other) // �� ������ �������� Collider � �������� isTrigger
    {
        if (other.CompareTag("Block")) // ������������, ��� � ������ ��� "Player"
        {
            Debug.Log("Block");
            manager.CheckpointReached(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish");
            manager.FinishLineReached(other.gameObject);
        }
    }
}
