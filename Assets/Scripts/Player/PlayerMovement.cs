using UnityEngine;


/// <summary>
/// Handles the movement, rotation, jumping, and teleportation of the player character.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float speed;  // Player's movement speed
    public float mouseSensitivity = 100.0f;  // Sensitivity of mouse movement
    private CharacterController controller;  // Player's CharacterController component
    private float verticalRotation = 0.0f;  // To keep track of the vertical rotation
    public Camera cameraPlayer;  // Camera attached to the player
    public float clampCameraTop, clampCameraBottom;  // Clamping values for vertical camera rotation

    // Variables for gravity and jumping
    public float jumpForce = 5f;  // Force applied when the player jumps
    public float gravity = -9.81f;  // Gravity applied to the player
    private Vector3 velocity;  // Current velocity of the player
    private bool isGrounded;  // Flag to check if the player is grounded

    public GameObject pointToTeleport;  // Point to teleport the player to
    private Transform originalParent;  // Original parent transform of the player

    /// <summary>
    /// Initializes the player movement system, locking the cursor and setting up necessary components.
    /// </summary>
    void Start()
    {
        speed = GetComponent<PlayerStats>().GetSpeed();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
        originalParent = transform.parent;
    }

    /// <summary>
    /// Updates the player's movement, rotation, jumping, and teleportation every frame.
    /// </summary>
    void Update()
    {
        // Update speed and jumpForce from PlayerStats
        speed = GetComponent<PlayerStats>().GetSpeed();
        jumpForce = GetComponent<PlayerStats>().GetJump();

        // Check if the player is grounded
        isGrounded = controller.isGrounded;

        // Reset vertical velocity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Small push downward to ensure player stays on the ground
        }

        // Get input for movement
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

        // Apply vertical rotation and clamp it within specified bounds
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -clampCameraBottom, clampCameraTop);

        // Apply the vertical rotation to the camera
        cameraPlayer.transform.localRotation = Quaternion.Euler(verticalRotation, 0.0f, 0.0f);

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity to the velocity
        velocity.y += gravity * Time.deltaTime;

        // Move the player based on calculated velocity
        controller.Move(velocity * Time.deltaTime);

        // Handle teleportation input
        if (Input.GetKeyDown(KeyCode.P))
        {
            TeleportToBase();
        }
    }

    /// <summary>
    /// Handles collision with the platform to set the player's parent to the platform's transform.
    /// </summary>
    /// <param name="hit">Information about the collision.</param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Platform"))
        {
            transform.SetParent(hit.collider.transform);  // Set the player as child of the platform
        }
        else
        {
            transform.SetParent(originalParent);  // Reset the player's parent
        }
    }

    /// <summary>
    /// Teleports the player to a specified point and toggles the CharacterController component.
    /// </summary>
    public void TeleportToBase()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;  // Disable CharacterController to move the player
            transform.position = pointToTeleport.transform.position;  // Set the new position
            characterController.enabled = true;  // Re-enable CharacterController
        }
        else
        {
            transform.position = pointToTeleport.transform.position;  // Teleport without CharacterController
        }
    }
}