using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;  // Player's movement speed
    public float mouseSensitivity = 100.0f;  // Sensitivity of mouse movement
    private CharacterController controller;  // Player's CharacterController component
    private float verticalRotation = 0.0f;  // To keep track of the vertical rotation
    public Camera cameraPlayer;
    public float clampCameraTop, clampCameraBottom;

    // Variables para la gravedad y el salto
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;

    public GameObject pointToTeleport;
    private Transform originalParent;

    void Start()
    {
        speed = GetComponent<PlayerStats>().GetSpeed();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
        originalParent = transform.parent;
    }

    void Update()
    {
        speed = GetComponent<PlayerStats>().GetSpeed();

        // Comprobar si el personaje está en el suelo
        isGrounded = controller.isGrounded;

        // Resetear la velocidad en Y si el personaje está en el suelo
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Pequeño empuje hacia abajo para asegurar que el personaje se quede pegado al suelo
        }

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

        // Saltar
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;

        // Mover al jugador basado en la velocidad calculada
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            TeleportToBase();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Platform"))
        {
            transform.SetParent(hit.collider.transform);
        }
        else
        {
            transform.SetParent(originalParent);
        }
    }

    public void TeleportToBase()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false; // Deshabilitar el CharacterController
            transform.position = pointToTeleport.transform.position;
            characterController.enabled = true; // Habilitar el CharacterController
        }
        else
        {
            transform.position = pointToTeleport.transform.position;
        }
    }
}