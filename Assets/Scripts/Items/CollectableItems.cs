using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{
    private Collider itemCollider;
    private Renderer itemRenderer;
    protected float timeSpawn = 10f;
    public float upgradeHealth, upgradeMaxHealth, upgradeArmor, upgradeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        itemCollider = GetComponent<Collider>();
        itemRenderer = GetComponent<Renderer>();
    }

    
    protected void DesactivateItem()
    {
        itemCollider.enabled = false;
        itemRenderer.enabled = false;
        StartCoroutine(ReactivateItem());
    }

    private IEnumerator ReactivateItem()
    {
        yield return new WaitForSeconds(timeSpawn); // Tiempo que el ítem permanece desactivado
        ActivateItem();
    }
    
    private void ActivateItem()
    {
        itemCollider.enabled = true;
        itemRenderer.enabled = true;
    }
}
