using UnityEngine;
using TMPro;

public class ChangeDescription : MonoBehaviour
{
    public static ChangeDescription Instance;
    public TextMeshProUGUI descriptionText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowDescription(string description)
    {
        descriptionText.text = description;
    }
}
