using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the parenting of objects (e.g., players) to the platform when they collide with it.
/// </summary>
public class PlatformSetParent : MonoBehaviour
{
    /// <summary>
    /// Called when another collider enters the trigger collider attached to this platform.
    /// Sets the parent of the player to the platform's parent when they enter the trigger.
    /// </summary>
    /// <param name="other">The collider that triggered the event.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Set the player's parent to the platform's parent, effectively making the platform's parent the new parent of the player
            other.transform.SetParent(transform.parent);
        }
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to this platform.
    /// Resets the parent of the player to null when they exit the trigger.
    /// </summary>
    /// <param name="other">The collider that triggered the event.</param>
    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Remove the player's parent, detaching them from any parent object
            other.transform.SetParent(null);
        }
    }
}
