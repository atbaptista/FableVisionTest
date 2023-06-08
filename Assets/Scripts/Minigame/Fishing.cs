using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public float meterVal;
    public float increaseRate;
    public float decreaseRate;
    public float maxMeterVal; 

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
        if(_isCaught){
            return;
        }
        if(!_isCatching){
            meterVal = Mathf.Clamp(meterVal -= decreaseRate, 0, 101);
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
        meterVal = Mathf.Clamp(meterVal += increaseRate, 0, 101);
    }
}
