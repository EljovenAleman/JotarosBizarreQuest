using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //animation parameters
    private bool isWalking = false;
    private bool isCrouching = false;
    private bool isStandingUp = false;
    private bool isJumping = false;

    //HitBoxes
    public Collider2D idleCollider;
    public Collider2D crouchingCollider;
    


    public float speed;
    float xMov;
    float yMov;
    Rigidbody2D rb;
    public Animator animator;
    public float jumpForce;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        yMov = rb.velocity.y;
        rb.velocity = new Vector2(xMov * speed, yMov);
        rb.gravityScale = 2;

        if(Input.GetKeyDown(KeyCode.W) && isJumping == false)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("Jumping", isJumping);
        }


        if(Input.GetKeyDown(KeyCode.S))
        {
            idleCollider.enabled = false;
            crouchingCollider.enabled = true;
            isCrouching = true;
            isStandingUp = false;

            animator.SetBool("Crouching", isCrouching);
            animator.SetBool("StandingUp", isStandingUp);
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            idleCollider.enabled = true;
            crouchingCollider.enabled = false;
            isStandingUp = true;
            isCrouching = false;

            animator.SetBool("Crouching", isCrouching);
            animator.SetBool("StandingUp", isStandingUp);
        }
        



        if(xMov != 0)
        {
            isWalking = true;
            isCrouching = false;
            animator.SetBool("Walking", isWalking);
            animator.SetBool("Crouching", isCrouching);
        }
        else
        {
            isWalking = false;
            animator.SetBool("Walking", isWalking);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Level")
        {
            isJumping = false;
            animator.SetBool("Jumping", isJumping);
        }
    }
}
