using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public static Instantiator instance;

    private void Awake() {
        instance = this;
    }

    public Dictionary<string, Queue<GameObject>> objectDictionary;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefabToSpawn;
        public int size;
    }

    public List<Pool> pools;

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
        objectDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject newSpawnObj = Instantiate(pool.prefabToSpawn);
                newSpawnObj.SetActive(false);
                objectQueue.Enqueue(newSpawnObj);
            }

            objectDictionary.Add(pool.tag, objectQueue);
        }
        
        cracksActive = 0;
        col = GetComponent<Collider2D>();
        minPosX = col.bounds.center.x - col.bounds.extents.x;
        maxPosX = col.bounds.center.x + col.bounds.extents.x;
        minPosY = col.bounds.center.y - col.bounds.extents.y;
        maxPosY = col.bounds.center.y + col.bounds.extents.y;

        StartCoroutine("InstantiateCrack");
    }

    public void SpawnObjectFromPool(string tag, Vector2 spawnPos, Quaternion rotation)
    {
        if(!objectDictionary.ContainsKey(tag)) return;

        if(objectDictionary[tag].Count != 0)
        {
        GameObject newObj = objectDictionary[tag].Dequeue();
        newObj.SetActive(true);
        newObj.transform.position = spawnPos;
        newObj.transform.rotation = rotation;
        }
        //objectDictionary[tag].Enqueue(newObj);
    }

    private void Update() {
        //Time.timeScale = 1+ (0.2f * cracksActive);
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
