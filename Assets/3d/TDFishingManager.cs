using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TDFishingManager : MonoBehaviour
{
    public Slider fishSlider;
    public TDFishing fish;
    public GameObject[] activateOnFishCaught;

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
            //moved this funcitonality to the player script
            // foreach(GameObject i in activateOnFishCaught){
            //     i.SetActive(true);
            // }
        }
    }
}
