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
    int iterLenguage = 0;
    [Header("List of text to be changed with excel")]
    public List<TMP_Text> list = new List<TMP_Text>();
    public GameObject canvasMenu;
    private bool turnOnOffMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasMenu.SetActive(turnOnOffMenu);
        ChangeIdiom();
        // Invoke("changeIdiom",0.1f);  //default english,
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            turnOnOffMenu = !turnOnOffMenu;
            canvasMenu.SetActive(turnOnOffMenu);
            if (turnOnOffMenu)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.visible = false;
            }
        }
    }
    public void SetIdiom(int id)
    {
        iterLenguage = id;
    }

    public void ChangeIdiom()
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
