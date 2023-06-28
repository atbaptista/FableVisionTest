using UnityEngine;
using UnityEngine.UI;

public class ZoomInUI : MonoBehaviour
{
    public Image backgroundImage;
    public float zoomSpeed = 0.01f;

    private float targetScale = 1.0f;
    private float currentScale = 1.0f;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();
        // Start with the image at its original scale
        backgroundImage.rectTransform.localScale = Vector3.one;
    }

    private void Update()
    {
        // Gradually increase the target scale
        targetScale += zoomSpeed * Time.deltaTime;

        // Lerp the current scale towards the target scale
        currentScale = Mathf.Lerp(currentScale, targetScale, zoomSpeed * Time.deltaTime);

        //dont zoom in too much, can change the 1.4 to a different size to make it stop at a larger zoom-in size
        currentScale = Mathf.Clamp(currentScale, 1.0f, 1.4f);

        // Apply the new scale to the image
        backgroundImage.rectTransform.localScale = new Vector3(currentScale, currentScale, 1f);
    }
}