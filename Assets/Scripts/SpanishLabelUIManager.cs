using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Manages the UI display for Spanish object labels
 * Shows labels on the left side of the screen with Best Education B.V. branding
 */

public class SpanishLabelUIManager : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("The panel that contains the label")]
    public GameObject labelPanel;

    [Tooltip("Image component for the Best Education B.V. logo")]
    public Image brandingLogo;

    [Tooltip("Text component for Spanish name")]
    public Text spanishText;

    [Tooltip("Text component for English translation")]
    public Text englishText;

    [Header("Branding Settings")]
    [Tooltip("Show the Best Education B.V. logo")]
    public bool showBranding = true;

    [Header("Animation Settings")]
    [Tooltip("Fade in/out duration")]
    public float fadeDuration = 0.3f;

    private CanvasGroup canvasGroup;
    private Coroutine fadeCoroutine;

    void Start()
    {
        // Get or add CanvasGroup for fading
        if (labelPanel != null)
        {
            canvasGroup = labelPanel.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = labelPanel.AddComponent<CanvasGroup>();
            }

            // Start hidden
            canvasGroup.alpha = 0f;
            labelPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Label Panel not assigned in SpanishLabelUIManager!");
        }
    }

    /// Show the label with the given Spanish and English names
    public void ShowLabel(string spanish, string english, bool showBrandingOption = true)
    {
        if (labelPanel == null) return;

        // Update branding logo visibility
        if (brandingLogo != null)
        {
            brandingLogo.gameObject.SetActive(showBranding && showBrandingOption);
        }

        if (spanishText != null)
        {
            spanishText.text = spanish;
        }

        if (englishText != null)
        {
            englishText.text = $"({english})";
        }

        // Show panel
        labelPanel.SetActive(true);

        // Fade in
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeIn());
    }

    /// Hide the label
    public void HideLabel()
    {
        // Check if label panel is active
        if (labelPanel == null || !labelPanel.activeSelf) return;

        // Fade out
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeOut());
    }

    // Fade in animation
    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }

    // Fade out animation
    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        labelPanel.SetActive(false);
    }
}
