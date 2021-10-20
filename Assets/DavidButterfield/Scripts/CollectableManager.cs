using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    
    public int playerScore = 0;
    [SerializeField]
    private Transform[] platforms;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject collectablePrefab;
    [SerializeField, Tooltip("The time that passes until another collectable gets instantiated")]
    private float timeInBetween;

    void Start()
    {
        scoreText.text = playerScore.ToString();
        StartCoroutine("InstantiateCollectables");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            playerScore = playerScore + 1;
            scoreText.text = playerScore.ToString();
        }
        if(other.CompareTag("Obstacle"))
        {
            StartCoroutine("TakeDamage");
        }
        
    }

    IEnumerator InstantiateCollectables()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeInBetween);
            Instantiate(collectablePrefab, platforms[Random.Range(0, platforms.Length)].position + Vector3.up, Quaternion.identity);
        }
    }

    IEnumerator TakeDamage()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 2), ForceMode2D.Impulse);
        GetComponent<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(1.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<PlayerMovement>().enabled = true;

    }
}
