using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMaze10x10()
    {
        PlayerPrefs.SetInt("MazeWidth", 10);
        PlayerPrefs.SetInt("MazeDepth", 10);
        SceneManager.LoadScene("Test");
    }

    public void LoadMaze20x20()
    {
        PlayerPrefs.SetInt("MazeWidth", 20);
        PlayerPrefs.SetInt("MazeDepth", 20);
        SceneManager.LoadScene("Test");
    }

    public void LoadMaze100x100()
    {
        PlayerPrefs.SetInt("MazeWidth", 100);
        PlayerPrefs.SetInt("MazeDepth", 100);
        SceneManager.LoadScene("Test");
    }

    public void ExitGame()
    {
        Debug.Log("Saliste del juego");
        Application.Quit();
        
    }
}
