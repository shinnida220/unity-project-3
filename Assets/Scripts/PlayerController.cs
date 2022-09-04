using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //For the player's rigidbody
    private Rigidbody playerRb;
    private Animator playerAnim;

    // Outside of player component
    public ParticleSystem explosionParticle;
    public ParticleSystem dirthParticle;

    //Player's jump force
    public float jumpForce = 15;

    public float gravityModifier;

    public bool isOnGround = true;

    public bool gameOver;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Game gravity.
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            
            // Lets make the player jump by applyng a force on the rigidbody
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            // When the player jumps, lets trigger the jump animation
            playerAnim.SetTrigger("Jump_trig");

            // Dont play dirth particle in space
            dirthParticle.Stop();

            // Play jumpClimp
            playerAudio.PlayOneShot(jumpSound,1);
        }
    }

    // Once the attached  gameObject collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            
            if (!gameOver) 
            {
                // Play dirth particle in space
                dirthParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over");
            gameOver = true;
            
            // Player dies
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            // Play particle explosion
            explosionParticle.Play();

            // Dont play dirth particle on gameOver
            dirthParticle.Stop();

            // Play crashSound
            playerAudio.PlayOneShot(crashSound,1);
        }
    }

}
