using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//singleton, keeps track of all player decisions
public class PlayerManager : MonoBehaviour
{
    //-1, 0, 1 correspond to bad, neutral, and good player choices
    public int optionOne {get; private set;}
    public int optionTwo {get; private set;}
    public int optionThree {get; private set;}
    public bool isPaused {get; private set;}

    public static PlayerManager Instance {get; private set;}
    
    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        isPaused = false;
    }

    private void Update() {
        //next scene, for debugging
        if(Input.GetKeyDown(KeyCode.Q)){
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextScene == SceneManager.sceneCountInBuildSettings){
                nextScene = 0;
            }
            SceneManager.LoadScene(nextScene);
        }
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

    public void Pause(){
        isPaused = true;
    }

    public void UnPause(){
        isPaused = false;
    }
}
