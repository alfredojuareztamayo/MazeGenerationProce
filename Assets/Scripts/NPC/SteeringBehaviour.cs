using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{
    public static Vector3 Wander(Transform entityTransform, ref Vector3 targetPosition, float wanderRadius, float wanderDistance, float wanderJitter)
    {
        // Calcular el desplazamiento aleatorio
        Vector3 randomPoint = Random.insideUnitSphere * wanderJitter;

        // Actualizar la posición objetivo
        targetPosition += randomPoint;

        // Restringir la posición objetivo al radio de vagar
        targetPosition = entityTransform.position + Vector3.ClampMagnitude(targetPosition - entityTransform.position, wanderRadius);

        // Mover la posición objetivo hacia adelante a la distancia de vagar
        Vector3 targetLocal = targetPosition + entityTransform.forward * wanderDistance;

        // Calcular la fuerza de dirección
        Vector3 wanderForce = targetLocal - entityTransform.position;
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

    public static Vector3 Arrive(Transform entityTransform, Vector3 targetPosition, float speed, float slowingDistance)
    {
        // Mantener la altura fija del NPC
        targetPosition.y = entityTransform.position.y;

        Vector3 toTarget = targetPosition - entityTransform.position;
        float distance = toTarget.magnitude;

        if (distance < 0.1f)
        {
            return Vector3.zero;
        }

        float rampedSpeed = speed * (distance / slowingDistance);
        float clippedSpeed = Mathf.Min(rampedSpeed, speed);
        Vector3 desiredVelocity = toTarget * (clippedSpeed / distance);

        return desiredVelocity - entityTransform.GetComponent<Rigidbody>().velocity;
    }

    public static Vector3 Pursuit(Transform entityTransform, Transform targetTransform, float speed)
    {
        Vector3 toTarget = targetTransform.position - entityTransform.position;
        float relativeHeading = Vector3.Dot(entityTransform.forward, targetTransform.forward);

        if (Vector3.Dot(toTarget, entityTransform.forward) > 0 && relativeHeading < -0.95f)
        {
            return Seek(entityTransform, targetTransform.position, speed);
        }

        float lookAheadTime = toTarget.magnitude / (speed + targetTransform.GetComponent<Rigidbody>().velocity.magnitude);

        return Seek(entityTransform, targetTransform.position + targetTransform.GetComponent<Rigidbody>().velocity * lookAheadTime, speed);
    }

    public static Vector3 Evade(Transform entityTransform, Transform targetTransform, float speed)
    {
        Vector3 toTarget = targetTransform.position - entityTransform.position;
        float lookAheadTime = toTarget.magnitude / (speed + targetTransform.GetComponent<Rigidbody>().velocity.magnitude);

        return Flee(entityTransform, targetTransform.position + targetTransform.GetComponent<Rigidbody>().velocity * lookAheadTime, speed);
    }
}
