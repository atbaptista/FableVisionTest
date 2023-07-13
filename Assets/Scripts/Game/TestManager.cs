using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script for button functionality
public class TestManager : MonoBehaviour
{
    public void NextScene(){
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextScene == SceneManager.sceneCountInBuildSettings){
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }

    public void setOptionOne(int num){
        PlayerManager.Instance.SetOptionOne(num);
    }

    public void setOptionTwo(int num){
        PlayerManager.Instance.SetOptionTwo(num);
    }

    public void setOptionThree(int num){
        PlayerManager.Instance.SetOptionThree(num);
    }

    public void SetTime(float num){
        Time.timeScale = num;
    }

    // public void Pause(){
    //     SetTime(0);
    //     PlayerManager.Instance.Pause();
    // }

    // public void UnPause(){
    //     SetTime(1);
    //     PlayerManager.Instance.UnPause();
    // }
}
