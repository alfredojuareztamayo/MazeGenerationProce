using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapLocation
{
    public int x;
    public int z;

    public MapLocation(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
}
public class Maze : MonoBehaviour
{

    /// <summary>
    /// height and width of the maze
    /// </summary>
    [Tooltip("This is the depth of your maze")]
    public int depth = 30;
    [Tooltip("This is the Width of your maze")]
    public int width = 30;

    public byte[,] map;

    [Tooltip("This is the scale of your maze")]
    public int scale = 6;

    public List<MapLocation> direction = new List<MapLocation>()
    {
    new MapLocation(0,1),
    new MapLocation(0,-1),
    new MapLocation(1,0),
    new MapLocation(-1,0)
    };

    public Transform positionMaze;
    public bool HorizontalOrVertical = false;
    private List<GameObject> walls = new List<GameObject>();

    public GameObject WallsCube;

    // Start is called before the first frame update
    void Start()
    {
        //InitialiseMap();
       // Generate();
       // DrawMap();
    }
    /// <summary>
    /// Function to initialise the map 
    /// </summary>
    void InitialiseMap()
    {
        map = new byte[width, depth];
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                    map[x, z] = 1;
                // 1 = wall and 0= corridor
            }
        }
    }
    
    /// <summary>
    /// Function
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
    /// Function to fill or draw the map
    /// </summary>

    void DrawMap()
    {
        Vector3 pos = new Vector3(0,0,0);
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                if (!HorizontalOrVertical)
                {
                     pos = new((x * scale) + positionMaze.position.x, positionMaze.position.y, (z * scale) + positionMaze.position.z);
                }
                else
                {
                    pos = new((x * scale) + positionMaze.position.x, (z * scale) + positionMaze.position.y,  positionMaze.position.z);
                }
                if (map[x, z] == 1)
                {
                    //GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject wall = Instantiate(WallsCube);
                    wall.transform.localScale = new(scale,scale,scale);
                    wall.transform.position = pos;
                    walls.Add(wall);
                }

            }
        }
    }
   public int CountSquareNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x-1,z]==0) count++;
        if (map[x+1,z]==0) count++;
        if (map[x,z+1]==0) count++;
        if (map[x,z-1]==0) count++;

        return count;
    }

    public int CountDiagonalNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x+1,z+1]==0) count++;
        if (map[x+1,z-1]==0 ) count++;
        if (map[x-1, z+1] == 0) count++;
        if (map[x-1,z-1] == 0) count++;
        return count;
    }

    public int CountAllNeighbours(int x, int z)
    {
        return CountDiagonalNeighbours(x, z) + CountSquareNeighbours(x,z);
    }

    public void ResetMaze()
    {
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
        walls.Clear();

       CreateMaze();
    }
    public void CreateMaze()
    {
        if(walls.Count == 0)
        {
        InitialiseMap();
        Generate();
        DrawMap();
        }
    }

    public void DestroyMaze()
    {
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
        walls.Clear();
    }
}
