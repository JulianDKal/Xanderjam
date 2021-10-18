using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandGrain : MonoBehaviour
{
    [SerializeField]
    private float randomRangeX = 2f;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        float randomForceX = Random.Range(-randomRangeX, randomRangeX);
        rb.AddForce(new Vector2(randomForceX, 0));
    }
}
