using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EN: Represents a collectible key in the game.  
/// When the player collides with it, the key is added to the player's keychain and the object is destroyed.  
/// ES: Representa una llave coleccionable en el juego.  
/// Cuando el jugador colisiona con ella, la llave se agrega a su llavero y el objeto se destruye.  
/// </summary>

public class Key : MonoBehaviour
{
    /// <summary>
    /// EN: Identifier of the key, used to track which keys the player has collected.  
    /// ES: Identificador de la llave, usado para rastrear cuáles llaves ha recogido el jugador.  
    /// </summary>
    public int keyId;

    /// <summary>
    /// EN: Called when another collider enters this key's trigger.  
    /// If the collider belongs to the player, the key is added to their keychain and the object is destroyed.  
    /// ES: Se llama cuando otro collider entra en el trigger de esta llave.  
    /// Si pertenece al jugador, la llave se agrega a su llavero y el objeto se destruye.  
    /// </summary>
    /// <param name="other">EN: Collider that entered the trigger. ES: Collider que entró en el trigger.</param>

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Keyschain.AddKeyPlayer(keyId);
        }
        Destroy(this.gameObject);
    }
}
