using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

namespace JuJu {

public class PlayerController : MonoBehaviour
{

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
    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Physics.gravity = gravityVector;
        cam = Camera.main;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.position = new Vector3(transform.position.x + (horizontal * moveSpeed * Time.deltaTime), transform.position.y, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            //gravityVector *= -1;
            //Physics2D.gravity = gravityVector;
            ChangeRotation();
            Debug.Log("F Key pressed");
        }

        hourglass.rotation = Quaternion.Slerp(hourglass.rotation, targetAngle, Time.deltaTime);
        Debug.Log(isTurned);
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