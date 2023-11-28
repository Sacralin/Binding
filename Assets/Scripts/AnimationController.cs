using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            // Walking forward
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isWalkingForward", true);
            }
            if (!Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isWalkingForward", false);
            }

            // Running forward
            if (Input.GetKey(KeyCode.LeftShift))
            {
                CharacterMovement characterMovement = GetComponent<CharacterMovement>();
                if (Input.GetKey(KeyCode.W) && characterMovement.canSprint)
                {
                    animator.SetBool("isRunningForward", true);
                }
                if (!Input.GetKey(KeyCode.W))
                {
                    animator.SetBool("isRunningForward", false);
                }
            }
            else
            {
                
            }
            

            // Walking Backward
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalkingBack", true);
            }
            if (!Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalkingBack", false);
            }
            
            // Walking Left
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isWalkingLeft", true);
            }
            if (!Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isWalkingLeft", false);
            }
            
            // Walking Right
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isWalkingRight", true);
            }
            if (!Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isWalkingRight", false);
            }
        }
    }
}
