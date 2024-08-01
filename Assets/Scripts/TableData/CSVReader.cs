using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    /// <summary>
    /// Archivo de texto que contiene los datos CSV.
    /// </summary>
    public TextAsset textAssetData;
    /// <summary>
    /// Clase que representa un conjunto de diálogos en varios idiomas.
    /// </summary>
    [System.Serializable]
    public class Dialogue
    {
        /// <summary>
        /// Array de cadenas que contiene los diálogos en diferentes idiomas.
        /// </summary>
        public string[] Alldialogues;
        /// <summary>
        /// Constructor para inicializar el array de diálogos.
        /// </summary>
        /// <param name="languageCount">Número de idiomas disponibles.</param>
        public Dialogue(int languageCount)
        {
            Alldialogues = new string[languageCount];
        }
    }
    /// <summary>
    /// Clase que representa una lista de diálogos.
    /// </summary>
    [System.Serializable]
    public class DialogueList
    {
        /// <summary>
        /// Array de objetos `Dialogue`.
        /// </summary>
        public Dialogue[] dialogues;
    }
    /// <summary>
    /// Lista de diálogos a ser cargada desde el CSV.
    /// </summary>
    public DialogueList dialogueList = new DialogueList();
    /// <summary>
    /// Número de filas en el archivo CSV, incluyendo la fila de cabecera.
    /// </summary>
    public int Rows;

    /// <summary>
    /// Número de columnas en el archivo CSV.
    /// </summary>
    public int Cols;

    /// <summary>
    /// Se llama al inicio del juego. Verifica el archivo CSV y lo lee si está asignado.
    /// </summary>
    void Awake()
    {
        if (textAssetData != null)
        {
            ReadCSV(Rows, Cols);
        }
        else
        {
            Debug.LogError("textAssetData is null. Please assign a CSV file in the inspector.");
        }
    }

    /// <summary>
    /// Lee los datos del archivo CSV y llena la lista de diálogos.
    /// </summary>
    /// <param name="numberOfRows">Número de filas en el archivo CSV.</param>
    /// <param name="numberOfColumns">Número de columnas en el archivo CSV.</param>
    void ReadCSV(int numberOfRows, int numberOfColumns)
    {
        if (textAssetData == null)
        {
            Debug.LogError("textAssetData is null.");
            return;
        }

        // Divide el texto CSV en líneas
        string[] dataCSV = textAssetData.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        int tableSize = numberOfRows - 1; // Ignora la fila de cabecera
        dialogueList.dialogues = new Dialogue[tableSize];

        // Lee cada fila de datos y asigna los valores a los diálogos
        for (int i = 0; i < tableSize; i++)
        {
            dialogueList.dialogues[i] = new Dialogue(numberOfColumns);
            string[] rowData = dataCSV[i + 1].Split(new string[] { "," }, StringSplitOptions.None);
            for (int j = 0; j < numberOfColumns; j++)
            {
                dialogueList.dialogues[i].Alldialogues[j] = rowData[j].Trim();
            }
        }
    }
}
