using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CSVReader))]
public class CSVReaderEditor : Editor
{
    SerializedProperty textAssetData;
    SerializedProperty dialogueList;

    void OnEnable()
    {
        textAssetData = serializedObject.FindProperty("textAssetData");
        dialogueList = serializedObject.FindProperty("dialogueList");
    }

    void OnDisable()
    {
        textAssetData = null;
        dialogueList = null;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(textAssetData);

        // Mostrar los diálogos
        EditorGUILayout.PropertyField(dialogueList, true);

        serializedObject.ApplyModifiedProperties();
    }
}