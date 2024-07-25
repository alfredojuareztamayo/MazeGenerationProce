using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemId;
    ItemManager itemManager;
    public bool Reactivate;
    public float ReactTime = 0;
    public Renderer Renderer;
    public Renderer RendererLiquid;
    public Collider Collider;
   

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
        Renderer.enabled = false;
        RendererLiquid.enabled = false;
        Collider.enabled = false;
        itemManager.ApplyEffects(ItemId);
        yield return new WaitForSeconds(time);
        Renderer.enabled = true;
        RendererLiquid.enabled = true;
        Collider.enabled=true;
    }
}
