using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script calculates the fish meter value
public class MeterManager : MonoBehaviour
{
    [Header("Meter Values")]
    public float increaseRate = 50;
    public float maxMeterVal = 100;
    [HideInInspector] public float meterVal;

    [Header("Decrease Rates")]
    public float minDecreaseRate = 25;
    public float midDecreaseRate = 40;
    public float maxDecreaseRate = 60;
    [HideInInspector] public float decreaseRate;

    [Header("Fish Caught Sound")]
    public AudioClip meterMaxSFX;

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

    // decreases faster the closer you are to catching the fish
    public void CalculateDecreaseRate()
    {
        if (_isCaught)
        {
            return;
        }

        if (meterVal < (maxMeterVal * 0.25))
        {
            decreaseRate = minDecreaseRate;
            return;
        }

        if (meterVal < (maxMeterVal * 0.75))
        {
            decreaseRate = midDecreaseRate;
            return;
        }

        decreaseRate = maxDecreaseRate;
    }

    public void CalculateMeter()
    {
        if (_isCaught)
        {
            return;
        }
        if (!_isCatching)
        {
            meterVal = Mathf.Clamp(meterVal -= (decreaseRate * Time.deltaTime), 0, 101);
        }

        if (meterVal >= maxMeterVal)
        {
            _isCaught = true;
            SoundManager.Instance.UISource.Stop();
            SoundManager.Instance.Play(meterMaxSFX);
            meterVal = maxMeterVal;
        }
    }

    public void Reset()
    {
        meterVal = 0;
        _isCaught = false;
        _isCatching = false;
    }

    public void IncreaseMeter(int val)
    {
        if (!_isCaught)
        {
            meterVal += val;
        }
    }

    // private void OnMouseExit() {
    //     _isCatching = false;
    // }

    // private void OnMouseOver() {
    //     if(_isCaught){
    //         return;
    //     }
    //     _isCatching = true;
    //     meterVal = Mathf.Clamp(meterVal += (increaseRate * Time.deltaTime), 0, 101);
    // }
}
