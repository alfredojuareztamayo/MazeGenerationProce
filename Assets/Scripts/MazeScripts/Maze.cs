using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapLocation
{
    /// <summary>
    /// The x-coordinate of the map location.
    /// </summary>
    public int x;

    /// <summary>
    /// The z-coordinate of the map location.
    /// </summary>
    public int z;

    /// <summary>
    /// Constructor to initialize a map location with x and z coordinates.
    /// </summary>
    /// <param name="_x">The x-coordinate.</param>
    /// <param name="_z">The z-coordinate.</param>
    public MapLocation(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
}
public class Maze : MonoBehaviour
{

    //// <summary>
    /// The height (depth) of the maze.
    /// </summary>
    [Tooltip("This is the depth of your maze")]
    public int depth = 30;

    /// <summary>
    /// The width of the maze.
    /// </summary>
    [Tooltip("This is the Width of your maze")]
    public int width = 30;

    // <summary>
    /// 2D array representing the maze map where 1 = wall and 0 = corridor.
    /// </summary>
    public byte[,] map;

    /// <summary>
    /// The scale of the maze's walls.
    /// </summary>
    [Tooltip("This is the scale of your maze")]
    public int scale = 6;

    /// <summary>
    /// List of possible directions for maze generation.
    /// </summary>
    public List<MapLocation> direction = new List<MapLocation>()
    {
        new MapLocation(0,1),
        new MapLocation(0,-1),
        new MapLocation(1,0),
        new MapLocation(-1,0)
    };

    /// <summary>
    /// Transform for positioning the maze.
    /// </summary>
    public Transform positionMaze;/// <summary>
                                  /// Determines whether the maze is drawn horizontally or vertically.
                                  /// </summary>
    public bool HorizontalOrVertical = false;

    /// <summary>
    /// List of wall GameObjects in the maze.
    /// </summary>
    private List<GameObject> walls = new List<GameObject>();

    /// <summary>
    /// Prefab for the maze walls.
    /// </summary>
    public GameObject WallsCube;

    /// <summary>
    /// Initializes the maze map with walls.
    /// </summary>
    void Start()
    {
        //InitialiseMap();
        //Generate();
        //DrawMap();
    }

    /// <summary>
    /// Initializes the map by setting all cells to walls (1).
    /// </summary>
    void InitialiseMap()
    {
        map = new byte[width, depth];
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                map[x, z] = 1; // 1 = wall and 0 = corridor
            }
        }
    }

    /// <summary>
    /// Generates the maze by randomly setting cells as corridors (0) or walls (1).
    /// </summary>
    public virtual void Generate()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                if (Random.Range(0, 100) < 50)
                {
                    map[x, z] = 0;
                }
            }
        }
    }

    /// <summary>
    /// Draws the maze by instantiating wall prefabs based on the map data.
    /// </summary>
    void DrawMap()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                if (!HorizontalOrVertical)
                {
                    pos = new Vector3((x * scale) + positionMaze.position.x, positionMaze.position.y, (z * scale) + positionMaze.position.z);
                }
                else
                {
                    pos = new Vector3((x * scale) + positionMaze.position.x, (z * scale) + positionMaze.position.y, positionMaze.position.z);
                }
                if (map[x, z] == 1)
                {
                    GameObject wall = Instantiate(WallsCube);
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                    walls.Add(wall);
                }
            }
        }
    }

    /// <summary>
    /// Counts the number of square (cardinal) neighbors that are corridors.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="z">The z-coordinate of the cell.</param>
    /// <returns>The count of square neighbors that are corridors.</returns>
    public int CountSquareNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x - 1, z] == 0) count++;
        if (map[x + 1, z] == 0) count++;
        if (map[x, z + 1] == 0) count++;
        if (map[x, z - 1] == 0) count++;

        return count;
    }

    /// <summary>
    /// Counts the number of diagonal neighbors that are corridors.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="z">The z-coordinate of the cell.</param>
    /// <returns>The count of diagonal neighbors that are corridors.</returns>
    public int CountDiagonalNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x + 1, z + 1] == 0) count++;
        if (map[x + 1, z - 1] == 0) count++;
        if (map[x - 1, z + 1] == 0) count++;
        if (map[x - 1, z - 1] == 0) count++;
        return count;
    }

    /// <summary>
    /// Counts all neighbors (both square and diagonal) that are corridors.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="z">The z-coordinate of the cell.</param>
    /// <returns>The count of all neighbors that are corridors.</returns>
    public int CountAllNeighbours(int x, int z)
    {
        return CountDiagonalNeighbours(x, z) + CountSquareNeighbours(x, z);
    }

    /// <summary>
    /// Resets the maze by destroying existing walls and recreating the maze.
    /// </summary>
    public void ResetMaze()
    {
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
        walls.Clear();

        CreateMaze();
    }

    /// <summary>
    /// Creates a new maze if there are no existing walls.
    /// </summary>
    public void CreateMaze()
    {
        if (walls.Count == 0)
        {
            InitialiseMap();
            Generate();
            DrawMap();
        }
    }

    /// <summary>
    /// Destroys all existing walls and clears the list of wall GameObjects.
    /// </summary>
    public void DestroyMaze()
    {
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
        walls.Clear();
    }
}