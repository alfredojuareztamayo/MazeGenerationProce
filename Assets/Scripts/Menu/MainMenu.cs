using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// EN: Main menu controller for selecting different maze sizes and exiting the game.
/// ES: Controlador del menú principal para seleccionar diferentes tamaños de laberinto y salir del juego.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// EN: Loads a 10x10 maze by setting PlayerPrefs and switching to the test scene.
    /// ES: Carga un laberinto de 10x10 estableciendo PlayerPrefs y cambiando a la escena de prueba.
    /// </summary>
    public void LoadMaze10x10()
    {
        PlayerPrefs.SetInt("MazeWidth", 10);
        PlayerPrefs.SetInt("MazeDepth", 10);
        SceneManager.LoadScene("Test");
    }
    /// <summary>
    /// EN: Loads a 20x20 maze by setting PlayerPrefs and switching to the test scene.
    /// ES: Carga un laberinto de 20x20 estableciendo PlayerPrefs y cambiando a la escena de prueba.
    /// </summary>
    public void LoadMaze20x20()
    {
        PlayerPrefs.SetInt("MazeWidth", 20);
        PlayerPrefs.SetInt("MazeDepth", 20);
        SceneManager.LoadScene("Test");
    }
    /// <summary>
    /// EN: Loads a 100x100 maze by setting PlayerPrefs and switching to the test scene.
    /// ES: Carga un laberinto de 100x100 estableciendo PlayerPrefs y cambiando a la escena de prueba.
    /// </summary>
    public void LoadMaze100x100()
    {
        PlayerPrefs.SetInt("MazeWidth", 100);
        PlayerPrefs.SetInt("MazeDepth", 100);
        SceneManager.LoadScene("Test");
    }
    /// <summary>
    /// EN: Exits the game. Logs a message in the editor and closes the application when built.
    /// ES: Sale del juego. Muestra un mensaje en el editor y cierra la aplicación cuando está compilado.
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Saliste del juego");
        Application.Quit();
        
    }
}
