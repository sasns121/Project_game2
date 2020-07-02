using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    public float VertSpeed = 40f;

    float horizontalMove = 0f;
    public bool Jump = false;
    public bool Crouch = false;

    public float VerticalMove=0f;
    public float distance;
    public LayerMask whatIsLedder;
    public LayerMask whatIsWater;
    public bool IsClimbing;

    public RaycastHit2D hitInfo;
    public RaycastHit2D hitInfo2;

    public Rigidbody2D rb;


    public bool StartJump=true;
    public float StartPosY;
    public float EndPosY;
    public float JumpHieght;
    public CharacterController2D PM;


    public static bool CanMove=true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PM = gameObject.GetComponent<CharacterController2D>();
        CanMove = true;
    }

    private void Update()
    {
        if (CanMove)
        {
            hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLedder);
            hitInfo2 = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsWater);
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            if (Input.GetButtonDown("Jump"))
            {
                Jump = true;
                animator.SetBool("IsJumping", true);
            }
            if (!PM.m_Grounded && StartJump)
            {
                StartPosY = transform.position.y;
                StartJump = false;
            }
            if (Input.GetButtonDown("Crouch"))
            {
                Crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                Crouch = false;
            }
        } 
    }

    public void OnLending()
    {
        if (CanMove)
        {
            animator.SetBool("IsJumping", false);
            EndPosY = transform.position.y;
            StartJump = true;
            JumpHieght = StartPosY - EndPosY;
            if (JumpHieght > 7)
            {
                PlayerCount.hp -= 2;
            }
        }
    }

    public void OnCrouching(bool IsCrouching)
    {
        if (CanMove)
        {
            animator.SetBool("IsCrouching", IsCrouching);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanMove)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, Crouch, Jump);
            Jump = false;

            if (hitInfo.collider != null)
            {
                IsClimbing = true;
                animator.SetBool("IsClimbing", true);
            }
            else
            {
                if (Input.GetButtonDown("Horizontal"))
                {
                    IsClimbing = false;
                }
            }
            if (IsClimbing == true && hitInfo.collider != null)
            {
                VerticalMove = Input.GetAxisRaw("Vertical") * VertSpeed;
                rb.velocity = new Vector2(rb.velocity.x, VerticalMove * Time.fixedDeltaTime);
                rb.gravityScale = 0;

            }
            else if (hitInfo2.collider != null)
            {
                rb.drag = 25f;
            }
            else
            {
                rb.gravityScale = 3;
                animator.SetBool("IsClimbing", false);
            }
        }
    }
        
}
