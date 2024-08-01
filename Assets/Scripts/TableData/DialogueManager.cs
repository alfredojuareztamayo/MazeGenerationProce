using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEditor.Progress;

public class DialogueManager : MonoBehaviour
{
    /// <summary>
    /// Referencia a un objeto que lee datos desde un archivo CSV.
    /// </summary>
    public CSVReader reader;

    /// <summary>
    /// Índice para iterar sobre los diálogos.
    /// </summary>
    int iter = 0;

    /// <summary>
    /// Índice para seleccionar el idioma de los diálogos.
    /// </summary>
    int iterLenguage = 0;

    /// <summary>
    /// Lista de elementos de texto a actualizar con datos de CSV.
    /// </summary>
    [Header("List of text to be changed with excel")]
    public List<TMP_Text> list = new List<TMP_Text>();

    /// <summary>
    /// Objeto del menú que se puede activar o desactivar.
    /// </summary>
    public GameObject canvasMenu;

    /// <summary>
    /// Estado del menú (activo o inactivo).
    /// </summary>
    private bool turnOnOffMenu = false;

    /// <summary>
    /// Método que se llama al inicio del juego. Configura la visibilidad del menú según el estado inicial y cambia el idioma de los textos.
    /// </summary>
    void Start()
    {
        canvasMenu.SetActive(turnOnOffMenu);
        ChangeIdiom();
        // Invoke("changeIdiom",0.1f);  //default english,
    }

    /// <summary>
    /// Método que se llama en cada frame. Permite alternar la visibilidad del menú con la tecla Escape y gestiona la pausa del juego y la visibilidad del cursor.
    /// </summary>
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

    /// <summary>
    /// Establece el idioma para los diálogos.
    /// </summary>
    /// <param name="id">Índice del idioma.</param>
    public void SetIdiom(int id)
    {
        iterLenguage = id;
    }

    /// <summary>
    /// Cambia el idioma de los textos en la lista según el idioma seleccionado.
    /// </summary>
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
