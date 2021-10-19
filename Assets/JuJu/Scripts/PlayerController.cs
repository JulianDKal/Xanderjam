using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
//using Cinemachine;
//hi, this is david, I think that it would be smarter to put some of these functions into a game manager script to keep things more organized
namespace JuJu {

public class PlayerController : MonoBehaviour
{
    //fields for the player HUD
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    public int maxTime;
    private float currentTime;
    private int score;

    //variables visibile in the inspector
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private float jumpForce = 5;
    [SerializeField]
    private Transform hourglass;

    //private variables
    private Rigidbody2D rb;
    private Camera cam;
    private Vector2 gravityVector = new Vector2(0, -9.8f);
    private Quaternion targetAngle = Quaternion.Euler(0, 0, 0);
    private bool isTurned = false;
    private float horizontal;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Physics.gravity = gravityVector;
        cam = Camera.main;
        currentTime = maxTime;
    }

    void Update()
    {
        if(!isTurned) horizontal = Input.GetAxisRaw("Horizontal");
        else horizontal = -Input.GetAxisRaw("Horizontal");

        transform.position = new Vector3(transform.position.x + (horizontal * moveSpeed * Time.deltaTime), transform.position.y, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isTurned) rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            else rb.AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            gravityVector *= -1;
            Physics2D.gravity = gravityVector;
            ChangeRotation();
            Debug.Log("F Key pressed");
        }
        currentTime -= Time.deltaTime;
        timerText.text = Convert.ToString((int)currentTime);
        if(currentTime <= 0)
        {
            Game_Manager.instance.GameOver();
        }

        hourglass.rotation = Quaternion.Slerp(hourglass.rotation, targetAngle, Time.deltaTime);
    }

    void ChangeRotation()
    {
        if(isTurned == false)
        {
            targetAngle = Quaternion.Euler(0,0,180);
            isTurned = true;
        }
        else
        {
            targetAngle = Quaternion.Euler(0,0,0);
            isTurned = false;
        }

    }
}

}