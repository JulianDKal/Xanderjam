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
    [SerializeField]
    private TextMeshProUGUI crackText;
    public int maxTime;
    private float currentTime;
    private int score;

    public float acseleration;
    [Range(0,1)]
    public float friction;
    Rigidbody2D rb;
    private Collider2D col;

    public float jumpForce;
    [Range(0, 1)]
    public float jumpCutoff;
    public float maxYSpeed;
    bool isGrounded;
    public LayerMask whatIsGround;


    public int cayoty;
    int cayotyTimer;
    public int remember;
    int rememberTimer;
    private int jumpCount;

    SpriteRenderer sr;
    public Sprite defalut;
    public Sprite jump;
    public Sprite fall;

    //FMOD
    private FMOD.Studio.EventInstance jumpInstance;


    //Get veriables
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        currentTime = maxTime;
        col = GetComponent<Collider2D>();
        
    }

    //Animation/jumping
    private void Update()
    {
        if(isGrounded) jumpCount = 0;
        if(!isGrounded && rb.velocity.y > 0.3)
        {
            sr.sprite = jump;
        }
        else if (!isGrounded && rb.velocity.y < -0.3)
        {
            sr.sprite = fall;
        }
        else
        {
            sr.sprite = defalut;
        }

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
            jumpInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay SFX/Jump");
            jumpInstance.start();
            jumpInstance.release();
        }
        if(jumpCount < 1)
        {
            rememberTimer = remember;
        }

        isGrounded = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.35f, whatIsGround);
        Debug.DrawRay(col.bounds.center, Vector2.down * 5, Color.green);
        //Physics2D.OverlapBox(groundCheck.position, checkSize, whatIsGround);
        if (cayotyTimer > 0 && rememberTimer > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            cayotyTimer = 0;
            rememberTimer = 0;
            jumpCount++;
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutoff);
        }     

        crackText.text = Instantiator.cracksActive.ToString();

        currentTime -= Time.deltaTime * (float)(1 + ( 0.25 * Instantiator.cracksActive));
        timerText.text = Convert.ToString((int)currentTime);
        if(currentTime < 0)
        {
            Game_Manager.instance.GameOver();
            currentTime = 0;
        };
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
