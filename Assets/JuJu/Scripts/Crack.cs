using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
    public Sprite[] crackVersions;

    private void OnCollisionStay2D(Collision2D other) {
        if(other.collider.CompareTag("Player"))
        {

        }
    }
}
