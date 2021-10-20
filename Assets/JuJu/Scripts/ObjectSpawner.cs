using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private int objectIndex = 0;
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private float timeBetweenObstacles = 2;

    private void Awake() {
        StartCoroutine("SpawnObstacles");
    }

    private void FixedUpdate() {
        objectIndex++;
        if(objectIndex % 2 == 0) Instantiator.instance.SpawnObjectFromPool("sand", transform.position, Quaternion.identity);
    }

    IEnumerator SpawnObstacles()
    {
        while(true)
        {
        yield return new WaitForSeconds(timeBetweenObstacles);
        Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
