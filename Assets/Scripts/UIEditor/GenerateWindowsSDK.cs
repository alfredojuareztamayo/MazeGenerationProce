using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateWindowsSDK : EditorWindow
{
    [MenuItem("Component/SDK_Sleekhell")]
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
}
