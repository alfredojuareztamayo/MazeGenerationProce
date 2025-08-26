using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EN: Maze generator using a "crawler" algorithm. 
/// Creates horizontal and vertical random paths in the maze.
/// ES: Generador de laberintos usando un algoritmo de "crawler".
/// Crea caminos aleatorios horizontales y verticales en el laberinto.
/// </summary>
public class Crawler : Maze
{
    /// <summary>
    /// EN: Number of horizontal crawlers to generate paths.
    /// ES: Número de crawlers horizontales para generar caminos.
    /// </summary>
    public int numCrawlerH = 3;

    /// <summary>
    /// EN: Number of vertical crawlers to generate paths.
    /// ES: Número de crawlers verticales para generar caminos.
    /// </summary>
    public int numCrawlerV = 2;

    /// <summary>
    /// EN: Main maze generation method. Executes horizontal and vertical crawlers.
    /// ES: Método principal de generación del laberinto. Ejecuta los crawlers horizontales y verticales.
    /// </summary>
    public override void Generate()
    {
        for(int i = 0; i < numCrawlerH; i++)
        {
            CrawlerH();
        }
        for (int j = 0; j < numCrawlerV; j++)
        {
            CrawlerV();
        }
        
        
    }
    /// <summary>
    /// EN: Vertical crawler algorithm. Starts from bottom edge and moves randomly 
    /// to carve vertical paths in the maze.
    /// ES: Algoritmo de crawler vertical. Inicia desde el borde inferior y se mueve aleatoriamente
    /// para crear caminos verticales en el laberinto.
    /// </summary>
    void CrawlerV()
    {
        bool done = false;
        int x = Random.Range(1,width-1);
        int z = 1;
        while (!done)
        {
            map[x, z] = 0;
            if (Random.Range(0, 100) < 50)
            {
                x += Random.Range(-1, 2);
            }
            else
            {
                z += Random.Range(0, 2);
            }


            done |= (x < 1 || x >= width-1 || z < 1 || z >= depth-1);
        }
    }
    /// <summary>
    /// EN: Horizontal crawler algorithm. Starts from left edge and moves randomly
    /// to carve horizontal paths in the maze.
    /// ES: Algoritmo de crawler horizontal. Inicia desde el borde izquierdo y se mueve aleatoriamente
    /// para crear caminos horizontales en el laberinto.
    /// </summary>
    void CrawlerH()
    {
        bool done = false;
        int x = 1;
        int z = Random.Range(1,depth-1);
        while (!done)
        {
            map[x, z] = 0;
            if (Random.Range(0, 100) < 50)
            {
                x += Random.Range(0, 2);
            }
            else
            {
                z += Random.Range(-1, 2);
            }


            done |= (x < 1 || x >= width - 1 || z < 1 || z >= depth - 1);
        }
    }
}
