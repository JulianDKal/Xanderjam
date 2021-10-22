using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandGrain : MonoBehaviour
{
    [SerializeField]
    private float randomRangeX = 2f;

    float time = 3;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        float randomForceX = Random.Range(-randomRangeX, randomRangeX);
        rb.AddForce(new Vector2(randomForceX, -2));
        time -= Time.deltaTime;
    }

    private void Update()
    {
        if(rb.velocity.magnitude < 0.2f && time < 0)
        {
            Freeze();
        }
    }

    void Freeze()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
}
