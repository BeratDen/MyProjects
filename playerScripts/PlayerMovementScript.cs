using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float gravity = -9.81f;

    public float speed = 3f;
    public float jump = 3f;


    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    public CharacterController characterController;

    Vector3 velocity;

    bool isGorunded;

    void Update()
    {
        isGorunded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGorunded&& velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGorunded)
        {
            velocity.y = Mathf.Sqrt(jump * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }


}
