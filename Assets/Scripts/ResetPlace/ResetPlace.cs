using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlace : MonoBehaviour
{
    public Transform pointToReset;
    public int DecreasePointsLife = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Try to get the CharacterController component from the player
            CharacterController characterController = other.GetComponent<CharacterController>();
            

            if (characterController != null)
            {
                // Temporarily disable the CharacterController to avoid teleportation issues
                characterController.enabled = false;
                // Set the player's position to the target teleport point
                other.transform.position = pointToReset.position;
                // Re-enable the CharacterController after teleportation
                characterController.enabled = true;

                other.GetComponent<HealthByPoints>().ReduceLife(DecreasePointsLife);
            }
            else
            {
                // If no CharacterController is found, just move the player directly
                other.transform.position = pointToReset.position;
            }
        }
        else
        {
            // Log a message if an object with the wrong tag enters the trigger zone
            Debug.Log("Objeto con tag incorrecto: " + other.tag);
        }
    }
}
