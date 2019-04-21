using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnnoyingEnemy : MonoBehaviour
{
    public float spawnInterval;
    private float spawnIntervalCount;
    public Object objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        spawnIntervalCount = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnIntervalCount -= Time.deltaTime;
        if (spawnIntervalCount < 0f)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            spawnIntervalCount = spawnInterval;
        }
    }
}
