using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the movement of a platform between two points with specified stop times at each point.
/// </summary>
public class PlatformPathAtoBTime : PlatformBase
{
    // Array to store the start and end positions for the platform
    private Vector3[] direccionAtoB = new Vector3[2];
    public Transform directionA; // The start point of the platform movement
    public Transform directionB; // The end point of the platform movement
    private int currentDirection = 0; // Index to track the current direction of movement
    private float[] timeToStop = new float[2]; // Array to store the stop times at each point
    public float timeA; // Time to stop at the start point
    public float timeB; // Time to stop at the end point
    private bool isMoving = false; // Flag to indicate if the platform is currently moving

    /// <summary>
    /// Initializes the platform's starting position, movement directions, and stop times.
    /// Called when the script instance is being loaded.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        direccionAtoB[0] = directionA.position; // Set start position
        direccionAtoB[1] = directionB.position; // Set end position
        gameObject.transform.position = directionA.position; // Set initial platform position
        timeToStop[0] = timeA; // Set stop time at the start point
        timeToStop[1] = timeB; // Set stop time at the end point
    }

    /// <summary>
    /// Moves the platform between the two points and handles stop times at each point.
    /// Called once per frame.
    /// </summary>
    public override void BehaviourPlatform()
    {
        // If there are no directions, do nothing
        if (direccionAtoB.Length == 0) return;

        // Start moving the platform if it's not already moving
        if (!isMoving)
        {
            StartCoroutine(TimeStop());
        }
    }

    /// <summary>
    /// Coroutine that moves the platform to the current direction and handles stop time.
    /// </summary>
    /// <returns>An IEnumerator for the coroutine.</returns>
    IEnumerator TimeStop()
    {
        isMoving = true;

        // Move the platform towards the current target position
        while (Vector3.Distance(transform.position, direccionAtoB[currentDirection]) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, direccionAtoB[currentDirection], speed * Time.deltaTime);
            yield return null;
        }

        // Wait for the specified stop time at the current direction
        yield return new WaitForSeconds(timeToStop[currentDirection]);

        // Switch to the next direction
        currentDirection = (currentDirection + 1) % direccionAtoB.Length;
        isMoving = false;
    }

    /// <summary>
    /// Handles collision with objects. If the object is tagged as "Player", it sets the player as a child of the platform.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    /// <summary>
    /// Handles when the player exits the collision with the platform. It removes the player from being a child of the platform.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}