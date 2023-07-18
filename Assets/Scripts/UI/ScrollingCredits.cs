using UnityEngine;
using UnityEngine.UI;

public class ScrollingCredits : MonoBehaviour
{
    public float scrollSpeed = 10f;
    public Transform resetPosition; // Adjust this based on the size of your credits text
    public GameObject activateAfterCredits;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Move the credits text upwards
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Reset the position once the credits have scrolled off the screen
        if (rectTransform.anchoredPosition.y >= resetPosition.position.y)
        {
            activateAfterCredits.SetActive(true);
        }
    }
}
