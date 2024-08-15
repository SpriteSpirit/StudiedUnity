using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 1.0f; // Скорость перемещения
        float distance = Vector3.Distance(enemy.position, transform.position);
        Vector3 movement = transform.forward * distance * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        transform.LookAt(enemy.position);
    }
}
