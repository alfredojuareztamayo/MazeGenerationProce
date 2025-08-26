using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a flying NPC (non-player character) that inherits behavior management from NPCManager.  
/// Handles AI states such as None, Seek, Flee, and Wander, applying the corresponding steering behaviors.  
/// </summary>
public class FlyingMob : NPCManager
{
    /// <summary>
    /// Initializes the NPC with a default status set to Wander.  
    /// </summary>

    void Start()
    {
        status = StatusNPC.Wander;
    }
    /// <summary>
    /// Updates the NPC every frame, executing the current state logic through HandleStatus().  
    /// </summary>

    void Update()
    {

        HandleStatus(status);
    }
    /// <summary>
    /// Handles NPC behavior according to its current status.  
    /// - None: Debug log message.  
    /// - Seek: Debug log message.  
    /// - Flee: Debug log message.  
    /// - Wander: Applies the Wander steering behavior within a defined area.  
    /// </summary>
    /// <param name="status">The current state of the NPC.</param>
    private void HandleStatus(StatusNPC status)
    {
        switch (status)
        {
            case StatusNPC.None:
                Debug.Log("Estoy en la inmortalidad del congrejo");
                break;
            case StatusNPC.Seek:
                Debug.Log("Estoy en la inmortalidad del congrejo");
                break;
            case StatusNPC.Flee:
                Debug.Log("Estoy en la inmortalidad del congrejo");
                break;
            case StatusNPC.Wander:
                Vector3 wanderForce = SteeringBehaviour.Wander(transform,  targetPosition, wanderRadius, wanderDistance, wanderJitter, areaCenter, areaSize);
                ApplySteering(wanderForce);
                break;
        }

    }
}
