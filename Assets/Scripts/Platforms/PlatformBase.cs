using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public abstract class PlatformBase : MonoBehaviour
{

    public string namePlatform;
    public float speed = 2.0f;
    private new Collider collider;
    private MeshRenderer MeshRenderer;
    public Material material;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        collider = GetComponent<Collider>();
        MeshRenderer = GetComponent<MeshRenderer>();
        if (MeshRenderer != null && material != null)
        {
            ChangeMaterialStart();
        }
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        BehaviourPlatform();
    }
    public abstract void BehaviourPlatform();
    protected virtual void ChangeMaterialStart()
    {
        if (material != null)
        {

            GetComponent<MeshRenderer>().material = material;
        }
    }
        
}
