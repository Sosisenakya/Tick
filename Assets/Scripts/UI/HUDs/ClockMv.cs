using UnityEngine;
using System.Collections;

public class ClockMv : MonoBehaviour
{
    public static ClockMv Instance;

    public RectTransform hourHand, minuteHand;
    public CanvasGroup effectCanvas;

    public DialougeAction dialougeScript;
    public FadeEffect fadeScript;
    public ShardCounter counterScript;
    public TimestopEffect colorScript;

    private bool isPaused = false;
    public bool isStopCooldown = false;
    private float totalMinutes;
    private int totalTimeStop;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    void Update()
    {
        UpdateClock();
    }

    public void IncrementTotalTimestop() {
        totalTimeStop++;
    }
    
    public IEnumerator StopEffect()
    {
        isStopCooldown = true;
        counterScript.shards += 10;

        fadeScript.SetFadeSpeed(6.5f);
        fadeScript.SetFadeColor(1f, 1f, 1f);
        fadeScript.FadeIn();

        yield return new WaitUntil(() => Mathf.Approximately(fadeScript.fadeCanvas.alpha, 1));

        if (isPaused) colorScript.SetMonochrome();
        if (!isPaused) colorScript.SetMonochrome();

        fadeScript.FadeOut();

        yield return new WaitUntil(() => Mathf.Approximately(fadeScript.fadeCanvas.alpha, 0));

        isStopCooldown = false;
    }

    public void ToggleTime()
    {
        isPaused = !isPaused;
    }

    void UpdateClock()
    {
        if (!isPaused)
        {
            totalMinutes += Time.deltaTime;
        }

        float hourValue = Mathf.Repeat(totalMinutes / 60f, 12);
        float minuteValue = Mathf.Repeat(totalMinutes, 60);

        hourHand.localRotation = Quaternion.Euler(0, 0, -hourValue * 30f);
        minuteHand.localRotation = Quaternion.Euler(0, 0, -minuteValue * 6f);
    }
}
