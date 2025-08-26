using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EN: Static class that manages the player's collected keys.  
/// Provides methods to add keys, check if the player has a key for a door, and clear all keys.  
/// ES: Clase estática que gestiona las llaves recogidas por el jugador.  
/// Proporciona métodos para agregar llaves, verificar si el jugador tiene una llave para una puerta y limpiar todas las llaves.  
/// </summary>
public static class Keyschain
{
    /// <summary>
    /// EN: HashSet storing the IDs of keys collected by the player.  
    /// ES: HashSet que almacena los IDs de las llaves recogidas por el jugador.  
    /// </summary>
    private static HashSet<int> idsKey = new HashSet<int>() { };

    /// <summary>
    /// EN: Adds a key to the player's collection.  
    /// ES: Agrega una llave a la colección del jugador.  
    /// </summary>
    /// <param name="id">EN: The key ID to add. ES: El ID de la llave a agregar.</param>
    public static void AddKeyPlayer(int id)
    {
        idsKey.Add(id);
    }
    /// <summary>
    /// EN: Checks if the player has the key corresponding to the given door.  
    /// ES: Verifica si el jugador tiene la llave correspondiente a la puerta dada.  
    /// </summary>
    /// <param name="door">EN: The door to check. ES: La puerta a verificar.</param>
    /// <returns>EN: True if the player has the key. ES: True si el jugador tiene la llave.</returns>

    public static bool HasKeyPlayer(Door door)
    {
        return idsKey.Contains(door.idDoor); 
    }
    /// <summary>
    /// EN: Clears all collected keys from the player's collection.  
    /// ES: Limpia todas las llaves recogidas de la colección del jugador.  
    /// </summary>
    public static void ClearHashSet()
    {
        idsKey.Clear();
    }
}
