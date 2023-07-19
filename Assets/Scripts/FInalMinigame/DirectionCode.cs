using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionCode : MonoBehaviour
{
    public ManageDirections directionManager;
    public int thisValue = 0;

    private void OnMouseEnter() {
        //Debug.Log(this.name);
        directionManager.SetMouseCurrentZone(thisValue);
    }
}
