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

public class Wilson : Maze
{
    List<MapLocation> direction = new List<MapLocation>()
    {
    new MapLocation(0,1),
    new MapLocation(0,-1),
    new MapLocation(1,0),
    new MapLocation(-1,0)
    };

    List<MapLocation> notUsed = new List<MapLocation>();
    
    [Tooltip("Set the start of the maze")]
    public MazeCoordinates startMaze;

    [Tooltip("Set the final of the maze")]
    public MazeCoordinates finalMaze;

    [Tooltip("Number of enemies to spawn")]
    public int enemies;
   
    public override void Generate()
    {
        //Create a random starting point
        int x = Random.Range(2, width - 2);
        int z = Random.Range(2, depth - 2);

        map[startMaze.x, startMaze.z] = 2;
        map[finalMaze.x, finalMaze.z]=2;

        Vector3 pos = new(finalMaze.x*scale, 0, finalMaze.z*scale);

        GameObject final = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //final.transform.localScale = new(scale, scale, scale);
        final.transform.position = pos;

        Instantiate(player, new Vector3(startMaze.x*scale, 5, startMaze.z * scale), Quaternion.identity);
        


        int runwalkAttempts = width * depth / 3;
        while (GetAvalibleCells() > 1 && runwalkAttempts > 0)
        {
            RandomWalk();
            runwalkAttempts--;
        }

       // GenerateEnemies();
    }

    int GetAvalibleCells()
    {
        notUsed.Clear();
        for (int z = 1; z < depth - 1; z++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                if (CountSquareMazeNeightbours(x, z) == 0)
                {
                    notUsed.Add(new MapLocation(x, z));
                }
            }
        }
        return notUsed.Count;
    }


    int CountSquareMazeNeightbours(int x, int z)
    {
        int count = 0;
        for (int d = 0; d < direction.Count; d++)
        {
            int nx = x + direction[d].x;
            int nz = z + direction[d].z;
            if (map[nx, nz] == 2)
            {
                count++;
            }
        }

        return count;
    }
    void RandomWalk()
    {
        List<MapLocation> inWalk = new List<MapLocation>();

        int rStartIndex = Random.Range(0, notUsed.Count);
        int cx = notUsed[rStartIndex].x;
        int cz = notUsed[rStartIndex].z;

        inWalk.Add(new MapLocation(cx, cz));
        int loop = 0;
        bool validPath = false;

        while (cx > 0 && cx < width - 1 && cz > 0 && cz < depth - 1 &&
                loop < (width * depth) && !validPath)
        {
            map[cx, cz] = 0;
            if (CountSquareMazeNeightbours(cx, cz) > 1)
                break;
            int rd = Random.Range(0, direction.Count);
            int nx = cx + direction[rd].x;
            int nz = cz + direction[rd].z;
            if (CountSquareNeighbours(nx, nz) < 2)
            {
                cx = nx;
                cz = nz;
                inWalk.Add(new MapLocation(cx, cz));
            }

            validPath = CountSquareMazeNeightbours(cx, cz) == 1;
            loop++;
        }
        if (validPath)
        {
            map[cx, cz] = 0;
            foreach (MapLocation newWalk in inWalk)
            {
                map[newWalk.x, newWalk.z] = 2;
            }
            inWalk.Clear();
        }
        else
        {
            foreach (MapLocation newWalk in inWalk)
            {
                map[newWalk.x, newWalk.z] = 1;
            }
            inWalk.Clear();
        }
    }

    void GenerateEnemies()
    {

          for (int z = 1; z < depth - 1; z++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                //Debug.Log(map[x,z]);
                    if (x==startMaze.x && z==startMaze.z)
                    {
                        Debug.Log("Entre a la condicion");
                        continue;
                    }
                    if (map[x, z] == 2  && enemies > 0)
                    {
                      //  Debug.Log();
                        if(Random.Range(0, 100) < 50)
                        {
                            Vector3 pos = new(x * scale, 0, z * scale);
                            GameObject enemiesSpawn = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                            enemiesSpawn.transform.position = pos;
                            enemies--;
                        }
                        enemies--;
                        
                    }
                }
            } 
        
    }
}