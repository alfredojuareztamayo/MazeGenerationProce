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
   
    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = transform.parent.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Name.text = playerStats.GetName();
        Health.text = "Health " + playerStats.GetCurrentHealth().ToString();
        Armor.text = "Armor " + playerStats.GetArmor().ToString();
        Speed.text = "Speed " + playerStats.GetSpeed().ToString();
        HealthBar.size = playerStats.GetCurrentHealth()/ playerStats.GetMaxHealth();
    }
}
