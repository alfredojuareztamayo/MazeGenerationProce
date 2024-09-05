using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManagerOnScene : MonoBehaviour
{
    public StackMaze maze;

    void Start()
    {
        int width = PlayerPrefs.GetInt("MazeWidth", 10); // Valor por defecto 10
        int depth = PlayerPrefs.GetInt("MazeDepth", 10); // Valor por defecto 10

        maze.width = width;
        maze.depth = depth;
    }
}
