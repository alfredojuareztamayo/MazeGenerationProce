using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MazeCoordinates
{
    public int x;
    public int z;
}

[System.Serializable]
public struct MazeCoordinatesStart
{
    public int x;
    public int z;
}


/// <summary>
/// This class extends the `Maze` class to implement Wilson's algorithm for maze generation.
/// It creates a maze by performing random walks from unvisited cells until the maze is fully connected.
/// The maze can be initialized with a specific start and end point, and can spawn enemies at specific locations.
/// </summary>
public class Wilson : Maze
{
    // List to store cells that are not yet used
    List<MapLocation> notUsed = new List<MapLocation>();

    [Tooltip("Set the start of the maze")]
    public MazeCoordinates startMaze; // Coordinates for the starting point of the maze

    [Tooltip("Set the final of the maze")]
    public MazeCoordinates finalMaze; // Coordinates for the ending point of the maze

    [Tooltip("Number of enemies to spawn")]
    public int enemies; // Number of enemies to spawn in the maze

    /// <summary>
    /// Starts the maze generation process using Wilson's algorithm.
    /// </summary>
    public override void Generate()
    {
        // Set the starting and ending points of the maze
        map[startMaze.x, startMaze.z] = 2;
        map[finalMaze.x, finalMaze.z] = 2;

        // Create a visual representation of the ending point
        Vector3 pos = new(finalMaze.x * scale, 0, finalMaze.z * scale);
        GameObject final = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        final.transform.position = pos;

        // Perform random walks to create the maze
        int runwalkAttempts = width * depth / 3;
        while (GetAvailableCells() > 1 && runwalkAttempts > 0)
        {
            RandomWalk();
            runwalkAttempts--;
        }

        // Uncomment to generate enemies in the maze
        // GenerateEnemies();
    }

    /// <summary>
    /// Retrieves the count of cells that are not yet used in the maze.
    /// </summary>
    /// <returns>The number of available cells.</returns>
    int GetAvailableCells()
    {
        notUsed.Clear(); // Clear the list of unused cells

        // Iterate through the maze grid to find cells with no neighboring maze cells
        for (int z = 1; z < depth - 1; z++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                if (CountSquareMazeNeighbours(x, z) == 0)
                {
                    notUsed.Add(new MapLocation(x, z)); // Add unused cells to the list
                }
            }
        }
        return notUsed.Count; // Return the count of available cells
    }

    /// <summary>
    /// Counts the number of neighboring cells that are part of the maze.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="z">The z-coordinate of the cell.</param>
    /// <returns>The number of neighboring cells that are part of the maze.</returns>
    int CountSquareMazeNeighbours(int x, int z)
    {
        int count = 0;
        for (int d = 0; d < direction.Count; d++)
        {
            int nx = x + direction[d].x;
            int nz = z + direction[d].z;
            if (map[nx, nz] == 2) // Check if the neighbor is part of the maze
            {
                count++;
            }
        }
        return count;
    }

    /// <summary>
    /// Performs a random walk from a starting cell to find a path and update the maze map.
    /// </summary>
    void RandomWalk()
    {
        List<MapLocation> inWalk = new List<MapLocation>(); // List to store the current path

        // Choose a random starting cell
        int rStartIndex = Random.Range(0, notUsed.Count);
        int cx = notUsed[rStartIndex].x;
        int cz = notUsed[rStartIndex].z;

        inWalk.Add(new MapLocation(cx, cz)); // Start the path

        int loop = 0;
        bool validPath = false;

        // Perform the random walk while within maze boundaries and not exceeding the iteration limit
        while (cx > 0 && cx < width - 1 && cz > 0 && cz < depth - 1 &&
                loop < (width * depth) && !validPath)
        {
            map[cx, cz] = 0; // Mark the current cell as part of the path
            if (CountSquareMazeNeighbours(cx, cz) > 1)
                break; // Stop the walk if the cell has more than one neighbor

            // Randomly choose a direction to move
            int rd = Random.Range(0, direction.Count);
            int nx = cx + direction[rd].x;
            int nz = cz + direction[rd].z;
            if (CountSquareNeighbours(nx, nz) < 2)
            {
                cx = nx;
                cz = nz;
                inWalk.Add(new MapLocation(cx, cz)); // Add the new cell to the path
            }

            // Check if the path is valid
            validPath = CountSquareMazeNeighbours(cx, cz) == 1;
            loop++;
        }

        // Finalize the path or revert changes if the path is invalid
        if (validPath)
        {
            map[cx, cz] = 0; // Mark the last cell of the path
            foreach (MapLocation newWalk in inWalk)
            {
                map[newWalk.x, newWalk.z] = 2; // Update the maze with the valid path
            }
            inWalk.Clear(); // Clear the path list
        }
        else
        {
            foreach (MapLocation newWalk in inWalk)
            {
                map[newWalk.x, newWalk.z] = 1; // Revert the changes for an invalid path
            }
            inWalk.Clear(); // Clear the path list
        }
    }

    /// <summary>
    /// Spawns enemies at random positions in the maze.
    /// </summary>
    void GenerateEnemies()
    {
        for (int z = 1; z < depth - 1; z++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                if (x == startMaze.x && z == startMaze.z)
                {
                    // Skip the starting point
                    continue;
                }
                if (map[x, z] == 2 && enemies > 0)
                {
                    if (Random.Range(0, 100) < 50)
                    {
                        Vector3 pos = new(x * scale, 0, z * scale);
                        GameObject enemySpawn = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                        enemySpawn.transform.position = pos;
                        enemies--; // Decrement the number of enemies left to spawn
                    }
                }
            }
        }
    }
}