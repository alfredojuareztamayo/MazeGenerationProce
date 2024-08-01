using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{
    /// <summary>
    /// Collider component attached to the item.
    /// </summary>
    private Collider itemCollider;

    /// <summary>
    /// Renderer component attached to the item.
    /// </summary>
    private Renderer itemRenderer;

    /// <summary>
    /// Time in seconds for which the item remains deactivated before being reactivated.
    /// </summary>
    public float timeSpawn = 10f;

    /// <summary>
    /// Amounts to upgrade various player stats when the item is collected.
    /// </summary>
    public float upgradeHealth, upgradeMaxHealth, upgradeArmor, upgradeSpeed, upgradeJump;

    /// <summary>
    /// Called before the first frame update. Initializes the collider and renderer components.
    /// </summary>
    void Start()
    {
        itemCollider = GetComponent<Collider>();
        itemRenderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// Deactivates the item by disabling its collider and renderer, then starts the coroutine to reactivate it.
    /// </summary>
    protected void DesactivateItem()
    {
        itemCollider.enabled = false;
        itemRenderer.enabled = false;
        StartCoroutine(ReactivateItem());
    }

    /// <summary>
    /// Coroutine that waits for a specified time before reactivating the item.
    /// </summary>
    /// <returns>An IEnumerator for coroutine handling.</returns>
    private IEnumerator ReactivateItem()
    {
        yield return new WaitForSeconds(timeSpawn); // Time the item remains deactivated
        ActivateItem();
    }

    /// <summary>
    /// Reactivates the item by enabling its collider and renderer.
    /// </summary>
    private void ActivateItem()
    {
        itemCollider.enabled = true;
        itemRenderer.enabled = true;
    }
}