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
    public int depth = 30;
    public int width = 30;

    public byte[,] map;

    public int scale = 6;

    // Start is called before the first frame update
    void Start()
    {
        InitialiseMap();
        Generate();
        DrawMap();
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
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 pos = new (x*scale, 0, z*scale);
                if (map[x, z] == 1)
                {
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.localScale = new(scale,scale,scale);
                    wall.transform.position = pos;
                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}