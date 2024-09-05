using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManagerOnScene : MonoBehaviour
{
    public StackMaze maze;

    private void Awake()
    {
        int width = PlayerPrefs.GetInt("MazeWidth"); // Valor por defecto 10
        int depth = PlayerPrefs.GetInt("MazeDepth"); // Valor por defecto 10

        maze.width = width;
        maze.depth = depth;
    }
    void Start()
    {
       
    }
}
