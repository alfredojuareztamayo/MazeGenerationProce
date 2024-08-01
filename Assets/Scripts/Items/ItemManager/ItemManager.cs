using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the ItemManager.
    /// </summary>
    public static ItemManager instance;

    /// <summary>
    /// List of items managed by this ItemManager.
    /// </summary>
    public List<ItemsBase> items;

    /// <summary>
    /// Reference to the PlayerStats component for applying item effects.
    /// </summary>
    PlayerStats stats;

    /// <summary>
    /// Called when the script instance is being loaded. Initializes the singleton instance.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Called before the first frame update. Initializes the PlayerStats reference and adds items.
    /// </summary>
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        AddItems();
    }

    /// <summary>
    /// Called once per frame. Currently unused.
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Logs the name of each item in the items list.
    /// </summary>
    void AddItems()
    {
        foreach (var item in items)
        {
            Debug.Log(item.itemName);
        }
    }

    /// <summary>
    /// Applies effects to the player based on the item ID.
    /// </summary>
    /// <param name="id">The ID of the item whose effects are to be applied.</param>
    public void ApplyEffects(int id)
    {
        // Find the item with the specified ID
        ItemsBase itemTemp = items.Find(item => item.itemID == id);

        // Apply effects based on item ID
        switch (id)
        {
            case 0:
                // Upgrade jump ability
                stats.UpgradeJump(itemTemp.statsPoints);
                break;
            case 1:
                // Upgrade speed ability
                stats.UpgradeSpeed(itemTemp.statsPoints);
                break;
        }
    }
}