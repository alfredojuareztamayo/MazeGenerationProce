//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonWithRooms : Maze
{
   

    List<MapLocation> notUsed = new List<MapLocation>();
    public override void Generate()
    {
        //Create a random starting point
        int x = Random.Range(2,width-2);
        int z = Random.Range(2,depth-2);
        map[x, z] = 2;
        while(GetAvalibleCells() > 1)
        {
        RandomWalk(); 
        }

    }

    int GetAvalibleCells()
    {
        notUsed.Clear();
        for(int z = 1; z < depth-1; z++)
        {
            for (int x = 1; x < width-1; x++)
            {
                if (CountSquareMazeNeightbours(x,z) == 0)
                {
                    notUsed.Add(new MapLocation(x,z));
                }
            }
        }
        return notUsed.Count;
    }

    int CountSquareMazeNeightbours(int x, int z)
    {
        int count = 0;
        for(int d = 0; d < direction.Count; d++)
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
        List<MapLocation> inWalk = new List<MapLocation> ();
       
        int rStartIndex = Random.Range(0,notUsed.Count);
        int cx = notUsed[rStartIndex].x;
        int cz = notUsed[rStartIndex].z;
      
        inWalk.Add(new MapLocation(cx, cz));
        int count = 0;
        bool validPath = false;
        while(cx > 0 && cx < width-1 && cz > 0 && cz < depth-1 && count<5000 && !validPath)
        {
            map[cx, cz] = 0;
            int index = Random.Range(0, direction.Count);
            int ncx = cx + direction[index].x;
            int ncz = cz + direction[index].z;
            if(CountSquareNeighbours(ncx, ncz)<2) 
            {
                cx = ncx;
                cz = ncz;
                inWalk.Add(new MapLocation(cx, cz));
            }

            validPath = CountSquareMazeNeightbours(cx, cz) == 1;

            count++;
        }
        if(validPath)
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
            foreach(MapLocation newWalk in inWalk)
            {
                map[newWalk.x, newWalk.z] = 1;
            }
            inWalk.Clear();
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