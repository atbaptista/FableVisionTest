using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingEffect : MonoBehaviour
{
    public float pulseSpeed = 4.0f;  // Adjust this value to control the pulsing speed
    public float minScale = 0.97f;    // Minimum scale of the sprite during pulsing
    public float maxScale = 1.03f;    // Maximum scale of the sprite during pulsing

    private Vector3 initialScale;
    private bool isPulsing = false;

    private void Start()
    {
        initialScale = transform.localScale;
        StartPulsing();
    }

    private void Update()
    {
        if (isPulsing)
        {
            // Calculate the new scale based on a sine wave
            float scaleFactor = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * pulseSpeed) + 1) * 0.5f);

            // Apply the new scale to the sprite
            transform.localScale = initialScale * scaleFactor;
        }
    }

    public void StartPulsing()
    {
        isPulsing = true;
    }

    public void StopPulsing()
    {
        isPulsing = false;
        transform.localScale = initialScale;
    }
}

