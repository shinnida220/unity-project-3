using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Addding gameobject since its a prefab
    public GameObject obstaclePrefab;

    // Spawn position of the spawn
    private Vector3 spawnPos = new Vector3(25, 0,0);

    // Used for repeated invocations
    private float startDelay = 2;
    private float repeatDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
