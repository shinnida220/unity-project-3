using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Speed at which the attached gameObject will move
    public float speed;

    // A reference to player controller script
    private PlayerController playerControllerScript;

    // Left bounds of objects
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        // Use the GameObject class to find a gameObject, get its playerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do a check for gameOver
        if (playerControllerScript.gameOver == false)
        {
            // Only then, should the attached object move left.
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Only the game object with tag Obstacle
        if (transform.position.x <= leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
