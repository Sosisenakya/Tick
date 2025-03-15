using UnityEngine;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;
    public List<Item> allItems = new List<Item>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadItems();
    }

    void LoadItems()
    {
        allItems.Add(new Item { id = 1, itemName = "Rune of Everything", description = "A powerful rune with unknown properties." });
        allItems.Add(new Item { id = 2, itemName = "Health Potion", description = "Restores 50 HP." });
    }

    public Item GetItemByID(int id)
    {
        return allItems.Find(item => item.id == id);
    }
}
