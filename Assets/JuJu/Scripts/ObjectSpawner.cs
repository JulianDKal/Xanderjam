using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private int objectIndex = 0;

    private void FixedUpdate() {
        objectIndex++;
        if(objectIndex % 2 == 0) Instantiator.instance.SpawnObjectFromPool("sand", transform.position, Quaternion.identity);
    }
}
