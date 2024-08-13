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


    private void OnGUI()
    {
        
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
    //[MenuItem("Component/SDK_Sleekhell/Platforms")]
    [MenuItem("Component/SDK_Sleekhell/Platforms/AtoBPrefab")]
    private static void CreateAtoBPlatform()
    {
        GameObject selecte = Selection.activeGameObject;
        if (selecte != null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefab/Platform/PlatformAtoB/AtoBnoTime/PlatformAtoB");
            GameObject prefab2 = Resources.Load<GameObject>("Prefab/Platform/PlatformAtoB/AtoBnoTime/PathsAtoB");
            if (prefab2 != null && prefab !=null)
            {
                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab, selecte.transform);
                instance.name = prefab.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
                Undo.RegisterCreatedObjectUndo(instance, "Create AtoB Platform");
                GameObject instance2 = (GameObject)PrefabUtility.InstantiatePrefab(prefab2, selecte.transform);
                instance2.name = prefab2.name; // Opcional: asegura que el nombre del objeto instanciado sea igual al prefab
                Undo.RegisterCreatedObjectUndo(instance2, "Create AtoB Platform Path");

            }
            else
            {
                Debug.LogError("<color=blue>Prefab 'AtoB' no encontrado en Resources/Prefabs/atob.</color>");
            }
        }
        else
        {
            Debug.Log("<color=green>No GameObject Selected</color>");
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
}
