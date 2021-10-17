using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
    ///<summary>
    ///class for the cracks on the hourglass. When the player presses R while being on top of a crack, the crack's health will decrease 
    ///causing it to display another image. 
    ///</summary>

    public Sprite[] crackVersions; //An array of the different versions of a crack
    public GameObject player;

    private int crackHealth; 

    private void Awake() {
        crackHealth = crackVersions.Length;
        GetComponent<SpriteRenderer>().sprite = crackVersions[crackHealth - 1];
        try
        {
             player = GameObject.Find("Player");
        }
        catch (System.NullReferenceException)
        {
            Debug.LogWarning("Player not active in hierarchy!");
        }
    }

    private void Update() {
        if(GetComponent<Collider2D>().OverlapPoint(player.transform.position))
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                crackHealth--;
                if(crackHealth <= 0) {
                    Destroy(gameObject);
                    return;
                    }
                GetComponent<SpriteRenderer>().sprite = crackVersions[crackHealth -1];
                Debug.Log(crackHealth);
            }
        }
    }


}
