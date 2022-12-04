using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    private Rigidbody playerRb; // variable for rigidbody of the player
    private Animator playerAnim; // variable for animation of the player
    private AudioSource playerAudio; // variable for the sounds made by the player

    // Public Variables
    public float jumpForce = 10.0f; // amount of force of the player when jumping
    public float gravityModifier = 1.5f; // amount of gravity that limits the player to fly over the space
    public bool isOnGround = true; // bool variable for isOnGround
    public bool gameOver = false; // bool variable for gameOver (used in MoveLeft and SpawnManager script)
    public ParticleSystem explosionParticle; // used for putting explosion  to the player
    public ParticleSystem dirtParticle; // used for for putting splattering dirt to the player's feet when running on the ground
    public AudioClip jumpSound; // used for putting sound to the jump of the player
    public AudioClip crashSound; // used for putting sound when the player crash to obstacle

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // initialize the variable by getting the player's rigid body component
        playerAnim = GetComponent<Animator>(); // initialize the variable by getting the player's animator component
        playerAudio = GetComponent<AudioSource>(); // initialize the variable by getting the audio source component
        Physics.gravity *= gravityModifier; // set the gravity
    }

    // Update is called once per frame
    void Update()
    {
        // Once the player jump using space bar, the codes below will be executed
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // lets the player jump
            isOnGround = false; // notes that the player is currently not on the ground
            playerAnim.SetTrigger("Jump_trig"); // add jump animation to the player
            dirtParticle.Stop(); // dirt splattering from the player's feet will stop
            playerAudio.PlayOneShot(jumpSound, 1.0f); // add jump sound to the player
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Once the player makes contact with the ground, the codes below will be executed
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // notes that the player is currently on the ground
            dirtParticle.Play(); // start dirt splattering from the player's feet
        }

        // Once the player makes contact with the obstacle, the codes below will be executed 
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!"); // notes that the game is over
            gameOver = true; // notes that the game is over
            playerAnim.SetBool("Death_b", true); // add death animation of the player
            playerAnim.SetInteger("DeathType_int", 1); // set what type of death animation of the player 
            explosionParticle.Play(); // add explosion animation to the player
            dirtParticle.Stop(); // dirt splattering from the player's feet will stop
            playerAudio.PlayOneShot(crashSound, 1.0f); // add crash audio to the player
        }
    }
}
