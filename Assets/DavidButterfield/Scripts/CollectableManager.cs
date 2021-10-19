using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    void Start()
    {
        scoreText.text = playerScore.ToString();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collectable")
        {
            Destroy(other.gameObject);
            playerScore = playerScore + 1;
            scoreText.text = playerScore.ToString();
        }
        
    }
}
