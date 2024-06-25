using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMob : NPCManager
{
    

    void Start()
    {
        status = StatusNPC.Wander;
    }

    void Update()
    {

        HandleStatus(status);
    }

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
                Vector3 wanderForce = SteeringBehaviour.Wander(transform, ref targetPosition, wanderRadius, wanderDistance, wanderJitter, areaCenter, areaSize);
                ApplySteering(wanderForce);
                break;
        }

    }
}
