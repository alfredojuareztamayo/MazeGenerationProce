using UnityEngine;

/// <summary>
/// EN: Represents a dungeon tile, storing its transform, the origin tile it was connected from, and its connector.  
/// ES: Representa un tile del dungeon, almacenando su transform, el tile de origen desde el que se conectó y su conector.  
/// </summary>
[System.Serializable]
public class Tile
{
    /// <summary>
    /// EN: Transform of this tile.  
    /// ES: Transform de este tile.  
    /// </summary>
    public Transform tile;

    /// <summary>
    /// EN: Transform of the tile from which this tile originated.  
    /// ES: Transform del tile del que se originó este tile.  
    /// </summary>
    public Transform origin;

    /// <summary>
    /// EN: Connector component used to attach this tile to other tiles.  
    /// ES: Componente Connector usado para conectar este tile a otros tiles.  
    /// </summary>
    public Connector connector;

    /// <summary>
    /// EN: Constructor to initialize a tile with its transform and origin.  
    /// ES: Constructor para inicializar un tile con su transform y su tile de origen.  
    /// </summary>
    /// <param name="_tile">EN: Transform of the tile. ES: Transform del tile.</param>
    /// <param name="_origin">EN: Transform of the origin tile. ES: Transform del tile de origen.</param>


    public Tile(Transform _tile, Transform _origin)
    {
        tile = _tile;
        origin = _origin;

    }
}
