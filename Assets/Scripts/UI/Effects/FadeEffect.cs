using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FadeEffect : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public Image fadeImage;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private float fadeSpeed;

    void Update() {
        if (fadeIn == true) {
            if (fadeCanvas.alpha < 1) {
                fadeCanvas.alpha += fadeSpeed * Time.deltaTime;
                if (fadeCanvas.alpha >= 1) {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut == true) {
            if (fadeCanvas.alpha >= 0) {
                fadeCanvas.alpha -= fadeSpeed * Time.deltaTime;
                if (fadeCanvas.alpha == 0) {
                    fadeOut = false;
                }
            }
        }
    }
    public void SetFadeColor(float red, float green, float blue) {
        fadeImage.color = new Color(red, green, blue);
    }
    public void SetFadeSpeed(float speed) {
        fadeSpeed = speed;
    }
    public void FadeIn() {
        fadeIn = true;
    }
    public void FadeOut() {
        fadeOut = true;
    }
}
