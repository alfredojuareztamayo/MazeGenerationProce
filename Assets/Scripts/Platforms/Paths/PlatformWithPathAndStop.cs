using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves a platform along a set of predefined paths with stop times at each path.
/// </summary>
public class PlatformWithPathAndStop : PlatformBase
{
    [Header("Path Attributes")]
    public Transform[] paths; // Array of transforms representing the path points
    private int currentPath = 1; // Index to track the current path point
    public float[] timeToStop; // Array of stop times at each path point
    private bool isMoving = false; // Flag to indicate if the platform is currently moving

    /// <summary>
    /// Initializes the platform's starting position.
    /// Called when the script instance is being loaded.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        if (paths.Length > 0)
        {
            gameObject.transform.position = paths[0].position; // Set initial position to the first path point
        }
    }

    /// <summary>
    /// Handles the platform's movement between path points and manages stop times.
    /// Called once per frame.
    /// </summary>
    public override void BehaviourPlatform()
    {
        // Check if paths and stop times are defined
        if (paths.Length == 0 || timeToStop.Length == 0) return;

        // Start movement coroutine if not already moving
        if (!isMoving)
        {
            StartCoroutine(TimeToStopInPaths());
        }
    }

    /// <summary>
    /// Coroutine that moves the platform between path points and handles stop times.
    /// </summary>
    /// <returns>An IEnumerator for the coroutine.</returns>
    IEnumerator TimeToStopInPaths()
    {
        isMoving = true;

        // Move the platform towards the current path point
        while (Vector3.Distance(transform.position, paths[currentPath].position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, paths[currentPath].position, speed * Time.deltaTime);
            yield return null;
        }

        // Wait for the specified stop time at the current path point
        yield return new WaitForSeconds(timeToStop[currentPath]);

        // Move to the next path point
        currentPath = (currentPath + 1) % paths.Length;

        isMoving = false;
    }
}