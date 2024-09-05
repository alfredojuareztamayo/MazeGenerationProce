using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURLOnTrigger : MonoBehaviour
{
    public string googleFormURL = "https://forms.gle/hribGZE7wfUMJW1Y8";

    // Este método se llama cuando otro objeto con un Collider entra en el Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el Trigger es el jugador u otro objeto específico
        if (other.CompareTag("Player"))
        {
            // Abre el navegador con el link especificado
            Application.OpenURL(googleFormURL);
            Debug.Log("Formulario abierto: " + googleFormURL);
        }
    }
}
