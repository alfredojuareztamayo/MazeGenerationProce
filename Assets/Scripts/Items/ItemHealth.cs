using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : CollectableItems
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().UpgradeHealth(upgradeHealth);
            DesactivateItem();
        }
    }
}
