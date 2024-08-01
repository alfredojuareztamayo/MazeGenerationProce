using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    /// <summary>
    /// Text component displaying the player's name.
    /// </summary>
    [Header("attributes")]
    public Text Name;

    /// <summary>
    /// Text component displaying the player's armor.
    /// </summary>
    public Text Armor;

    /// <summary>
    /// Text component displaying the player's speed.
    /// </summary>
    public Text Speed;

    /// <summary>
    /// Text component displaying the player's health.
    /// </summary>
    public Text Health;

    /// <summary>
    /// Scrollbar representing the player's health bar.
    /// </summary>
    public Scrollbar HealthBar;

    /// <summary>
    /// Text component displaying the player's jump value.
    /// </summary>
    public Text Jump;

    /// <summary>
    /// Flag indicating whether the stats should be shown.
    /// </summary>
    private bool showStats = true;

    /// <summary>
    /// Flag indicating whether the canvas is available.
    /// </summary>
    private bool haveCanvas = true;

    /// <summary>
    /// GameObject representing the canvas that displays the player stats.
    /// </summary>
    public GameObject canvasStats;

    /// <summary>
    /// Reference to the PlayerStats component for accessing player data.
    /// </summary>
    private PlayerStats playerStats;

    /// <summary>
    /// Called before the first frame update. Initializes the playerStats reference and canvas visibility.
    /// </summary>
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        if (canvasStats == null)
        {
            haveCanvas = false;
        }
        else
        {
            haveCanvas = true;
            canvasStats.SetActive(false);
        }
    }

    /// <summary>
    /// Called once per frame. Updates the UI elements with the latest player stats and handles canvas visibility.
    /// </summary>
    void Update()
    {
        // Update UI elements with player stats
        Name.text = playerStats.GetName();
        Health.text = "Health " + playerStats.GetCurrentHealth().ToString();
        Armor.text = "Armor " + playerStats.GetArmor().ToString();
        Speed.text = "Speed " + playerStats.GetSpeed().ToString();
        Jump.text = "Jump " + playerStats.GetJump().ToString();
        HealthBar.size = playerStats.GetCurrentHealth() / playerStats.GetMaxHealth();

        // Toggle canvas visibility when 'U' key is pressed
        if (Input.GetKeyDown(KeyCode.U) && haveCanvas)
        {
            ShowCanvasStats();
        }
    }

    /// <summary>
    /// Toggles the visibility of the canvasStats.
    /// </summary>
    private void ShowCanvasStats()
    {
        if (showStats)
        {
            canvasStats.SetActive(true);
            showStats = false;
        }
        else
        {
            canvasStats.SetActive(false);
            showStats = true;
        }
    }
}
