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

    // A reference to player controller script
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
        // Use the GameObject class to find a gameObject, get its playerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // Only spawn new obstacle if game isn't over
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
