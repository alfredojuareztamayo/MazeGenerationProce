using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // Player's transform to follow
    public Vector3 offset;            // Offset from the player

    /// <summary>
    /// Checks if the player transform is assigned.
    /// </summary>
    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform not assigned in CameraFollow script.");
        }
    }

    /// <summary>
    /// Updates the camera position to follow the player.
    /// </summary>
    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Update camera position to follow the player
            transform.position = playerTransform.position + offset;
        }
    }
}
