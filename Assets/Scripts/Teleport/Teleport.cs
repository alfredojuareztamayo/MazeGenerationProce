using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles teleportation of the player when they enter a trigger zone.
/// </summary>
public class Teleport : MonoBehaviour
{
    public GameObject pointToTeleport;  // The target point to which the player will be teleported

    /// <summary>
    /// Called when another collider enters the trigger zone.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger zone has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Try to get the CharacterController component from the player
            CharacterController characterController = other.GetComponent<CharacterController>();

            if (characterController != null)
            {
                // Temporarily disable the CharacterController to avoid teleportation issues
                characterController.enabled = false;
                // Set the player's position to the target teleport point
                other.transform.position = pointToTeleport.transform.position;
                // Re-enable the CharacterController after teleportation
                characterController.enabled = true;
            }
            else
            {
                // If no CharacterController is found, just move the player directly
                other.transform.position = pointToTeleport.transform.position;
            }
        }
        else
        {
            // Log a message if an object with the wrong tag enters the trigger zone
            Debug.Log("Objeto con tag incorrecto: " + other.tag);
        }
    }
}