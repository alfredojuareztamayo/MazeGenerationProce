using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CSVReader))]
public class CSVReaderEditor : Editor
{
    SerializedProperty textAssetData;
    SerializedProperty dialogueList;
    SerializedProperty rows;
    SerializedProperty cols;

    void OnEnable()
    {
        textAssetData = serializedObject.FindProperty("textAssetData");
        dialogueList = serializedObject.FindProperty("dialogueList");
        rows = serializedObject.FindProperty("Rows");
        cols = serializedObject.FindProperty("Cols");
    }

    void OnDisable()
    {
        textAssetData = null;
        dialogueList = null;
        rows = null;
        cols = null;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(textAssetData);
        EditorGUILayout.PropertyField(rows);
        EditorGUILayout.PropertyField(cols);
        // Mostrar los diálogos
        EditorGUILayout.PropertyField(dialogueList, true);

        serializedObject.ApplyModifiedProperties();
    }
}