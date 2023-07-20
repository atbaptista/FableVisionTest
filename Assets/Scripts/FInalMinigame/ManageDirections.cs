using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageDirections : MonoBehaviour
{
    public MeterManager meterManager;
    public int increaseMeterVal = 6;

    private int lastZone;
    private int numZones = 4;

    private void Update() {
        increaseMeterVal = PlayerManager.Instance.minigameDifficulty;
    }

    public void SetMouseCurrentZone(int currentZone){
        switch (lastZone){
            case 1:
                if(currentZone == 2){
                    meterManager.IncreaseMeter(increaseMeterVal);
                }
                break;
            case 2:
                if(currentZone == 3){
                    meterManager.IncreaseMeter(increaseMeterVal);
                }
                break;
            case 3:
                if(currentZone == 4){
                    meterManager.IncreaseMeter(increaseMeterVal);
                }
                break;
            case 4:
                if(currentZone == 1){
                    meterManager.IncreaseMeter(increaseMeterVal);
                }
                break;
        }
        lastZone = currentZone;
    }

    public void SetRate(int val){
        increaseMeterVal = val;
        PlayerManager.Instance.SetDifficulty(val);
    }
}
