using UnityEngine;
using System.Collections;

public class RoomTeleporter : MonoBehaviour
{
    public Transform tpPoint;
    public FadeEffect fadeScript;

    void Start()
    {
        fadeScript = FindAnyObjectByType<FadeEffect>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeAndTeleport(other.transform));
        }
    }

    IEnumerator FadeAndTeleport(Transform player)
    {
        fadeScript.SetFadeSpeed(2.3f);
        fadeScript.SetFadeColor(0,0,0);
        fadeScript.FadeIn();
        yield return new WaitUntil(() => fadeScript.fadeCanvas.alpha >= 1);
        player.position = tpPoint.position;
        fadeScript.FadeOut();
        yield return new WaitUntil(() => fadeScript.fadeCanvas.alpha >= 0);
    }
}
