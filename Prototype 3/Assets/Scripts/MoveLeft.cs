using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Private Variables
    private float speed = 20.0f; // speed of the objects (background & obstacle) moving to the left 
    private PlayerController playerControllerScript; // import PlayerController script
    private float leftBound = -15.0f; // x value

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the variable by finding the Player and getting the PlayerController component
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // As long as the game isn't over, the player will continue to run 
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Once the obstacle reaches the leftBound value, obstacle will be destroyed from the game
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
