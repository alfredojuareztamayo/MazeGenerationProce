using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject pointToTeleport;
   
    public string TagPLayer;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagPLayer))
        {
           

            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false; // Deshabilitar el CharacterController
                other.transform.position = pointToTeleport.transform.position;
                characterController.enabled = true; // Habilitar el CharacterController
            }
            else
            {
                other.transform.position = pointToTeleport.transform.position;
            }
        }
        else
        {
            Debug.Log("Objeto con tag incorrecto: " + other.tag);
        }
    }
}
