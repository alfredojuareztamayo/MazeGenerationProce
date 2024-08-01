using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsBase
{
    /// <summary>
    /// The name of the item.
    /// </summary>
    public string itemName;

    /// <summary>
    /// A description of the item.
    /// </summary>
    public string description;

    /// <summary>
    /// The icon representing the item.
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// A unique identifier for the item.
    /// </summary>
    public int itemID;

    /// <summary>
    /// The quantity of the item.
    /// </summary>
    public int quantity;

    /// <summary>
    /// The amount of stats points associated with the item.
    /// </summary>
    public float statsPoints;
}


