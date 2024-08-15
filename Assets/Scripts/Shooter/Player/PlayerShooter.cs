using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    [Header("Movement")]
    private CharacterController controller;

    private float speed = 5f;

    private float gravity = -9.81f;
    private float jumpHeight = 3f;

    private Vector3 velocity;
    private bool grounded;


    [Header("Animator")]
    [HideInInspector]
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Reload");
        }

        // condition ? trueResult : falseResult
        animator.SetBool("isRun", Input.GetKey(KeyCode.W) ? true : false);

        grounded = controller.isGrounded;

        if (grounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * Time.deltaTime * speed);

        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            // вычисление значения, на которое нужно изменить вертикальную скорость,
            // чтобы персонаж "подпрыгнул" на нужную высоту.
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
