using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateWindowsSDK : EditorWindow
{
    //[MenuItem("Component/SDK_Sleekhell")]
    //[MenuItem("Component/SDK_Sleekhell/Platforms")]
   
    // Start is called before the first frame update
    public static void ShowWindow()
    {
        GetWindow<GenerateWindowsSDK>("SDK Sleekhell");
    }

    [MenuItem("Component/SDK_Sleekhell/Teleport")]
    private static void TeleportAction()
    {
        // Obtén el GameObject actualmente seleccionado en la escena
        GameObject selectedObject = Selection.activeGameObject;
        if (CheckTagExist("Teleport"))
        {
            selectedObject.tag = "Teleport";
        }
        else
        {
            Debug.Log($"<color=blue>Missing Teleport Tag</color>");
        }
        selectedObject.AddComponent<Teleport>();
        selectedObject.AddComponent<BoxCollider>();
    }

   static bool CheckTagExist(string tagName)
    {
        foreach (string tag in UnityEditorInternal.InternalEditorUtility.tags)
        {
            if (tag == tagName)
            {
                return true;
            }
        }
        return false;
    }
    [MenuItem("GameObject/SDK_Sleekhell/Teleport")]
    private static void CreateTeleportPrefab()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefab/Teleport/TeleportPrefab");
        if (prefab == null)
        {
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name;
            Undo.RegisterCreatedObjectUndo(instance, "Create Teleport Prefab");
        }
        else
        {
            Debug.LogError("<color=blue>Prefab 'Teleport' no encontrado en Resources/Prefab/Teleport/TeleportPrefab.</color>");
        }

    }
    //[MenuItem("Component/SDK_Sleekhell/Platforms")]
    [MenuItem("GameObject/SDK_Sleekhell/Platforms/AtoBPrefab")]
    private static void CreateAtoBPlatform()
    {
       
            GameObject prefab = Resources.Load<GameObject>("Prefab/Platform/PlatformAtoB/AtoBnoTime/PlatformAtoB");
            GameObject prefab2 = Resources.Load<GameObject>("Prefab/Platform/PlatformAtoB/AtoBnoTime/PathsAtoB");
            if (prefab2 != null && prefab !=null)
            {
                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
                Undo.RegisterCreatedObjectUndo(instance, "Create AtoB Platform");
                GameObject instance2 = (GameObject)PrefabUtility.InstantiatePrefab(prefab2);
                instance2.name = prefab2.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
                Undo.RegisterCreatedObjectUndo(instance2, "Create AtoB Platform Path");

            }
            else
            {
                Debug.LogError("<color=blue>Prefab 'AtoB' no encontrado en Resources/Prefabs/atob.</color>");
            }
        
    }

    [MenuItem("Component/SDK_Sleekhell/Platforms/AtoB")]
    private static void CreateAtoBPlatformScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            if(selected.GetComponent<BoxCollider>() == null)
            {
                Undo.AddComponent<BoxCollider>(selected);
            }
           Undo.AddComponent<PlatformPathsAtoB>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }
    }
    [MenuItem("GameObject/SDK_Sleekhell/Platforms/AtoBTimePrefab")]
    private static void CreateToAtoBTimePrefab()
    {
        
            GameObject prefab = Resources.Load<GameObject>("Prefab/Platform/PlatformAtoB/AtoBTime/PlatformAtoBWithTime");
            GameObject prefab2 = Resources.Load<GameObject>("Prefab/Platform/PlatformAtoB/AtoBTime/PathsAtoBWithTime");
            if (prefab2 != null && prefab != null)
            {
                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
                Undo.RegisterCreatedObjectUndo(instance, "Create AtoBTime Platform");
                GameObject instance2 = (GameObject)PrefabUtility.InstantiatePrefab(prefab2);
                instance2.name = prefab2.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
                Undo.RegisterCreatedObjectUndo(instance2, "Create AtoBTime Platform Path");

            }
            else
            {
                Debug.LogError("<color=blue>Prefab 'AtoB' no encontrado en Resources/Prefabs/AtoBTime.</color>");
            }
       
    }
    [MenuItem("Component/SDK_Sleekhell/Platforms/AtoBTime")]
    private static void CreateAtoBWithTimePlatformScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            if (CheckTagExist("Platform"))
            {
                selected.tag = "Platform";
            }
            else
            {
                Debug.Log($"<color=blue>Missing Teleport Tag</color>");
            }
            if (selected.GetComponent<BoxCollider>() == null)
            {
                Undo.AddComponent<BoxCollider>(selected);
            }
            Undo.AddComponent<PlatformPathAtoBTime>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }

    [MenuItem("GameObject/SDK_Sleekhell/Platforms/PlatformPathsPrefab")]
    private static void CreatePlatformPathsPrefab()
    {
        
            GameObject prefab = Resources.Load<GameObject>("Prefab/Platform/PlatformWithPath/PathwithoutTime/PlatformWithPath");
            GameObject prefab2 = Resources.Load<GameObject>("Prefab/Platform/PlatformWithPath/PathwithoutTime/PathsToFollow");
            if (prefab2 != null && prefab != null)
            {
            
                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
                Undo.RegisterCreatedObjectUndo(instance, "Create paths Platform");
                GameObject instance2 = (GameObject)PrefabUtility.InstantiatePrefab(prefab2);
                instance2.name = prefab2.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
                Undo.RegisterCreatedObjectUndo(instance2, "Create paths Platform Path");

            }
            else
            {
                Debug.LogError("<color=blue>Prefab 'AtoB' no encontrado en Resources/Prefabs/PlatformPaths.</color>");
            }
        
    }
    [MenuItem("Component/SDK_Sleekhell/Platforms/PlatformPaths")]
    private static void CreatePlatformPathsScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            if (CheckTagExist("Platform"))
            {
                selected.tag = "Platform";
            }
            else
            {
                Debug.Log($"<color=blue>Missing Platform Tag</color>");
            }
            if (selected.GetComponent<BoxCollider>() == null)
            {
                Undo.AddComponent<BoxCollider>(selected);
            }
            Undo.AddComponent<PlatformWithPath>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }
    [MenuItem("GameObject/SDK_Sleekhell/Platforms/PlatformPathsTimePrefab")]
    private static void CreatePlatformPathsTimePrefab()
    {

        GameObject prefab = Resources.Load<GameObject>("Prefab/Platform/PlatformWithPath/PathwithTime/PlatformWithPathAndTime");
        GameObject prefab2 = Resources.Load<GameObject>("Prefab/Platform/PlatformWithPath/PathwithTime/PathsToFollowTime");
        if (prefab2 != null && prefab != null)
        {

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance, "Create paths Platform time");
            GameObject instance2 = (GameObject)PrefabUtility.InstantiatePrefab(prefab2);
            instance2.name = prefab2.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance2, "Create paths Platform Path time");

        }
        else
        {
            Debug.LogError("<color=blue>Prefab 'PathsWithTime' no encontrado en Resources/Prefabs/PlatformPathsTime.</color>");
        }

    }

    [MenuItem("Component/SDK_Sleekhell/Platforms/PlatformPathsTime")]
    private static void CreatePlatformPathsTimeScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            if (CheckTagExist("Platform"))
            {
                selected.tag = "Platform";
            }
            else
            {
                Debug.Log($"<color=blue>Missing Platform Tag</color>");
            }
            if (selected.GetComponent<BoxCollider>() == null)
            {
                Undo.AddComponent<BoxCollider>(selected);
            }
            Undo.AddComponent<PlatformWithPathAndStop>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }

    [MenuItem("GameObject/SDK_Sleekhell/Maze/Crawler")]
    private static void CreateCrawlerPrefab()
    {

        GameObject prefab = Resources.Load<GameObject>("Prefab/Mazes/Crawler");
        
        if (prefab != null)
        {

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance, "Create Crawler");
            

        }
        else
        {
            Debug.LogError("<color=blue>Prefab Crawler no encontrado en Resources Prefab/Mazes.</color>");
        }

    }
    [MenuItem("GameObject/SDK_Sleekhell/Maze/Prims")]
    private static void CreatePrimsPrefab()
    {

        GameObject prefab = Resources.Load<GameObject>("Prefab/Mazes/Prims");

        if (prefab != null)
        {

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance, "Create Prims");


        }
        else
        {
            Debug.LogError("<color=blue>Prefab Prims no encontrado en ResourcesPrefab/Mazes.</color>");
        }

    }
    [MenuItem("GameObject/SDK_Sleekhell/Maze/Recursive")]
    private static void CreateRecursivePrefab()
    {

        GameObject prefab = Resources.Load<GameObject>("Prefab/Mazes/Recursive");

        if (prefab != null)
        {

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance, "Create Recursive");


        }
        else
        {
            Debug.LogError("<color=blue>Prefab Recursive no encontrado en Resources Prefab/Mazes.</color>");
        }

    }
    [MenuItem("GameObject/SDK_Sleekhell/Maze/StackMaze")]
    private static void CreateStackMazePrefab()
    {

        GameObject prefab = Resources.Load<GameObject>("Prefab/Mazes/StackMaze");

        if (prefab != null)
        {

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance, "Create StackMaze");


        }
        else
        {
            Debug.LogError("<color=blue>Prefab StackMaze no encontrado en ResourcesPrefab/Mazes.</color>");
        }

    }
    [MenuItem("GameObject/SDK_Sleekhell/Maze/Wilson")]
    private static void CreateWilsonPrefab()
    {

        GameObject prefab = Resources.Load<GameObject>("Prefab/Mazes/Wilson");

        if (prefab != null)
        {

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance, "Create Wilson");


        }
        else
        {
            Debug.LogError("<color=blue>Prefab Wilson no encontrado en ResourcesPrefab/Mazes.</color>");
        }

    }
    [MenuItem("GameObject/SDK_Sleekhell/Maze/WilsonWithRooms")]
    private static void CreateWilsonWithRoomsPrefab()
    {

        GameObject prefab = Resources.Load<GameObject>("Prefab/Mazes/WilsonWithRooms");

        if (prefab != null)
        {

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance, "Create WilsonWithRooms");


        }
        else
        {
            Debug.LogError("<color=blue>Prefab WilsonWithRooms no encontrado en ResourcesPrefab/Mazes.</color>");
        }

    }

    [MenuItem("Component/SDK_Sleekhell/Maze/Crawler")]
    private static void CreateCrawlerScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            Undo.AddComponent<Crawler>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }
    [MenuItem("Component/SDK_Sleekhell/Maze/Prims")]
    private static void CreatePrimsScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            Undo.AddComponent<Prims>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }
    [MenuItem("Component/SDK_Sleekhell/Maze/Recursive")]
    private static void CreateRecursiveScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            Undo.AddComponent<Recursive>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }
    [MenuItem("Component/SDK_Sleekhell/Maze/Stack")]
    private static void CreateStackMazeScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            Undo.AddComponent<StackMaze>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }
    [MenuItem("Component/SDK_Sleekhell/Maze/Wilson")]
    private static void CreateWilsonScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            Undo.AddComponent<Wilson>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }
    [MenuItem("Component/SDK_Sleekhell/Maze/WilsonWithRooms")]
    private static void CreateWilsonWithRoomsScript()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected)
        {
            Undo.AddComponent<WilsonWithRooms>(selected);
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
        }

    }
    [MenuItem("GameObject/SDK_Sleekhell/Player/Player")]
    private static void CreatePlayerPrefab()
    {

        GameObject prefab = Resources.Load<GameObject>("Prefab/Player/Player");

        if (prefab != null)
        {

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
            Undo.RegisterCreatedObjectUndo(instance, "Create Player");


        }
        else
        {
            Debug.LogError("<color=blue>Prefab Player no encontrado en Resources Prefab/Player/Player.</color>");
        }

    }
}
