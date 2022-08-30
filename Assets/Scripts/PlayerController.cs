using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //For the player's rigidbody
    private Rigidbody playerRb;

    //Player's jump force
    public float jumpForce = 10;

    public float gravityModifier;

    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        // Game gravity.
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            
            // Lets make the player jump by applyng a force on the rigidbody
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    // Once the attached  gameObject collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

}
