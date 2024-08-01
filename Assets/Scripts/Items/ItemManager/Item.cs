using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    /// <summary>
    /// Unique identifier for the item.
    /// </summary>
    public int ItemId;

    /// <summary>
    /// Reference to the ItemManager that handles item effects.
    /// </summary>
    ItemManager itemManager;

    /// <summary>
    /// Determines if the item should be reactivated after being deactivated.
    /// </summary>
    public bool Reactivate;

    /// <summary>
    /// Time in seconds before the item is reactivated.
    /// </summary>
    public float ReactTime = 0;

    /// <summary>
    /// Renderer component for the item.
    /// </summary>
    public Renderer Renderer;

    /// <summary>
    /// Renderer component for the liquid part of the item.
    /// </summary>
    public Renderer RendererLiquid;

    /// <summary>
    /// Collider component for the item.
    /// </summary>
    public Collider Collider;

    /// <summary>
    /// Called when the script instance is being loaded. Finds the ItemManager instance.
    /// </summary>
    private void Start()
    {
        itemManager = FindAnyObjectByType<ItemManager>();
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this item.
    /// Applies effects based on the item's ID and manages item activation based on Reactivate flag.
    /// </summary>
    /// <param name="other">The collider that triggered the event.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (Reactivate)
        {
            StartCoroutine(TurnOffOnItem(ReactTime));
        }
        else
        {
            itemManager.ApplyEffects(ItemId);
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Coroutine to deactivate and then reactivate the item after a delay.
    /// </summary>
    /// <param name="time">Time in seconds to remain deactivated.</param>
    /// <returns>An IEnumerator for the coroutine.</returns>
    IEnumerator TurnOffOnItem(float time)
    {
        Renderer.enabled = false;
        RendererLiquid.enabled = false;
        Collider.enabled = false;
        itemManager.ApplyEffects(ItemId);
        yield return new WaitForSeconds(time);
        Renderer.enabled = true;
        RendererLiquid.enabled = true;
        Collider.enabled = true;
    }
}
