using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [Header("Meter Values")]
    public float increaseRate;
    public float maxMeterVal; 
    [HideInInspector] public float meterVal;

    [Header("Decrease Rates")]
    public float minDecreaseRate = 30;
    public float midDecreaseRate = 40;
    public float maxDecreaseRate = 55;
    [HideInInspector] public float decreaseRate;

    private bool _isCaught = false;
    private bool _isCatching = false;
    

    // Start is called before the first frame update
    void Start()
    {
        meterVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDecreaseRate();
        CalculateMeter();
        
    }

    //decreases faster the closer you are to catching the fish
    public void CalculateDecreaseRate(){
        if(_isCaught){
            return;
        }

        if(meterVal < (maxMeterVal * 0.25)){
            decreaseRate = minDecreaseRate;
            return;
        }

        if(meterVal < (maxMeterVal * 0.75)){
            decreaseRate = midDecreaseRate;
            return;
        }

        decreaseRate = maxDecreaseRate;
    }

    public void CalculateMeter(){
        if(_isCaught){
            return;
        }
        if(!_isCatching){
            meterVal = Mathf.Clamp(meterVal -= (decreaseRate * Time.deltaTime), 0, 101);
        }

        if(meterVal > maxMeterVal){
            _isCaught = true;
            meterVal = maxMeterVal;
        }
    }

    private void OnMouseExit() {
        _isCatching = false;
    }

    private void OnMouseOver() {
        if(_isCaught){
            return;
        }
        _isCatching = true;
        meterVal = Mathf.Clamp(meterVal += (increaseRate * Time.deltaTime), 0, 101);
    }
}
