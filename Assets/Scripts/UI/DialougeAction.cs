using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialougeAction : MonoBehaviour
{
    public RectTransform dialougeRect;

    public void OpenDialougeBox()
    {
        StartCoroutine(ChangeBoxWidth(0.35f));
        StartCoroutine(ChangeBoxHeight(0.2f));
    }

    IEnumerator ChangeBoxWidth(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newWidth = Mathf.Lerp(0, 100, elapsedTime / duration);
            dialougeRect.sizeDelta = new Vector2(newWidth, dialougeRect.sizeDelta.y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        dialougeRect.sizeDelta = new Vector2(100, dialougeRect.sizeDelta.y);
    }

    IEnumerator ChangeBoxHeight(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float newHeight = Mathf.Lerp(0, 100, elapsedTime / duration);
            dialougeRect.sizeDelta = new Vector2(dialougeRect.sizeDelta.x, newHeight);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        dialougeRect.sizeDelta = new Vector2(dialougeRect.sizeDelta.x, 100);
    }
}
