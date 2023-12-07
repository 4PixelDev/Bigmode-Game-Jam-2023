using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpVelocity = 14f;

    private Rigidbody2D rb;
    float moveInput;

    // flip player
    bool facingRight = true;

    [Header("Ground Debug")]
    // Ground Check Parameters
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;

    [Header("Sound")]
    [SerializeField] private AudioSource jumpSound;

    private Animator anim;


    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;


    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerJump();

        // R to restart scene
        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

        anim.SetFloat("yVelocity", rb.velocity.y);
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        PlayerMovement();
    }

    private void PlayerJump()
    {
        if (isGrounded) { coyoteTimeCounter = coyoteTime; }
        else { coyoteTimeCounter -= Time.deltaTime; }

        if (Input.GetKeyDown(KeyCode.UpArrow)) { jumpBufferCounter = jumpBufferTime; }
        if (Input.GetKeyDown(KeyCode.W)) { jumpBufferCounter = jumpBufferTime; }
        if (Input.GetKeyDown(KeyCode.Space)) { jumpBufferCounter = jumpBufferTime; }
        else { jumpBufferCounter -= Time.deltaTime; }


        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);

            jumpBufferCounter = 0f;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);

            jumpBufferCounter = 0f;

        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            jumpBufferCounter = 0f;
        }





        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }



        if (isGrounded == true)
        {
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isJump", true);

        }

    }

    private void PlayerMovement()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


        // run animation condisions
        if (moveInput == 0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
