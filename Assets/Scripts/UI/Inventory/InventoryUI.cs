using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public Transform gridParent;

    private List<int> playerInventory = new List<int>();

    void Start()
    {
        playerInventory.Add(1);
        playerInventory.Add(2);

        LoadInventory();
    }

    void LoadInventory()
    {
        foreach (Transform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        foreach (int itemID in playerInventory)
        {
            GameObject newSlot = Instantiate(itemSlotPrefab, gridParent);
            newSlot.GetComponent<ItemSlot>().SetItem(itemID);
        }
    }
}
