using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]
    public class Dialogue
    {
        public string[] Alldialogues;

        public Dialogue(int languageCount)
        {
            Alldialogues = new string[languageCount];
        }
    }

    [System.Serializable]
    public class DialogueList
    {
        public Dialogue[] dialogues;
    }

    public DialogueList dialogueList = new DialogueList();
    public int Rows;
    public int Cols;

    // Start is called before the first frame update
    void Start()
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

    void ReadCSV(int numberOfRows, int numberOfColumns)
    {
        if (textAssetData == null)
        {
            Debug.LogError("textAssetData is null.");
            return;
        }

        string[] dataCSV = textAssetData.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        int tableSize = numberOfRows - 1; // Ignoramos la fila de cabecera
        dialogueList.dialogues = new Dialogue[tableSize];

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
