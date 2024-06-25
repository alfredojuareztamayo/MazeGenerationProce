using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public float wanderRadius = 5f;
    public float wanderDistance = 10f;
    public float wanderJitter = 0.5f;
    public float slowingDistance = 5f; // Distancia para el comportamiento arrive
    public float speed = 5f;
    public float perceptionRadius = 10f;
    public float maxHealth = 100f;
    public float currentHealth;
    public float armor = 10f;
    public float damage = 20f;
    public StatusNPC status = StatusNPC.None;
    public Vector3 targetPosition;
    public Vector3 steering = Vector3.zero;
    public  float fixedHeight = 5;
    public Vector3 areaCenter; // Centro del �rea de vagar
    public Vector3 areaSize; // Tama�o del �rea de vagar (ancho, alto, profundidad)

    // Referencia al target
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar la salud
        currentHealth = maxHealth;
        targetPosition = transform.position + Random.insideUnitSphere * wanderRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        float damageTaken = amount - armor;
        if (damageTaken > 0)
        {
            currentHealth -= damageTaken;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implementar comportamiento de muerte
        // Desactivar el NPC, jugar animaci�n de muerte, etc.
        gameObject.SetActive(false);
        Debug.Log("NPC ha muerto.");
    }
    void OnTriggerEnter(Collider other)
    {
        // Si un objeto entra en el �rea de percepci�n, se convierte en el target
        if (other.CompareTag("Player")) // Aseg�rate de que el target tenga el tag "Player"
        {
            target = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el objeto sale del �rea de percepci�n, el target se vuelve null
        if (other.CompareTag("Player")) // Aseg�rate de que el target tenga el tag "Player"
        {
            target = null;
        }
    }

    public virtual void SetFixedHeight(float height)
    {
        fixedHeight = height;
    }
    void OnDrawGizmosSelected()
    {
        // Dibujar el �rea de percepci�n en el editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, perceptionRadius);
    }
    public void ApplySteering(Vector3 steering)
    {
        // Aplicar la fuerza de steering al movimiento del NPC
        Vector3 newPosition = transform.position + steering * Time.deltaTime * speed;

        // Mantener la altura fija
        newPosition.y = fixedHeight;

        // Actualizar la posici�n del NPC
        transform.position = newPosition;
    }
}

public enum StatusNPC
{
    Wander,
    Seek,
    Flee,
    None
}