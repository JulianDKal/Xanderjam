using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JuJu {

public class PlayerController : MonoBehaviour
{

    //values visibile in the inspector
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private float jumpForce = 5;

    //private variables
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.position = new Vector3(transform.position.x + (horizontal * moveSpeed * Time.deltaTime), transform.position.y, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}

}