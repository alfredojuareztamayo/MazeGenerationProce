using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract base class for platform behaviors in the game.
/// All platform types should inherit from this class and implement specific platform behaviors.
/// </summary>
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public abstract class PlatformBase : MonoBehaviour
{
    /// <summary>
    /// The name of the platform. Can be used for identification or debugging.
    /// </summary>
    public string namePlatform;

    /// <summary>
    /// The speed at which the platform moves.
    /// </summary>
    public float speed = 2.0f;

    private new Collider collider;        // Reference to the platform's Collider component
    private MeshRenderer MeshRenderer;    // Reference to the platform's MeshRenderer component
    public Material material;             // Material to be applied to the platform's MeshRenderer

    /// <summary>
    /// Called before the first frame update.
    /// Initializes the Collider and MeshRenderer components and applies the material if provided.
    /// </summary>
    protected virtual void Start()
    {
        collider = GetComponent<Collider>();
        MeshRenderer = GetComponent<MeshRenderer>();
        if (MeshRenderer != null && material != null)
        {
            ChangeMaterialStart();
        }
    }

    /// <summary>
    /// Called once per physics frame.
    /// Executes the platform-specific behavior by calling the abstract BehaviourPlatform method.
    /// </summary>
    protected virtual void FixedUpdate()
    {
        BehaviourPlatform();
    }

    /// <summary>
    /// Defines the platform-specific behavior. 
    /// Must be implemented by derived classes.
    /// </summary>
    public abstract void BehaviourPlatform();

    /// <summary>
    /// Applies the specified material to the MeshRenderer at the start.
    /// </summary>
    protected virtual void ChangeMaterialStart()
    {
        if (material != null)
        {
            GetComponent<MeshRenderer>().material = material;
        }
    }
}