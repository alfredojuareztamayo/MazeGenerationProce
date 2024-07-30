using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]
    public  class Dialogue
    {
        public string[] Alldialogues;
        
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
        ReadCSV(Rows, Cols);
    }

    void ReadCSV(int numberOfRow, int numberOfColumns)
    {
        string[] dataCSV = textAssetData.text.Split(new String[] { ",", "\n" },StringSplitOptions.None);
        int tableSize = dataCSV.Length / numberOfColumns - 1;
        dialogueList.dialogues = new Dialogue[tableSize];
        for (int i = 0; i < tableSize; i++)
        {
            dialogueList.dialogues[i] = new Dialogue();
            for(int j = 0; j < numberOfRow; j++)
            {
                dialogueList.dialogues[i].Alldialogues[j] = dataCSV[numberOfColumns * (i + 1)];
            }
        }

    }
}
