using UnityEngine;
using TMPro;

public class ShardCounter : MonoBehaviour
{
    [SerializeField] private float _shards;

    public float shards {
        get { 
            return _shards; 
        }
        set {
            _shards = value;
            UpdateTextUI();
        }
    }

    public TMP_Text counterText;

    public void UpdateTextUI() {
        if (counterText != null) {
            string totalShardsInString = _shards.ToString();

            if (_shards > 99) {
                counterText.text = totalShardsInString;
            } else if (_shards > 9) {
                counterText.text = string.Format("0{0}", totalShardsInString);
            } else {
                counterText.text = string.Format("00{0}", totalShardsInString);
            }
        }
    }
}
