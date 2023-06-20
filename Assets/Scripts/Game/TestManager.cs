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

    public void SetTime(float num){
        Time.timeScale = num;
    }
}
