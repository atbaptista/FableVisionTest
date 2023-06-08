using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int optionOne {get; private set;}
    public int optionTwo {get; private set;}
    public int optionThree {get; private set;}

    public static PlayerManager Instance {get; private set;}
    
    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetOptionOne(int num){
        optionOne = num;
    }

    public void SetOptionTwo(int num){
        optionTwo = num;
    }

    public void SetOptionThree(int num){
        optionThree = num;
    }
}
