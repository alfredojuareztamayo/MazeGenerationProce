using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthByPoints : MonoBehaviour
{

    public int Health = 3;
    public string SceneOfDeath;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    public void ReduceLife(int less)
    {
        Health -= less;
    }

    public void IncreaseLife(int more)
    { Health += more;}

    public int GetHealth()
    {
        return Health;
    }

    public void CheckHealth()
    {
        text.text = Health.ToString() + " x";
        if (Health <= 0)
        {
            SceneManager.LoadScene(SceneOfDeath);
        }
    }
}
