using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;  // Player's movement speed
    public float mouseSensitivity = 100.0f;  // Sensitivity of mouse movement
    private CharacterController controller;  // Player's CharacterController component
    private float verticalRotation = 0.0f;  // To keep track of the vertical rotation
    public Camera cameraPlayer;
    public float clampCameraTop, clampCameraBottom;

    //public GameObject inventoryItem = null;  // Currently held inventory item

    /// <summary>
    /// Initializes the CharacterController component.
    /// </summary>
    void Start()
    {
        speed = GetComponent<PlayerStats>().GetSpeed();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
    }

    /// <summary>
    /// Handles user input for moving the player and picking up/dropping items.
    /// </summary>
    void Update()
    {
        speed = GetComponent<PlayerStats>().GetSpeed();
        // Get user input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Move the player
        controller.Move(movement * speed * Time.deltaTime);

        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Apply horizontal rotation
        transform.Rotate(Vector3.up * mouseX);

        // Apply vertical rotation and clamp it
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -clampCameraBottom, clampCameraTop);

        // Apply the vertical rotation to the camera
        cameraPlayer.transform.localRotation = Quaternion.Euler(verticalRotation, 0.0f, 0.0f);
    }
}
