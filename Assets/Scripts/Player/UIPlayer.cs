using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [Header("attributes")]
    public Text Name;
    public Text Armor;
    public Text Speed;
    public Text Health;
    public Scrollbar HealthBar;
    public Text Jump;

    private bool showStats = true;
    private bool haveCanvas = true;
    public GameObject canvasStats;
   
    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        if (canvasStats == null)
        {
            haveCanvas = false;
        }
        else
        {
            haveCanvas = true;
            canvasStats.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        Name.text = playerStats.GetName();
        Health.text = "Health " + playerStats.GetCurrentHealth().ToString();
        Armor.text = "Armor " + playerStats.GetArmor().ToString();
        Speed.text = "Speed " + playerStats.GetSpeed().ToString();
        Jump.text = "Jump " + playerStats.GetJump().ToString();
        HealthBar.size = playerStats.GetCurrentHealth()/ playerStats.GetMaxHealth();
        
        if (Input.GetKeyDown(KeyCode.U) && haveCanvas)
        {
          
            ShowCanvasStats();
        }
        
    }

    private void ShowCanvasStats()
    {
      
        if (showStats)
        {
            canvasStats.SetActive(true);
            showStats = false;
        }
        else
        {
            canvasStats.SetActive(false);
            showStats= true;
        }
    }

}
