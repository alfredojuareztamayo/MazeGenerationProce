using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEditor.Progress;

public class DialogueManager : MonoBehaviour
{
    public CSVReader reader;
    int iter = 0;
    int iterLenguage = 3;
    [Header("List of text to be changed with excel")]
    public List<TMP_Text> list = new List<TMP_Text>();

    // Start is called before the first frame update
    void Start()
    {
        changeIdiom();  
       // Invoke("changeIdiom",0.1f);  //default english,
    }

    public void SetIdiom(int id)
    {
        iterLenguage = id;
    }

    public void changeIdiom()
    {
        if (reader.dialogueList.dialogues.Length == 0)
        {
            Debug.LogError("No dialogues found in CSV data.");
            return;
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (iter < reader.dialogueList.dialogues.Length)
            {
                list[i].text = reader.dialogueList.dialogues[i].Alldialogues[iterLenguage];
                
            }
            else
            {
                Debug.LogError("iter is out of range for the dialogues list.");
            }
        }
    }

}
