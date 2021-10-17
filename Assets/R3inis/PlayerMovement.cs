using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acseleration;
    [Range(0,1)]
    public float friction;
    Rigidbody2D rb;

    public float jumpForce;
    [Range(0, 1)]
    public float jumpCutoff;
    public float maxYSpeed;
    [HideInInspector]
    public bool isGrounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Vector2 checkSize;

    bool isDashing;
    [HideInInspector]
    public bool canDash;
    public float dashTime;
    float dashTime_;
    public float dashSpeed;

    public int cayoty;
    int cayotyTimer;
    public int remember;
    int rememberTimer;

    Animator anim;
    [HideInInspector]
    public bool jumpTrigger = false;


    //Get veriables
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //Animation/jumping
    private void Update()
    {
        jumpTrigger = false;
        anim.SetFloat("SpeedY", rb.velocity.y);
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("isDashing", isDashing);

        if (rb.velocity.x > 0.2)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (rb.velocity.x < -0.2)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        cayotyTimer--;
        rememberTimer--;

        if(Input.GetButtonDown("Jump"))
        {
            cayotyTimer = cayoty;
        }
        if(isGrounded)
        {
            rememberTimer = remember;
            canDash = true;
        }

        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkSize, 0, whatIsGround);
        if (cayotyTimer > 0 && rememberTimer > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            cayotyTimer = 0;
            rememberTimer = 0;
            jumpTrigger = true;
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutoff);
        }

        if(Input.GetButtonDown("Dash") && canDash)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            isDashing = true;
            dashTime_ = dashTime;
            canDash = false;

        }
    }
    //Execute code
    private void FixedUpdate()
    {
        Move();
    }
    //Movement
    void Move()
    {     
        //dashing
        if(dashTime_ < 0)
        {
            isDashing = false;
            rb.gravityScale = 4;
        }

        if(isDashing)
        {
            if (transform.eulerAngles.y == 0)
            {
                rb.velocity = new Vector2(dashSpeed, 0);
            }
            if (transform.eulerAngles.y == 180)
            {
                rb.velocity = new Vector2(-dashSpeed, 0);
            }
            dashTime_ -= Time.deltaTime;
            return;
        }
        //Clamp Y speed
        float velY = Mathf.Clamp(rb.velocity.y, -maxYSpeed, float.MaxValue);

        //Horizontal
        float velX = rb.velocity.x;
        velX += Input.GetAxisRaw("Horizontal") * acseleration;
        velX *= Mathf.Pow(1f - friction, Time.deltaTime * 10f);

        rb.velocity = new Vector2(velX, velY);

        //Set X speed to 0
        if (Mathf.Abs(rb.velocity.x) < 0.2f)
        {
            velX = 0;
        }
    }   
}
