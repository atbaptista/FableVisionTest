using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//i think i can delete this
public class ThreeDManager : MonoBehaviour
{
    public GameObject FishCaughtUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FishCaught(){
        FishCaughtUI.SetActive(true);
    }
}
