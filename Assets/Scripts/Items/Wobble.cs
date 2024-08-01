using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    /// <summary>
    /// Renderer component used to access and modify the material of the GameObject.
    /// </summary>
    Renderer rend;

    /// <summary>
    /// Last position of the GameObject.
    /// </summary>
    Vector3 lastPos;

    /// <summary>
    /// Current velocity of the GameObject.
    /// </summary>
    Vector3 velocity;

    /// <summary>
    /// Last rotation of the GameObject.
    /// </summary>
    Vector3 lastRot;

    /// <summary>
    /// Current angular velocity of the GameObject.
    /// </summary>
    Vector3 angularVelocity;

    /// <summary>
    /// Maximum amount of wobble effect applied to the GameObject.
    /// </summary>
    public float MaxWobble = 0.03f;

    /// <summary>
    /// Speed at which the wobble effect oscillates.
    /// </summary>
    public float WobbleSpeed = 1f;

    /// <summary>
    /// Rate at which the wobble effect recovers to zero.
    /// </summary>
    public float Recovery = 1f;

    /// <summary>
    /// Wobble amount in the X direction.
    /// </summary>
    float wobbleAmountX;

    /// <summary>
    /// Wobble amount in the Z direction.
    /// </summary>
    float wobbleAmountZ;

    /// <summary>
    /// Amount of wobble to add in the X direction.
    /// </summary>
    float wobbleAmountToAddX;

    /// <summary>
    /// Amount of wobble to add in the Z direction.
    /// </summary>
    float wobbleAmountToAddZ;

    /// <summary>
    /// Pulse value used for oscillation.
    /// </summary>
    float pulse;

    /// <summary>
    /// Time variable used for calculating wobble oscillation.
    /// </summary>
    float time = 0.5f;

    /// <summary>
    /// Called before the first frame update. Initializes the Renderer component.
    /// </summary>
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    /// <summary>
    /// Called once per frame. Updates the wobble effect based on velocity and rotation.
    /// </summary>
    private void Update()
    {
        time += Time.deltaTime;

        // Decrease wobble amount over time
        wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * Recovery);
        wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * Recovery);

        // Calculate the pulse for the sine wave
        pulse = 2 * Mathf.PI * WobbleSpeed;
        wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
        wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

        // Apply the wobble values to the shader
        rend.material.SetFloat("_WobbleX", wobbleAmountX);
        rend.material.SetFloat("_WobbleZ", wobbleAmountZ);

        // Calculate the velocity and angular velocity
        velocity = (lastPos - transform.position) / Time.deltaTime;
        angularVelocity = transform.rotation.eulerAngles - lastRot;

        // Update wobble amounts with clamped velocity
        wobbleAmountToAddX += Mathf.Clamp((velocity.x + (angularVelocity.z * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);
        wobbleAmountToAddZ += Mathf.Clamp((velocity.z + (angularVelocity.x * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);

        // Store the current position and rotation for the next frame
        lastPos = transform.position;
        lastRot = transform.rotation.eulerAngles;
    }
}
