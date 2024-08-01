using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves a platform along a set of predefined paths without any stop times.
/// </summary>
public class PlatformWithPath : PlatformBase
{
    [Header("Path Attributes")]
    public Transform[] paths; // Array of transforms representing the path points
    private int currentPath = 1; // Index to track the current path point

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
    /// Handles the platform's movement between path points.
    /// Called once per frame.
    /// </summary>
    public override void BehaviourPlatform()
    {
        // Check if paths are defined
        if (paths.Length == 0) return;

        // Move the platform towards the current path point
        transform.position = Vector3.MoveTowards(transform.position, paths[currentPath].position, speed * Time.deltaTime);

        // Check if the platform has reached the current path point
        if (Vector3.Distance(transform.position, paths[currentPath].position) < 0.1f)
        {
            // Move to the next path point
            currentPath = (currentPath + 1) % paths.Length;
        }
    }
}