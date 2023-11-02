using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// sets UI slider value, should move this code to another script to make it less complicated
public class Meter : MonoBehaviour
{
    public Slider fishMeter;
    public MeterManager meterManager;
    public GameObject[] activateOnFishCaught;

    [HideInInspector]
    public bool isCaught;

    // Start is called before the first frame update
    void Start()
    {
        fishMeter.maxValue = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        fishMeter.value = meterManager.meterVal / meterManager.maxMeterVal;

        if (fishMeter.value == fishMeter.maxValue)
        {
            isCaught = true;
            // moved this funcitonality to the player script
            // foreach(GameObject i in activateOnFishCaught){
            //     i.SetActive(true);
            // }
        }
    }
}
