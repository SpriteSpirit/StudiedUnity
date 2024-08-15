using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControllerSurvival : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private Vector2 m_Move;
    private Vector2 m_Look;
    private Vector2 m_Rotation;

    // Update is called once per frame
    void Update()
    { 
        Look(m_Look);
        Move(m_Move);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    //public void OnLook(InputAction.CallbackContext context)
    //{
    //    m_Look = context.ReadValue<Vector2>();
    //}

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
        {
            return;
        }
        var scaleMoveSpeed = moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        Debug.Log(move.GetType());
        transform.position += move * scaleMoveSpeed;
    }

    //private void Look(Vector2 rotate)
    //{
    //    if (rotate.sqrMagnitude < 0.01)
    //        return;

    //    var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
    //    m_Rotation.y += rotate.x * scaledRotateSpeed;
    //    m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
    //    transform.localEulerAngles = m_Rotation;
    //}

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        transform.localEulerAngles = m_Rotation;
    }
}
