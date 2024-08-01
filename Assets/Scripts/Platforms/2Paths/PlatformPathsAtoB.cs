using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Handles the movement of a platform between two points in a specified direction.
/// </summary>
public class PlatformPathsAtoB : PlatformBase
{
    // Array to store the start and end positions for the platform
    private Vector3[] direccionAtoB = new Vector3[2];
    public Transform directionA; // The start point of the platform movement
    public Transform directionB; // The end point of the platform movement
    private int currentDirection = 0; // Index to track the current direction of movement

    /// <summary>
    /// Initializes the platform's starting position and sets up the movement directions.
    /// Called when the script instance is being loaded.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        direccionAtoB[0] = directionA.position; // Set start position
        direccionAtoB[1] = directionB.position; // Set end position
        gameObject.transform.position = directionA.position; // Set initial platform position
    }

    /// <summary>
    /// Moves the platform between the two points and handles direction changes.
    /// Called once per frame.
    /// </summary>
    public override void BehaviourPlatform()
    {
        // Move the platform towards the current target position at the specified speed
        if (direccionAtoB.Length == 0) return; // If there are no directions, do nothing

        transform.position = Vector3.MoveTowards(transform.position, direccionAtoB[currentDirection], speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, direccionAtoB[currentDirection]) < 0.1f)
        {
            // Switch to the next direction in the array
            currentDirection = (currentDirection + 1) % direccionAtoB.Length;
        }
    }
}
