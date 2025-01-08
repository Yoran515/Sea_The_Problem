using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Rigidbody2D rb;     
    public Animator animator;
    private Vector2 movement;

    private bool IsUp;
    private bool IsDown;
    private bool IsLeft;
    private bool IsRight;
    void Update()
    {
    

        movement = Vector2.zero;
  
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;

            IsUp = true;
            IsDown =false; 
            IsLeft = false; 
            IsRight = false;
          
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
            IsUp = false;
            IsDown = true;
            IsLeft = false;
            IsRight = false;
          
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
            IsUp = false;
            IsDown = false;
            IsLeft = false;
            IsRight = true;
           
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
            IsUp = false;
            IsDown = false;
            IsLeft = true;
            IsRight = false;
          
        }

        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", movement.magnitude > 0);

        animator.SetBool("IsLookingRight", IsRight);
        animator.SetBool("IsLookingLeft", IsLeft);
        animator.SetBool("IsLookingDown", IsDown);
        animator.SetBool("IsLookingUp", IsUp);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
