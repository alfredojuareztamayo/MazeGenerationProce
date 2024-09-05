using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDialogue : MonoBehaviour
{
    public bool turnOnOffMenu = false;
   // private bool onLenguage = false;
    public GameObject canvasMenu;
    public GameObject canvasLenguage;
    public GameObject canvasManager;
    // Start is called before the first frame update
    void Start()
    {
        if (turnOnOffMenu)
        {
            
            canvasManager.SetActive(turnOnOffMenu);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            turnOnOffMenu = !turnOnOffMenu;
            canvasManager.SetActive(turnOnOffMenu);

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
    public void ChangeToLenguage()
    {
        canvasMenu.SetActive(false);
        canvasLenguage.SetActive(true);

    }
    public void BackMenu()
    {
        canvasMenu.SetActive(true);
        canvasLenguage.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Saliste del juego");
        Application.Quit();

    }
}
