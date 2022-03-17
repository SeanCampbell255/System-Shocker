using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f; //player move speed
    public float gravity = -9.81f; //player only gravity
    public float groundDistance = 0.4f; //allowable margin for ground check
    public float jumpHeight = 3f; //not force; used as height in calc

    public Transform groundCheck; //transform on bottom of player for ground check

    public LayerMask groundMask; //layer that contains 'ground'; used for jump reset

    public CharacterController controller; //convenient non-physics controller for movement, collisions, etc

    Vector3 velocity; //vector-form velocity used to move player when jumping
    bool isGrounded; //tells if player is on ground for jump reset
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //check from bottom player if ground is in acceptable range to consider grounded

        //if it's grounded want it to stick to ground instead of float 'groundDistance' above it
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        //getting input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //'move' is vector representing 
        Vector3 move = transform.right * x + transform.forward * z;

        //move player toward input direction with 'speed' magnitude
        controller.Move(move * speed * Time.deltaTime);

        //if input jump and isGrounded, move player vertically resisting gravity
        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //updates vertical movement based on gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
