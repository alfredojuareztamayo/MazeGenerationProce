using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class extends the `Maze` class to implement a stack-based maze generation algorithm.
/// The algorithm uses depth-first search to explore and create paths in the maze.
/// </summary>
public class StackMaze : Maze
{
    public GameObject Player;
    public GameObject TeleportToAnotherLevel;
    int id = 0;
    public float offsetYPlayer = 0;
    public List<RoomsCreation> rooms = new List<RoomsCreation>();

    /// <summary>
    /// Starts the maze generation process using a stack-based depth-first search algorithm.
    /// </summary>
    public override void Generate()
    {
        // Initialize the stack and push the starting location onto it
        Stack<MapLocation> stack = new Stack<MapLocation>();
        int t_x = Random.Range(1, width - 1);
        int t_z = Random.Range(1, depth - 1);
        MapLocation start = new MapLocation( t_x,t_z);
        stack.Push(start);
        RoomsCreation roomsCreation = new RoomsCreation(t_x, t_z, id);
        id++;
        rooms.Add(roomsCreation);

        // Continue generating the maze while there are still locations in the stack
        while (stack.Count > 0)
        {
            // Pop the current location from the stack
            MapLocation current = stack.Pop();
            int x = current.x;
            int z = current.z;

            // Check if the current location has fewer than two neighboring maze cells
            if (CountSquareNeighbours(x, z) < 2)
            {
                // Mark the current cell as part of the maze
                map[x, z] = 0;

                RoomsCreation temp = new RoomsCreation(x, z, id);
                id++;
                rooms.Add(temp);
                // Shuffle the directions to ensure randomness in path creation
                direction.Shuffle();

                // Iterate through all possible directions
                foreach (var dir in direction)
                {
                    // Calculate the new location based on the current direction
                    int newX = x + dir.x;
                    int newZ = z + dir.z;

                    // Check if the new location is within bounds and is a wall
                    if (IsInBounds(newX, newZ) && map[newX, newZ] == 1)
                    {
                        // Push the new location onto the stack
                        stack.Push(new MapLocation(newX, newZ));
                    }
                }
            }
        }
    }

    public override void InstantiatePlayer()
    {
        RoomsCreation tempPlayer = rooms.Find(m => m.id == 0);
        RoomsCreation tempTeleport = rooms.Find(m => m.id == (rooms.Count/2));
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = new Vector3((tempPlayer.x * scale) + positionMaze.position.x, positionMaze.position.y, (tempPlayer.z * scale) + positionMaze.position.z);
        Player.GetComponent<CharacterController>().enabled = true;
        Debug.Log(rooms.Count);
       TeleportToAnotherLevel.transform.position = new Vector3((tempTeleport.x * scale) + positionMaze.position.x, positionMaze.position.y, (tempTeleport.z * scale) + positionMaze.position.z);
    }
    /// <summary>
    /// Checks if the given coordinates are within the bounds of the maze.
    /// </summary>
    /// <param name="x">The x-coordinate to check.</param>
    /// <param name="z">The z-coordinate to check.</param>
    /// <returns>True if the coordinates are within bounds, otherwise false.</returns>
    private bool IsInBounds(int x, int z)
    {
        return x >= 0 && x < width && z >= 0 && z < depth;
    }
}