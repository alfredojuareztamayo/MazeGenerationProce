using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerNPC : NPCManager
{
    public float stateChangeDelay = 0.5f; // Tiempo de retraso antes de cambiar de estado
    private float lastStateChangeTime;
    void Start()
    {
        // Llamar al método Start() de NPCManager
        lastStateChangeTime = Time.time;
    }

    void Update()
    {
        // Comprobar si es tiempo de cambiar de estado
        if (Time.time - lastStateChangeTime > stateChangeDelay)
        {
            // Cambiar a Seek si el target está dentro del radio de percepción
            if (target != null )
            {
                this.status = StatusNPC.Seek;
            }
            else
            {
                this.status = StatusNPC.Wander;
            }

            // Actualizar el tiempo del último cambio de estado
            lastStateChangeTime = Time.time;
        }

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
                if (target != null)
                {
                    Vector3 seekForce = SteeringBehaviour.Seek(transform, target.position, speed);
                    ApplySteering(seekForce);
                }
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
