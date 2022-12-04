using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Public Variables
    public GameObject obstaclePrefab; // helps set the obstacle prefab

    // Private Variables
    private Vector3 spawnPos = new Vector3(27, 0, 0); // position where the obstacle will spawn
    private float startDelay = 2.0f; // start delay spawning the obstacle
    private float repeatRate = 2.0f; // interval value for spawning the obstacle
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Repeat spawning the obstacle
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        // Initialize the variable by finding the Player and getting the PlayerController component
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // As long as the game isn't over, the obstacle will continue to spawn
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
