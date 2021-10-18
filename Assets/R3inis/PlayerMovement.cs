using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerMovement : MonoBehaviour
{

    //fields for the player HUD
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    public int maxTime;
    private float currentTime;
    private int score;

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


    public int cayoty;
    int cayotyTimer;
    public int remember;
    int rememberTimer;

    //Animator anim;


    //Get veriables
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTime = maxTime;
        //anim = GetComponent<Animator>();
    }

    //Animation/jumping
    private void Update()
    {
        //anim.SetFloat("SpeedY", rb.velocity.y);
        //anim.SetBool("IsGrounded", isGrounded);

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
        }

        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkSize, whatIsGround);
        if (cayotyTimer > 0 && rememberTimer > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            cayotyTimer = 0;
            rememberTimer = 0;
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutoff);
        }     

        currentTime -= Time.deltaTime;
        timerText.text = Convert.ToString((int)currentTime);
        if(currentTime <= 0)
        {
            Game_Manager.instance.GameOver();
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
