using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;
    public CanvasGroup inventoryCanvasGroup;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void ShowInventoryGUI()
    {
        if (inventoryCanvasGroup.alpha == 0) {
            inventoryCanvasGroup.alpha = 1;
            inventoryCanvasGroup.interactable = true;
            inventoryCanvasGroup.blocksRaycasts = true;
        } else {
            inventoryCanvasGroup.alpha = 0;
            inventoryCanvasGroup.interactable = false;
            inventoryCanvasGroup.blocksRaycasts = false;
        }
    }
    public void ShowAchievementsGUI()
    {
        if (inventoryCanvasGroup.alpha == 0) {
            inventoryCanvasGroup.alpha = 1;
            inventoryCanvasGroup.interactable = true;
            inventoryCanvasGroup.blocksRaycasts = true;
        } else {
            inventoryCanvasGroup.alpha = 0;
            inventoryCanvasGroup.interactable = false;
            inventoryCanvasGroup.blocksRaycasts = false;
        }
    }
    public void ShowQuestsGUI()
    {
        if (inventoryCanvasGroup.alpha == 0) {
            inventoryCanvasGroup.alpha = 1;
            inventoryCanvasGroup.interactable = true;
            inventoryCanvasGroup.blocksRaycasts = true;
        } else {
            inventoryCanvasGroup.alpha = 0;
            inventoryCanvasGroup.interactable = false;
            inventoryCanvasGroup.blocksRaycasts = false;
        }
    }
}