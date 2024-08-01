using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the player's statistics such as health, armor, speed, and jump.
/// Provides methods to modify and retrieve these statistics.
/// </summary>
public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 100;  // The maximum health the player can have
    [SerializeField] private float currentHealth;     // The current health of the player
    [SerializeField] private float armor = 100;       // The player's armor value
    [SerializeField] private float speed = 5f;        // The speed at which the player moves
    [SerializeField] private float jump = 1f;         // The player's jump height
    [SerializeField] private string Name = "";        // The name of the player

    /// <summary>
    /// Initializes the player's current health to the maximum health at the start.
    /// </summary>
    void Start()
    {
        currentHealth = MaxHealth;
    }

    private void Update()
    {
        // Update logic can be added here if needed
    }

    /// <summary>
    /// Handles the player's death by deactivating the game object if health is zero or less.
    /// </summary>
    private void DiePlayer()
    {
        if (currentHealth <= 0)
        {
            // Die
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Gets the current speed of the player.
    /// </summary>
    /// <returns>The player's speed.</returns>
    public float GetSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Sets the player's speed to a new value.
    /// </summary>
    /// <param name="speed">The new speed value.</param>
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    /// <summary>
    /// Gets the maximum health of the player.
    /// </summary>
    /// <returns>The maximum health value.</returns>
    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    /// <summary>
    /// Sets the player's maximum health to a new value.
    /// </summary>
    /// <param name="health">The new maximum health value.</param>
    public void SetMaxHealth(float health)
    {
        this.MaxHealth = health;
    }

    /// <summary>
    /// Gets the current health of the player. Ensures health is not negative.
    /// </summary>
    /// <returns>The current health value.</returns>
    public float GetCurrentHealth()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        return currentHealth;
    }

    /// <summary>
    /// Sets the player's current health to a new value.
    /// </summary>
    /// <param name="health">The new current health value.</param>
    public void SetCurrentHealth(float health)
    {
        this.currentHealth = health;
    }

    /// <summary>
    /// Gets the player's armor value.
    /// </summary>
    /// <returns>The armor value.</returns>
    public float GetArmor()
    {
        return armor;
    }

    /// <summary>
    /// Sets the player's armor to a new value.
    /// </summary>
    /// <param name="armor">The new armor value.</param>
    public void SetArmor(float armor)
    {
        this.armor = armor;
    }

    /// <summary>
    /// Upgrades all player stats by the specified amounts.
    /// </summary>
    /// <param name="health">Amount to add to current health.</param>
    /// <param name="armor">Amount to add to armor.</param>
    /// <param name="maxHealth">Amount to add to maximum health.</param>
    /// <param name="speed">Amount to add to speed.</param>
    public void UpgradeAllStats(float health, float armor, float maxHealth, float speed)
    {
        this.currentHealth += health;
        this.armor += armor;
        this.MaxHealth += maxHealth;
        //SetMaxHealth(maxHealth);
        this.speed += speed;
    }

    /// <summary>
    /// Upgrades the player's health by a specified amount, ensuring it does not exceed maximum health.
    /// </summary>
    /// <param name="health">Amount to add to current health.</param>
    public void UpgradeHealth(float health)
    {
        float lifeModify = this.currentHealth + health;
        if (lifeModify > MaxHealth)
        {
            // Debug.Log("Entre a esta condicion de vida");
            currentHealth = MaxHealth;
        }
        else
        {
            this.currentHealth += health;
        }
    }

    /// <summary>
    /// Upgrades the player's maximum health by a specified amount.
    /// </summary>
    /// <param name="maxHealth">Amount to add to maximum health.</param>
    public void UpgradeMaxHealth(float maxHealth)
    {
        this.MaxHealth += maxHealth;
    }

    /// <summary>
    /// Upgrades the player's speed by a specified amount.
    /// </summary>
    /// <param name="speed">Amount to add to speed.</param>
    public void UpgradeSpeed(float speed)
    {
        this.speed += speed;
    }

    /// <summary>
    /// Upgrades the player's armor by a specified amount.
    /// </summary>
    /// <param name="armor">Amount to add to armor.</param>
    public void UpgradeArmor(float armor)
    {
        this.armor += armor;
    }

    /// <summary>
    /// Gets the name of the player.
    /// </summary>
    /// <returns>The player's name.</returns>
    public string GetName()
    {
        return Name;
    }

    /// <summary>
    /// Upgrades the player's jump height by a specified amount.
    /// </summary>
    /// <param name="_jump">Amount to add to the jump height.</param>
    public void UpgradeJump(float _jump)
    {
        this.jump += _jump;
    }

    /// <summary>
    /// Gets the player's jump height.
    /// </summary>
    /// <returns>The jump height.</returns>
    public float GetJump()
    {
        return this.jump;
    }
}