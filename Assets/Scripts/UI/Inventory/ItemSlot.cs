using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public int itemID;
    public TextMeshProUGUI itemNameText;
    public Button button;

    void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetItem(int id)
    {
        itemID = id;
        Item item = ItemDatabase.Instance.GetItemByID(id);
        itemNameText.text = item.itemName;
    }

    void OnClick()
    {
        Item item = ItemDatabase.Instance.GetItemByID(itemID);
        ChangeDescription.Instance.ShowDescription(item.description);
    }
}
