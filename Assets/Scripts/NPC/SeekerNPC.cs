using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerNPC : MonoBehaviour
{
    public Transform target; // Target para seek, flee, pursuit, evade

    public float slowingDistance = 5f; // Distancia para el comportamiento arrive
    public float speed = 5f;

   

    void Start()
    {
   
    }

    void Update()
    {
        Vector3 steering = Vector3.zero;

        // Ejemplo de cómo llamar a los comportamientos
        if (target != null)
        {
            steering = SteeringBehaviour.Seek(transform, target.position, speed);
            // steering = SteeringBehaviour.Flee(transform, target.position, speed);
            // steering = SteeringBehaviour.Arrive(transform, target.position, speed, slowingDistance);
            // steering = SteeringBehaviour.Pursuit(transform, target, speed);
            // steering = SteeringBehaviour.Evade(transform, target, speed);
        }
       

        // Aplicar la fuerza de steering al movimiento del NPC
        Vector3 newPosition = transform.position + steering * Time.deltaTime * speed;


        // Actualizar la posición del NPC
        transform.position = newPosition;
    }
}
