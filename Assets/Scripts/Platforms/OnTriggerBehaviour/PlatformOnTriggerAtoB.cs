using System.Collections;
using UnityEngine;

/// <summary>
/// Manages the movement of a platform between two points, triggered by collision with a specified player.
/// </summary>
public class PlatformOnTriggerAtoB : PlatformBase
{
    [Header("Attributes On Trigger")]
    public string playerTag; // Tag used to identify the player that triggers the platform

    [Header("Attributes On Trigger")]
    private Vector3[] direccionAtoB = new Vector3[2]; // Array to store start and end positions
    public Transform directionA; // The start position of the platform movement
    public Transform directionB; // The end position of the platform movement
    private int currentDirection = 0; // Index to track the current direction of movement
    private float[] timeToStop = new float[2]; // Array to store stop times at each position
    public float timeA; // Time to stop at the start point
    public float timeB; // Time to stop at the end point
    private bool isMoving = false; // Flag to indicate if the platform is currently moving
    private bool isTrigger = false; // Flag to indicate if the player is currently on the platform

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
    /// Moves the platform between the two points and handles stop times if the player is on the platform.
    /// Called once per frame.
    /// </summary>
    public override void BehaviourPlatform()
    {
        // If there are no directions or if the platform is not moving, do nothing
        if (direccionAtoB.Length == 0) return;
        if (!isMoving && isTrigger)
        {
            StartCoroutine(TimeStop());
        }
    }

    /// <summary>
    /// Handles collision with objects. If the object is tagged with the specified player tag, it sets the trigger flag to true.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            isTrigger = true;
        }
    }

    /// <summary>
    /// Handles when the player exits the collision with the platform. It stops the platform's movement and sets the trigger flag to false.
    /// </summary>
    /// <param name="collision">The collision information.</param>
    private void OnCollisionExit(Collision collision)
    {
        isTrigger = false;
        StopCoroutine(TimeStop());
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
}

/// <summary>
/// Enum to specify different types of platform behaviors.
/// </summary>
public enum TypeOfPlatform
{
    None, // No specific behavior
    isAtoB, // Moves between two points
    isAtoBWithTime, // Moves between two points with stop times
    isPaths, // Follows a predefined path
    isPathsWithTime // Follows a predefined path with stop times
}