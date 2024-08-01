using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : CollectableItems
{
    /// <summary>
    /// Called when another collider enters the trigger collider attached to this item.
    /// Upgrades the player's health if the colliding object has the "Player" tag.
    /// </summary>
    /// <param name="other">The collider that triggered the event.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Upgrade the player's health
            other.GetComponent<PlayerStats>().UpgradeHealth(upgradeHealth);
            // Deactivate the item after use
            DesactivateItem();
        }
    }
}