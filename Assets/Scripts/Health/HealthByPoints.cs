using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/// <summary>
/// EN: Manages the player's health using points. Displays health on screen and loads a scene when health reaches zero.
/// ES: Administra la salud del jugador usando puntos. Muestra la salud en pantalla y carga una escena cuando la salud llega a cero.
/// </summary>

public class HealthByPoints : MonoBehaviour
{

    /// <summary>
    /// EN: Current health value of the player.
    /// ES: Valor actual de salud del jugador.
    /// </summary>
    public int Health = 3;

    /// <summary>
    /// EN: Name of the scene to load when health reaches zero (death scene).
    /// ES: Nombre de la escena que se cargará cuando la salud llegue a cero (escena de muerte).
    /// </summary>
    public string SceneOfDeath;

    /// <summary>
    /// EN: UI text element that displays the current health on screen.
    /// ES: Elemento de texto UI que muestra la salud actual en pantalla.
    /// </summary>
    public TMP_Text text;

    /// <summary>
    /// EN: Unity's Start method, called before the first frame update.
    /// ES: Método Start de Unity, llamado antes de la primera actualización de frame.
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// EN: Unity's Update method, called once per frame. Constantly checks player's health.
    /// ES: Método Update de Unity, llamado una vez por frame. Revisa constantemente la salud del jugador.
    /// </summary>
    void Update()
    {
        CheckHealth();
    }
    /// <summary>
    /// EN: Reduces the player's health by a given amount.
    /// ES: Reduce la salud del jugador en una cantidad específica.
    /// </summary>
    /// <param name="less">
    /// EN: Amount to subtract from health.
    /// ES: Cantidad a restar de la salud.
    /// </param>
    public void ReduceLife(int less)
    {
        Health -= less;
    }
    /// <summary>
    /// EN: Increases the player's health by a given amount.
    /// ES: Incrementa la salud del jugador en una cantidad específica.
    /// </summary>
    /// <param name="more">
    /// EN: Amount to add to health.
    /// ES: Cantidad a sumar a la salud.
    /// </param>
    public void IncreaseLife(int more)
    { Health += more;}
    /// <summary>
    /// EN: Returns the current health value.
    /// ES: Devuelve el valor actual de la salud.
    /// </summary>
    /// <returns>
    /// EN: Current health points.
    /// ES: Puntos de salud actuales.
    /// </returns>
    public int GetHealth()
    {
        return Health;
    }
    /// <summary>
    /// EN: Updates the health text on screen and loads the death scene if health is zero or below.
    /// ES: Actualiza el texto de la salud en pantalla y carga la escena de muerte si la salud es cero o menor.
    /// </summary>
    public void CheckHealth()
    {
        text.text = Health.ToString() + " x";
        if (Health <= 0)
        {
            SceneManager.LoadScene(SceneOfDeath);
        }
    }
}
