using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMob : MonoBehaviour
{
    public float wanderRadius = 5f;
    public float wanderDistance = 10f;
    public float wanderJitter = 0.5f;
    public float speed = 5f;
    public float fixedHeight = 10f;  // Altura fija para el NPC

    private Vector3 targetPosition;

    void Start()
    {
        // Inicializar la posición objetivo
        targetPosition = transform.position + Random.insideUnitSphere * wanderRadius;
    }

    void Update()
    {
        // Obtener la fuerza de wander del método estático
        Vector3 wanderForce = SteeringBehaviour.Wander(transform, ref targetPosition, wanderRadius, wanderDistance, wanderJitter);

        // Aplicar la fuerza de wander al movimiento del NPC
        Vector3 newPosition = transform.position + wanderForce * Time.deltaTime * speed;

        // Mantener la altura fija
        newPosition.y = fixedHeight;

        // Actualizar la posición del NPC
        transform.position = newPosition;
    }
}
