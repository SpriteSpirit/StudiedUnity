using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour // ���������� ������ CarMovement, ������������ MonoBehaviour
{
    public float speed; // ��������� ���� ��� �������� ������
    public float maxSpeed; // ������������ �������� ������
    private float rotationSpeed = 100f; // ��������� ���� ��� �������� �������� ������

    [HideInInspector]
    public float acceleration = 20f; // �������� ��������� ��� �������� ������
    public float deceleration = 10f; // �������� ���������� ��� ������� ���������
    public float maxReverseSpeed = -20f; // ������������ �������� �����
    public float brakeSpeed = 20f; // ���������� �� ������ ���������

    public float driftForce; // ����������� ����������� ���������� �� ����� ������

    public Rigidbody rb;

    // step2 - check circle
    public GameManager manager;
    // step3 - nitro
    public float nitroAmount = 100f; // ��������� ���������� �����
    public float nitroConsumption = 40f; // ������� ����� ������������ �� ���������
    public float nitroRechargeRate = 5f; // �������� �������������� �����

    public float nitroBoost = 2f;       // ����������� ���������� �������� ��� �����
    public float nitroDuration = 3f;    // ����������������� �����
    public float nitroCooldown = 5f;    // ����� �� ����������� ����� (�������)

    private float nitroEndTime = 0f;    // ����� ��������� �����
    private float nextNitroTime = 0f;   // �����, ����� ����� ����� ����� ��������

    public Text textField;
    public Slider nitroSlider;

    public TrailRenderer trailLeft;
    public TrailRenderer trailRight;


    void Start()
    {
        // ������������� Slider. �� ������������� ������������ � ������� �������� ��� ������ ����
        nitroSlider.maxValue = nitroAmount;
        nitroSlider.value = nitroAmount;
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        bool isBraking = false;
        bool handbrake = Input.GetKey(KeyCode.Space);

        if (Input.GetKey(KeyCode.W))
        {
            // ���������� � ������������ �������� ������������ ���������
            speed = Mathf.MoveTowards(speed, maxSpeed, acceleration * Time.deltaTime);

            // ����� ���������, ��� �� �� ���������� �����, ���� ���������� ������
            if (speed < 0)
            {
                speed = Mathf.MoveTowards(speed, 0, brakeSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (speed > 0)
            {
                // ���� �� ��������� ������ � ������ S, �� �������� ����������� ����������
                isBraking = true;
                speed = Mathf.MoveTowards(speed, 0, brakeSpeed * Time.deltaTime);

            }
            else
            {
                // ��� ������ �������� �������� 0, �������� ��������� �����
                speed = Mathf.MoveTowards(speed, maxReverseSpeed, acceleration * Time.deltaTime);
            }
        }
        else if (!isBraking)
        {
            // ������� ���������� ��� ���������� ������
            speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
        }


        // ������� ����������
        transform.Rotate(Vector3.up, moveHorizontal * rotationSpeed * Time.deltaTime);
        // ����������� � ��������
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            trailLeft.time = 0.5f;
            trailRight.time = 0.5f;
            rb.AddForce(transform.right * driftForce, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            trailLeft.time = 0;
            trailRight.time = 0;
        }

        // ��������� ��������� ���� �� ���������
        textField.text = "SPEED: " + Mathf.Abs((int)speed);

        // ������ �� ������
        // �������� ��� ������� W ��� �������� ��������


        // step3
        // ��������� ����������� ��������� �����
        if (Input.GetKeyDown(KeyCode.V) && Time.time > nextNitroTime && nitroAmount >= 100f)
        {
            ActivateNitro();
        }

        if (nitroBoost > 1) // ����� ����� �������
        {
            nitroAmount -= nitroConsumption * Time.deltaTime; // ���������� �����
        }
        else if (Time.time >= nextNitroTime && nitroAmount < 100f) // ����� ����� � cooldown, ��� �����������������
        {
            nitroAmount += nitroRechargeRate * Time.deltaTime; // ��������������� �����
        }

        nitroAmount = Mathf.Clamp(nitroAmount, 0, 100f); // ��������, ��� �������� ����� �� ������ �� �����
        nitroSlider.value = nitroAmount; // ��������� �������� Slider

        // ���� ����� ����� �������, ���������� �������� �� �������
        if (nitroBoost > 1 && Time.time > nextNitroTime) // ���������, ��� ����� ������� (nitroBoost > 1) � ����� �������
        {
            speed /= nitroBoost; // ���������� ������� ��������
            nitroBoost = 1; // ���������� ����������� ���������
        }
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

    void ActivateNitro()
    {
        // ���������, ��� ����� �� ������� ��� (nitroBoost == 1) � ��� � �������� ���� cooldown
        if (nitroBoost == 1 && Time.time >= nextNitroTime)
        {
            nitroBoost = 2f;
            speed *= nitroBoost; // ����������� ��������
            nitroAmount -= nitroConsumption;

            // ��������� ����� ��������� ����� � ���������� ���������� �������������
            nitroEndTime = Time.time + nitroDuration;
            nextNitroTime = Time.time + nitroDuration + nitroCooldown;
            
            Debug.Log("����� ������������!");
        }
    }

    IEnumerator timer()
    {
        for (int i = 4; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.5f);
            trailLeft.time = i / 10;
            trailRight.time = i / 10;
        }
    }
}
