using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed;
    private Transform spawner;

    void Start()
    {
        spawner = GameObject.Find("spawner").transform;
    }
    
    void Update()
    {
        Vector3 direction = (spawner.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
