using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f; 

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {   
        // Physics.CheckSphere returns T/F if the groundCheck.position(x, y, z) has a radius of groundDistance and that sphere collide with groundMask.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // if isGrounded and velocity should be less than 0 because if our player tries to jump its velocity will be positive and when it is grounded its velocity will be -2f. 
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        // Vector3 move = new Vector3(x, 0f, z); would make the player move globally and not where the player is facing.
        Vector3 move = transform.forward * z + transform.right * x;

        // controller should move with speed of 12f respective of time not frame.
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // velocity.y is used because our velocity is a vector of form (x, y, z).
        velocity.y += gravity * Time.deltaTime;

        // del y = 1/2[g(t^2)] therefor controller.move should with a velocity(gravity X time) of 9.8 int multiplied by time, we didnt account for constant k=1/2.
        controller.Move(velocity * Time.deltaTime);
    }
}
