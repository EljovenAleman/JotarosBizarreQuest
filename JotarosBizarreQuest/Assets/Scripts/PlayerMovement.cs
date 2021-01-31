using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isWalking = false;
    public float speed;
    float xMov;
    float yMov;
    Rigidbody2D rb;
    public Animator animator;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        yMov = rb.velocity.y;
        rb.velocity = new Vector2(xMov * speed, yMov);

        if(xMov != 0)
        {
            isWalking = true;
            animator.SetBool("Walking", isWalking);
        }
        else
        {
            isWalking = false;
            animator.SetBool("Walking", isWalking);
        }

        
    }
}
