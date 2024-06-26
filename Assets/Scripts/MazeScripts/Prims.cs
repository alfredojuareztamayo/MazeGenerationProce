using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prims : Maze
{


    /// <summary>
    /// This class, which overrides from the parent class Maze, generates a Crawler but requires a starting point (x, z).
    /// The walls are added to a list, and then we start checking all the walls, adding new ones to the list.
    /// This process continues until there are no more walls to check.
    /// </summary>
    public override void Generate()
    {
        int x = 2;
        int z = 2;

        map[x, z] = 0;
        List<MapLocation> walls = new List<MapLocation>();
        walls.Add(new MapLocation(x+1, z));
        walls.Add(new MapLocation(x-1, z));
        walls.Add(new MapLocation(x, z+1));
        walls.Add(new MapLocation(x, z-1));

        int countLoop = 0;

        while ( walls.Count > 0 && countLoop < 5000)
        {
            int rWall = Random.Range(0,walls.Count);
            x = walls[rWall].x;
            z = walls[rWall].z;
            walls.RemoveAt(rWall);
            if(CountSquareNeighbours(x,z) == 1)
            {
                map[x, z] = 0;
                walls.Add(new MapLocation(x + 1, z));
                walls.Add(new MapLocation(x - 1, z));
                walls.Add(new MapLocation(x, z + 1));
                walls.Add(new MapLocation(x, z - 1));
            }
            countLoop++;
        }
    }
}
