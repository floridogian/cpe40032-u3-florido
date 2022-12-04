using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Private Variables
    private Vector3 startPos; // start position of the background
    private float repeatWidth; // get the width of the background

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // initialize the variable by getting the background's position
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // initialize the variable by getting the background's size using box collider component
    }

    // Update is called once per frame
    void Update()
    {
        // This will smoothly repeat the background to it's start position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
