using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{
    public static Vector3 Wander(Transform entityTransform, Vector3 targetPosition, float wanderRadius, float wanderDistance, float wanderJitter, Vector3 areaCenter, Vector3 areaSize)
    {
        // Calcular el desplazamiento aleatorio
        Vector3 randomPoint = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * wanderJitter;

        // Actualizar la posición objetivo
        targetPosition += randomPoint;

        // Restringir la posición objetivo al radio de vagar
        targetPosition = entityTransform.position + Vector3.ClampMagnitude(targetPosition - entityTransform.position, wanderRadius);

        // Mantener la posición objetivo dentro de los límites del área
        targetPosition.x = Mathf.Clamp(targetPosition.x, areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2);
        targetPosition.z = Mathf.Clamp(targetPosition.z, areaCenter.z - areaSize.z / 2, areaCenter.z + areaSize.z / 2);

        // Calcular la fuerza de dirección
        Vector3 wanderForce = targetPosition - entityTransform.position;
        return wanderForce.normalized;
    }

    public static Vector3 Seek(Transform entityTransform, Vector3 targetPosition, float speed)
    {
        // Mantener la altura fija del NPC
        targetPosition.y = entityTransform.position.y;

        Vector3 desiredVelocity = (targetPosition - entityTransform.position).normalized * speed;
        Vector3 steering = desiredVelocity - entityTransform.GetComponent<Rigidbody>().velocity;
        steering /= entityTransform.GetComponent<Rigidbody>().mass;
        steering += entityTransform.GetComponent<Rigidbody>().velocity;
        steering.y = 0;
        return steering;
    }

    public static Vector3 Flee(Transform entityTransform, Vector3 targetPosition, float speed)
    {
        // Mantener la altura fija del NPC
        targetPosition.y = entityTransform.position.y;

        Vector3 desiredVelocity = (entityTransform.position - targetPosition).normalized * speed;
        return desiredVelocity - entityTransform.GetComponent<Rigidbody>().velocity;
    }

    
}
