using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{

    public float movementSpeed = 3.0f;
    public float rotationSpeed = 100.0f;
    public float jumpForce = 5.0f;

    private float gravity = -9.81f; // Earth's gravity
    private CharacterController characterController;
    private Vector3 velocity;
    private float horizontal;
    private float vertical;

    public bool canRotateWithMouse = false;
    public bool canRotate = false;
    public bool canSprint = false;
    public bool canJump = false;
    public bool canMoveWhileJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(0, 0, vertical).normalized;

        
        
        if (canRotate)
        {
            
            
                if (canRotateWithMouse || canMoveWhileJumping)
                {

                    MouseRotation();
                    Strafe();
                }
                else
                {
                    KeyboardRotation();
                }
            
        }
        else
        {
            Strafe();
        }

        

        if (canJump)
        {
            Jump();
        }
        


        // Move the character 
        if (direction.magnitude >= 0.1f)
        {

            if (Input.GetKey(KeyCode.LeftShift) && canSprint)
            {
                movementSpeed = 6.0f;
            }
            else
            {
                movementSpeed = 3.0f;
            }


            if (vertical >= 0)
            {
                characterController.Move(transform.forward * vertical * movementSpeed * Time.deltaTime);
            }
            else
            {
                // Walking backwards
                characterController.Move(-transform.forward * -vertical * movementSpeed * Time.deltaTime);
                
            }
        }


        //apply gravity
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void KeyboardRotation()
    {
        
        //Rotate the character // uses A & D to rotate the character around a point... like resident evil 1 (cannot be used with strafe)
        if (horizontal != 0)
        {
            transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
        }
    }

    public void MouseRotation()
    {
        float horizontalSpeed = 2.0F;
        //float verticalSpeed = 2.0F;
    
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);
    }

    public void Strafe() // cannot be used with KeyboardRotation()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(transform.right * horizontal * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            characterController.Move(-transform.right * -horizontal * movementSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(transform.up * jumpForce * Time.deltaTime);
        }
    }

    public void FaceDirection()
    {

    }



}

