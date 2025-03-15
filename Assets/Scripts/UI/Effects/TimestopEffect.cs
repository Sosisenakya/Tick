using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TimestopEffect : MonoBehaviour
{
    public Volume volume;
    private ColorAdjustments colorAdjustments;
    private LensDistortion lensDistortion;
    private bool isGrayscale = false;

    public CanvasGroup effectCanvas;

    void Start()
    {
        if (volume != null && volume.profile.TryGet(out colorAdjustments))
        {
            colorAdjustments.saturation.value = 0f;
        }
        if (volume != null && volume.profile.TryGet(out lensDistortion)) {
            lensDistortion.intensity.value = 0f;
        }
    }

    public void SetMonochrome() {
        isGrayscale = !isGrayscale;
        if (isGrayscale == true) {
            colorAdjustments.saturation.value = -100f;
            lensDistortion.intensity.value = 0.2f;
            effectCanvas.alpha = 1;
        } else {
            colorAdjustments.saturation.value = 0f;
            lensDistortion.intensity.value = 0f;
            effectCanvas.alpha = 0;
        }
    }
}
