using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public bool melt = false;
    

    public float xSpeed = 40f;
    float xMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        if (melt == false)
        {
            xMove = Input.GetAxisRaw("Horizontal") * xSpeed;
            animator.SetFloat("Speed", Mathf.Abs(xMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }

        }
        
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // This is where we move the character
        controller.Move(xMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
