using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// EN: Represents a door that can be opened or closed when the player interacts with it,
/// depending on whether the player has the required key.
/// ES: Representa una puerta que puede abrirse o cerrarse cuando el jugador interactúa con ella,
/// dependiendo de si el jugador tiene la llave requerida.
/// </summary>
public class Door : MonoBehaviour
{
    /// <summary>
    /// EN: Identifier for the door, useful to match it with a key.
    /// ES: Identificador de la puerta, útil para asociarla con una llave.
    /// </summary>
    public int idDoor = 0;

    /// <summary>
    /// EN: Indicates whether the door is currently open.
    /// ES: Indica si la puerta está actualmente abierta.
    /// </summary>
    public bool isOpenDoor = false;

    /// <summary>
    /// EN: Event triggered when the door is opened.
    /// ES: Evento que se ejecuta cuando la puerta se abre.
    /// </summary>
    public UnityEvent OpenDoorEvent = new UnityEvent();

    /// <summary>
    /// EN: Event triggered when the door is closed.
    /// ES: Evento que se ejecuta cuando la puerta se cierra.
    /// </summary>
    public UnityEvent closeDoorEvent = new UnityEvent();

    /// <summary>
    /// EN: Detects collision with the player and attempts to open the door.
    /// ES: Detecta colisión con el jugador e intenta abrir la puerta.
    /// </summary>
    /// <param name="collision">
    /// EN: Collision information from Unity's physics system.
    /// ES: Información de colisión del sistema de físicas de Unity.
    /// </param>
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag =="Player")
        {
            AttempOpenDoor();
        }
    }
    /// <summary>
    /// EN: Detects trigger with the player and attempts to open the door.
    /// ES: Detecta entrada a un trigger con el jugador e intenta abrir la puerta.
    /// </summary>
    /// <param name="other">
    /// EN: Collider that entered the trigger.
    /// ES: El collider que entró al trigger.
    /// </param>
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AttempOpenDoor();
        }
    }
    /// <summary>
    /// EN: Attempts to open the door if the player has the required key and the door is not already open.
    /// ES: Intenta abrir la puerta si el jugador tiene la llave requerida y la puerta no está ya abierta.
    /// </summary>
    public void AttempOpenDoor()
    {
        if (Keyschain.HasKeyPlayer(this) && !isOpenDoor)
        {
            Open();
        }
    }

    /// <summary>
    /// EN: Opens the door, sets the state to open, and invokes the open event.
    /// ES: Abre la puerta, cambia el estado a abierta e invoca el evento de apertura.
    /// </summary>
    public void Open()
    {
        isOpenDoor = true;
        OpenDoorEvent.Invoke();
    }

    /// <summary>
    /// EN: Closes the door, sets the state to closed, and invokes the close event.
    /// ES: Cierra la puerta, cambia el estado a cerrada e invoca el evento de cierre.
    /// </summary>
    public void Close()
    {
        isOpenDoor = false;
        closeDoorEvent.Invoke();

    }

}
