using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float trembleSpeed;
    public float trembleAmount;

    private Vector3 _initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the trembling offset based on Perlin noise
        float xOffset = Mathf.PerlinNoise(0f, Time.time * trembleSpeed) * trembleAmount;
        float yOffset = Mathf.PerlinNoise(Time.time * trembleSpeed, 0f) * trembleAmount;

        // Apply the trembling offset to the sprite's position
        Vector3 newPosition = _initialPosition + new Vector3(xOffset, yOffset, 0f);
        transform.position = newPosition;
    }
}
