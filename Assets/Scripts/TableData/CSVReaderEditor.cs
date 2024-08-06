#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CSVReader))]
public class CSVReaderEditor : Editor
{
    /// <summary>
    /// Propiedad serializada para el campo de datos del archivo de texto.
    /// </summary>
    SerializedProperty textAssetData;

    /// <summary>
    /// Propiedad serializada para la lista de diálogos.
    /// </summary>
    SerializedProperty dialogueList;

    /// <summary>
    /// Propiedad serializada para el número de filas en el CSV.
    /// </summary>
    SerializedProperty rows;

    /// <summary>
    /// Propiedad serializada para el número de columnas en el CSV.
    /// </summary>
    SerializedProperty cols;

    /// <summary>
    /// Se llama cuando el editor se inicializa. Encuentra las propiedades serializadas para ser editadas en el inspector.
    /// </summary>
    void OnEnable()
    {
        textAssetData = serializedObject.FindProperty("textAssetData");
        dialogueList = serializedObject.FindProperty("dialogueList");
        rows = serializedObject.FindProperty("Rows");
        cols = serializedObject.FindProperty("Cols");
    }

    /// <summary>
    /// Se llama cuando el editor se desactiva. Limpia las referencias a las propiedades serializadas.
    /// </summary>
    void OnDisable()
    {
        textAssetData = null;
        dialogueList = null;
        rows = null;
        cols = null;
    }

    /// <summary>
    /// Se llama para dibujar la interfaz de usuario del inspector en el editor. Muestra los campos serializados en el inspector de Unity.
    /// </summary>
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Muestra el campo para el archivo de texto
        EditorGUILayout.PropertyField(textAssetData);

        // Muestra el campo para el número de filas
        EditorGUILayout.PropertyField(rows);

        // Muestra el campo para el número de columnas
        EditorGUILayout.PropertyField(cols);

        // Muestra el campo para la lista de diálogos y permite desplegar elementos anidados
        EditorGUILayout.PropertyField(dialogueList, true);

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
