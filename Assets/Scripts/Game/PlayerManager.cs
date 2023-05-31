using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int PlayerHP;
    public static PlayerManager Instance {get; private set;}

    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        PlayerHP = 100;
    }

    public void DamagePlayer(int dmg){
        PlayerHP -= dmg;
    }
}
