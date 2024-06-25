using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;
    [SerializeField] float currentHealth;
    [SerializeField] float armor = 100;
    [SerializeField] float speed = 5f;
    [SerializeField] string Name = "";


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    private void Update()
    {

    }

    private void DiePlayer()
    {
        if (currentHealth <= 0)
        {
            //Die
            gameObject.SetActive(false);
        }
    }
    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public void SetMaxHealth(float health)
    {
        this.MaxHealth = health;
    }
    public float GetCurrentHealth()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
        return currentHealth;
    }

    public void SetCurrentHealth(float health)
    {
        this.currentHealth = health;
    }
    public float GetArmor()
    {
        return armor;
    }

    public void SetArmor(float armor)
    {
        this.armor = armor;
    }

    public void UpgradeAllStats(float health, float armor, float maxHealth, float speed)
    {
        this.currentHealth += health;
        this.armor += armor;
        this.MaxHealth += maxHealth;
        //SetMaxHealth(maxHealth);
        this.speed += speed;
    }
    public void UpgradeHealth(float health)
    {
        float lifeModify = this.currentHealth + health;
        if (lifeModify > MaxHealth)
        {
           // Debug.Log("Entre a esta condicion de vida");
            currentHealth = MaxHealth;
        }
        else
        {
         this.currentHealth += health;
        }
    }
    public void UpgradeMaxHealth(float maxHealth)
    {
        this.MaxHealth -= maxHealth;
    }
    public void UpgradeSpeed(float speed)
    {
        this.speed += speed;
    }
    public void UpgradeArmor(float armor)
    {
        this.armor = armor;
    }

    public string GetName()
    {
        return Name;
    }
}
