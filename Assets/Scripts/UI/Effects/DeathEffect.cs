using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class DeathEffect : MonoBehaviour
{
    public Volume volume;

    public VolumeProfile defaultProfile;
    public VolumeProfile deathProfile;

    private Vignette vignette;
    private ColorAdjustments colorAdjustments;

    public Player playerScript;
    public CameraMv cameraScript;
    public FadeEffect fadeScript;
    public CanvasGroup uiCanvasGroup;

    public void TriggerDeathEffect() {
        volume.profile = deathProfile;
        cameraScript.CameraDeath();
        uiCanvasGroup.alpha = 0f;
        if (volume != null && volume.profile.TryGet(out vignette))
        {
            float start = 0f;

            DOTween.To(() => start, 
                x => { 
                    start = x; 
                    vignette.intensity.value = start;
                }, 
                1f, 
                0.7f)
                .SetEase(Ease.Linear);
        }

        StartCoroutine(CloseVignette(0.5f));

        if (deathProfile.TryGet(out colorAdjustments)) {
            Color startColor = Color.white;

            DOTween.To(() => startColor, 
                x => { 
                    startColor = x; 
                    colorAdjustments.colorFilter.value = startColor;
                }, 
                new Color(0f, 0f, 0f), 
                0.55f)
                .SetEase(Ease.Linear);
        }

    }
    private IEnumerator CloseVignette(float duration)
    {
        yield return new WaitForSeconds(0.5f);
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            vignette.intensity.value = Mathf.Lerp(0f, 1f, t);
            vignette.smoothness.value = Mathf.Lerp(0.3f, 1f, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        vignette.intensity.value = 1f;
        vignette.smoothness.value = 1f;
    }
}
