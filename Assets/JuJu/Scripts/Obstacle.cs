using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private void Awake() {
        rb.AddForce(new Vector2(Random.Range(-1, 2), 0), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("bottom"))
        {
            Destroy(gameObject);
        }
    }
}
