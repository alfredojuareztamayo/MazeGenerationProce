using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class extends the `Maze` class to implement Prim's algorithm for maze generation.
/// It starts with an initial point and progressively adds walls to a list, checking and adding new walls until no more walls are left to check or a maximum number of iterations is reached.
/// </summary>
public class Prims : Maze
{
    /// <summary>
    /// This class, which overrides from the parent class Maze, generates a Crawler but requires a starting point (x, z).
    /// The walls are added to a list, and then we start checking all the walls, adding new ones to the list.
    /// This process continues until there are no more walls to check.
    /// </summary>
    public override void Generate()
    {
        // Starting point of the maze generation
        int x = 2;
        int z = 2;
        // Initialize the starting point as a corridor (0)
        map[x, z] = 0;

        // List of walls to be checked and processed
        List<MapLocation> walls = new List<MapLocation>();
        walls.Add(new MapLocation(x+1, z));
        walls.Add(new MapLocation(x-1, z));
        walls.Add(new MapLocation(x, z+1));
        walls.Add(new MapLocation(x, z-1));

        // Counter to prevent infinite loops
        int countLoop = 0;
        // Continue processing while there are walls to check and the loop count is within limits

        while ( walls.Count > 0 && countLoop < 5000)
        {
            // Randomly select a wall from the list
            int rWall = Random.Range(0, walls.Count);
            x = walls[rWall].x;
            z = walls[rWall].z;
            walls.RemoveAt(rWall);

            // Check if the selected wall leads to a valid corridor
            if (CountSquareNeighbours(x,z) == 1)
            {
                // Set the selected wall location as a corridor
                map[x, z] = 0;

                // Add the neighboring walls to the list
                walls.Add(new MapLocation(x + 1, z));
                walls.Add(new MapLocation(x - 1, z));
                walls.Add(new MapLocation(x, z + 1));
                walls.Add(new MapLocation(x, z - 1));
            }
            // Increment loop counter
            countLoop++;
        }
    }
}
