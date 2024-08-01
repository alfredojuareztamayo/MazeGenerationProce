//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class extends the `Maze` class to implement Wilson's algorithm for maze generation with rooms.
/// It creates a maze by performing random walks from unvisited cells until the maze is fully connected.
/// </summary>
public class WilsonWithRooms : Maze
{
    // List to store cells that are not yet used
    List<MapLocation> notUsed = new List<MapLocation>();

    /// <summary>
    /// Starts the maze generation process using Wilson's algorithm.
    /// </summary>
    public override void Generate()
    {
        // Create a random starting point for the maze
        int x = Random.Range(2, width - 2);
        int z = Random.Range(2, depth - 2);
        map[x, z] = 2; // Mark the starting point as part of the maze

        // Continue random walking until only one unvisited cell remains
        while (GetAvailableCells() > 1)
        {
            RandomWalk();
        }
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

        int rStartIndex = Random.Range(0, notUsed.Count); // Choose a random starting cell
        int cx = notUsed[rStartIndex].x;
        int cz = notUsed[rStartIndex].z;

        inWalk.Add(new MapLocation(cx, cz)); // Start the path

        int count = 0;
        bool validPath = false;

        // Perform the random walk while within maze boundaries and not exceeding the iteration limit
        while (cx > 0 && cx < width - 1 && cz > 0 && cz < depth - 1 && count < 5000 && !validPath)
        {
            map[cx, cz] = 0; // Mark the current cell as part of the path
            int index = Random.Range(0, direction.Count);
            int ncx = cx + direction[index].x;
            int ncz = cz + direction[index].z;

            // Check if the neighboring cell has less than two maze neighbors
            if (CountSquareNeighbours(ncx, ncz) < 2)
            {
                cx = ncx;
                cz = ncz;
                inWalk.Add(new MapLocation(cx, cz)); // Add the new cell to the path
            }

            validPath = CountSquareMazeNeighbours(cx, cz) == 1; // Check if the path is valid

            count++;
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
}
/*
 while(CountSquareNeighbours(x, z) !=5 && count < 5000) 
        {
            map[x, z] = 0;
            if (Random.Range(0, 100) < 50)
            {
                x += Random.Range(0, 2);
            }
            else
            {
                z += Random.Range(0, 2);
            }
            count++;
        } 
 */