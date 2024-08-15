using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 20;
    [SerializeField] PlayerMovementRunner playerScript;

    void Update()
    {
        if (!playerScript.gameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
