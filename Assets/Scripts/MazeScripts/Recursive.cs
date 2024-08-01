using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class extends the `Maze` class to implement a recursive maze generation algorithm.
/// It starts from a random point and recursively generates the maze by carving out paths.
/// </summary>
public class Recursive : Maze
{
    /// <summary>
    /// Initializes the maze generation by selecting a random starting point and calling the recursive generation method.
    /// </summary>
    public override void Generate()
    {
        // Start the maze generation from a random point within the maze boundaries
        Generate(Random.Range(1, width), Random.Range(1, depth));
    }

    /// <summary>
    /// Recursively generates the maze by carving out paths from the current position.
    /// </summary>
    /// <param name="x">The x-coordinate of the current position.</param>
    /// <param name="z">The z-coordinate of the current position.</param>
    void Generate(int x, int z)
    {
        // Stop recursion if the current position has two or more neighboring corridors
        if (CountSquareNeighbours(x, z) >= 2) return;

        // Carve out a path at the current position
        map[x, z] = 0;

        // Shuffle the directions to ensure random path generation
        direction.Shuffle();

        // Recursively generate paths in all four possible directions
        Generate(x + direction[0].x, z + direction[0].z);
        Generate(x + direction[1].x, z + direction[1].z);
        Generate(x + direction[2].x, z + direction[2].z);
        Generate(x + direction[3].x, z + direction[3].z);
    }
}