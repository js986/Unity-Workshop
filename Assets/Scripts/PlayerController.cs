using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.8f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public CharacterController controller;
    public LayerMask groundMask;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float vertical = Input.GetAxis("Vertical");
        float horiztonal = Input.GetAxis("Horizontal");
        Vector3 moveDirectionX = transform.forward * vertical;
        Vector3 moveDirectionZ = transform.right * horiztonal;

        Vector3 direction = moveDirectionX + moveDirectionZ;
        Vector3 distance = direction * speed * Time.deltaTime;

        controller.Move(distance);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
