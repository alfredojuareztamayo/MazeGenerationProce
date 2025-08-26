using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// EN: Handles scene changes when the player enters a trigger.  
/// ES: Gestiona el cambio de escenas cuando el jugador entra en un trigger.  
/// </summary>
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// EN: Name of the scene to load when the player enters the trigger.  
    /// ES: Nombre de la escena que se cargará cuando el jugador entre en el trigger.  
    /// </summary>
    public string SceneNameToLoad;

    /// <summary>
    /// EN: Called when another collider enters the trigger.  
    /// If the collider belongs to the player, loads the specified scene.  
    /// ES: Se llama cuando otro collider entra en el trigger.  
    /// Si pertenece al jugador, carga la escena especificada.  
    /// </summary>
    /// <param name="other">EN: Collider that entered the trigger. ES: Collider que entró en el trigger.</param>

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(SceneNameToLoad);
        }
    }
}
