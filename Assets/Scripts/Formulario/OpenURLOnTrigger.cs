using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EN: Opens a specified URL in the browser when the player enters a trigger zone.
/// ES: Abre una URL especificada en el navegador cuando el jugador entra en una zona de trigger.
/// </summary>
public class OpenURLOnTrigger : MonoBehaviour
{
    /// <summary>
    /// EN: The URL to open when the player enters the trigger (e.g., a Google Form).
    /// ES: La URL que se abrirá cuando el jugador entre en el trigger (ejemplo: un formulario de Google).
    /// </summary>
    public string googleFormURL = "https://forms.gle/hribGZE7wfUMJW1Y8";

    /// <summary>
    /// EN: Called when another object with a Collider enters the trigger zone.
    /// ES: Se llama cuando otro objeto con un Collider entra en la zona del trigger.
    /// </summary>
    /// <param name="other">
    /// EN: The Collider of the object that entered the trigger.
    /// ES: El Collider del objeto que entró en el trigger.
    /// </param>
    private void OnTriggerEnter(Collider other)
    {
        /// <summary>
        /// EN: Checks if the object entering the trigger is the player.
        /// ES: Verifica si el objeto que entra en el trigger es el jugador.
        /// </summary>
        if (other.CompareTag("Player"))
        {
            /// <summary>
            /// EN: Logs a debug message indicating that the form has been opened.
            /// ES: Registra un mensaje en la consola indicando que se abrió el formulario.
            /// </summary>
            Application.OpenURL(googleFormURL);
            Debug.Log("Formulario abierto: " + googleFormURL);
        }
    }
}
