using UnityEngine;
using UnityEngine.UI;

public class UIFadeController : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration of the fade in seconds
    public Image imageToFadeOut;
    public Image imageToFadeIn;

    private GameObject activatable;

    public void StartFadeTransition()
    {
        StartCoroutine(FadeTransition());
    }

    private System.Collections.IEnumerator FadeTransition()
    {
        Color startColor = imageToFadeOut.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
            imageToFadeOut.color = Color.Lerp(startColor, targetColor, normalizedTime);
            yield return null;
        }

        imageToFadeOut.gameObject.SetActive(false);
        imageToFadeOut.color = startColor;

        imageToFadeIn.gameObject.SetActive(true);
        imageToFadeIn.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        elapsedTime = 0f;
        startColor = imageToFadeIn.color;
        targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
            imageToFadeIn.color = Color.Lerp(startColor, targetColor, normalizedTime);
            yield return null;
        }

        imageToFadeIn.color = targetColor;
    }

    public void ActivateAfterTransition(GameObject obj){
        activatable = obj;
        Invoke("Activate", fadeDuration + 1f);
    }

    private void Activate(){
        activatable.SetActive(true);
    }
}
