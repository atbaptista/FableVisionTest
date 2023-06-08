using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingManager : MonoBehaviour
{
    public Slider fishSlider;
    public Fishing fish;

    [HideInInspector]
    public bool isCaught;

    // Start is called before the first frame update
    void Start()
    {
        fishSlider.maxValue = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        fishSlider.value = fish.meterVal/fish.maxMeterVal;
    }
}
