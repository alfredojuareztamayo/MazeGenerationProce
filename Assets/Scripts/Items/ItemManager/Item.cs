using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemId;
    ItemManager itemManager;
    public bool Reactivate;
    public float ReactTime = 0;
   

    private void Start()
    {
        itemManager = FindAnyObjectByType<ItemManager>();
    }
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


    IEnumerator TurnOffOnItem(float time)
    {
        gameObject.SetActive(false);
        itemManager.ApplyEffects(ItemId);
        yield return new WaitForSeconds(time);
        gameObject.SetActive(true);
    }
}
