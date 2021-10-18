using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField]
    private GameObject crack;

    public static int cracksActive = 0;

    Collider2D col;
    private float minPosX;
    private float maxPosX;
    private float minPosY;
    private float maxPosY;

    void Start()
    {
        cracksActive = 0;
        col = GetComponent<Collider2D>();
        minPosX = col.bounds.center.x - col.bounds.extents.x;
        maxPosX = col.bounds.center.x + col.bounds.extents.x;
        minPosY = col.bounds.center.y - col.bounds.extents.y;
        maxPosY = col.bounds.center.y + col.bounds.extents.y;

        StartCoroutine("InstantiateCrack");
    }

    private void Update() {
        Time.timeScale = 1+ (0.2f * cracksActive);
    }

    private IEnumerator InstantiateCrack()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);

            Vector2 instantiatePoint = new Vector2(Random.Range(minPosX, maxPosX), Random.Range(minPosY, maxPosY));
            while(!(col.OverlapPoint(instantiatePoint) && instantiatePoint.y <= col.bounds.center.y))
            {
                instantiatePoint = new Vector2(Random.Range(minPosX, maxPosX), Random.Range(minPosY, maxPosY));
            }

            GameObject newCrack = Instantiate(crack, instantiatePoint, Quaternion.identity);
            cracksActive++;
            Debug.Log(cracksActive);
        }
        
    }
}
