using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public List<ItemsBase> items;
    PlayerStats stats;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        AddItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddItems()
    {
        foreach (var item in items)
        {
            Debug.Log(item.itemName);
        }
    }

    public void ApplyEffects(int id)
    {
        ItemsBase itemTemp = items.Find(items => items.itemID == id);
        switch (id)
        {
            case 0:
                stats.UpgradeJump(itemTemp.statsPoints);
            break;
            case 1:
            stats.UpgradeSpeed(itemTemp.statsPoints);
            break;

        }
    }

}
