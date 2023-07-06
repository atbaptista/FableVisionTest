using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Header("TEXT DIALOGUE")]
    public TextMeshProUGUI textComponent; 
    public string[] lines; 
    public float textSpeed;

    [Header("LOGISTIC STUFF")]
    public GameObject[] activateAfterText;
    public GameObject[] deactivateAfterText;

    [Header("Sounds and Poses")] 
    public GameObject character;
    //all poses and dialogue sounds will play on the index of the dialogue line that is currently running
    //if there is no change or sound, leave it empty in the inspector
    public Sprite[] characterPoses;
    public AudioClip[] dialogueSound;


    private int _index;
    private bool _isFinished;

    private void OnEnable() {
        //this overrides the inspector value
        textSpeed = 0.025f;
        
        textComponent.text = string.Empty;
        _isFinished = false;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
            if(textComponent.text == lines[_index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[_index];
            }
        }
    }

    public void StartDialogue(){
        _index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        //change pose
        try{
            if(characterPoses[_index] != null){
                character.GetComponent<Image>().sprite = characterPoses[_index];
            }
        } catch(Exception e){
            Debug.Log(e.Data);
        }
        
        //play audio 
        try{
            if(dialogueSound[_index] != null){
                SoundManager.Instance.Play(dialogueSound[_index]);
            }
        } catch(Exception e){
            Debug.Log(e.Data);
        }

        //type each char one at a time
        foreach (char c in lines[_index].ToCharArray()){
            textComponent.text += c; 
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if (_index < lines.Length - 1){
            _index++; 
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{ //dialogue finished, runs this every time next button is clicked when dialogue is done
            
            if(!_isFinished){
                foreach(GameObject i in activateAfterText){
                i.SetActive(true);
                }
                foreach(GameObject i in deactivateAfterText){
                    i.SetActive(false);
                }
                _isFinished = true;
                //Debug.Log(this.gameObject.name + " dialogue finished");
            }
            
            //use button to hide the dialogue box
            //gameObject.SetActive(false);
        }
    }
}
