using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private void FixedUpdate() {
        Instantiator.instance.SpawnObjectFromPool("sand", transform.position, Quaternion.identity);
    }
}
