using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//sets UI slider value, should move this code to another script to make it less complicated
public class FishingManager : MonoBehaviour
{
    public Slider fishSlider;
    public Fishing fish;
    public GameObject NextSceneButton;

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

        if(fishSlider.value == fishSlider.maxValue){
            isCaught = true;
            NextSceneButton.SetActive(true);
        }
    }
}
