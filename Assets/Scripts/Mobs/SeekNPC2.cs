using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekNPC2 : MonoBehaviour
{
    public Transform target;  // Objetivo al que buscar o huir
    public float speed = 5f;
    public float fleeDistance = 10f;
    public bool SeekerNPC = true;
    private Rigidbody rb;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 steering;
        if (!SeekerNPC)
        {
        // Si el NPC está dentro de cierta distancia, huirá. De lo contrario, buscará el objetivo.
            if (Vector3.Distance(transform.position, target.position) < fleeDistance)
            {
                steering = SteeringBehaviour.Flee(transform, target.position, speed);
                // Aplicar la fuerza de steering
                rb.velocity = steering;
            }
            
            
        }
        else 
        {
            if (Vector3.Distance(transform.position, target.position) > fleeDistance)
            {

                steering = SteeringBehaviour.Seek(transform, target.position, speed);
                // Aplicar la fuerza de steering
                rb.velocity = steering;
            }
        }
        
    }
}
