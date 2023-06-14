using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    public float bobSpeed = 1.0f;      // Adjust this value to control the bobbing speed
    public float bobHeight = 0.2f;     // Adjust this value to control the height of the bobbing
    public float catchSpeed = 3.0f;

    private Vector3 _initialPosition;
    private bool _isBobbing = false;
    private bool _fishCaught = false;
    private int _waitTime = 0;

    public float trembleSpeed = 1.0f;     // Adjust this value to control the trembling speed
    public float trembleAmount = 0.2f;    // Adjust this value to control the amount of trembling

    private bool _isTrembling = false;

    private void Start()
    {
        _initialPosition = transform.position;
        StartBobbing();

        _waitTime = Random.Range(4,21);
        Debug.Log(_waitTime);
        Invoke("FishCaught", _waitTime);
    }

    private void Update()
    {
        Checks();
    }

    public void StartBobbing()
    {
        _isBobbing = true;
    }

    public void StopBobbing()
    {
        _isBobbing = false;
        transform.position = _initialPosition;
    }

    public void StartTrembling()
    {
        _isTrembling = true;
    }

    public void StopTrembling()
    {
        _isTrembling = false;
        transform.position = _initialPosition;
    }

    public void FishCaught(){
        _isBobbing = false;
        _fishCaught = true;
        _isTrembling = true;
    }

    public void Checks(){
        if (_isBobbing)
        {
            // Calculate the new position based on a sine wave
            float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            Vector3 newPosition = _initialPosition + new Vector3(0f, yOffset, 0f);

            // Apply the new position to the sprite
            transform.position = newPosition;
            return;
        }

        // if (_fishCaught){
        //     if(transform.position.y < -6){
        //         return;
        //     }

        //     Vector3 newPosition = transform.position - new Vector3(0f, (catchSpeed * Time.deltaTime), 0f);

        //     // Apply the new position to the sprite
        //     transform.position = newPosition;
        // }

        if (_isTrembling)
        {
            // Calculate the trembling offset based on Perlin noise
            float xOffset = Mathf.PerlinNoise(0f, Time.time * trembleSpeed) * trembleAmount;
            float yOffset = Mathf.PerlinNoise(Time.time * trembleSpeed, 0f) * trembleAmount;

            // Apply the trembling offset to the sprite's position
            Vector3 newPosition = _initialPosition + new Vector3(xOffset, yOffset, 0f);
            transform.position = newPosition;
        }
    }
}

