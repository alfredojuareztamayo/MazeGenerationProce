using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Keyschain
{
   private static HashSet<int> idsKey = new HashSet<int>() { };
   
    public static void AddKeyPlayer(int id)
    {
        idsKey.Add(id);
    }
   public static bool HasKeyPlayer(Door door)
    {
        return idsKey.Contains(door.idDoor); 
    }

    public static void ClearHashSet()
    {
        idsKey.Clear();
    }
}
