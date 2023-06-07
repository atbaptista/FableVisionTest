using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; 
    public string[] lines; 
    public float textSpeed;

    private int _index;

    private void OnEnable() {
        textComponent.text = string.Empty;
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
        else{ //dialogue finished
            gameObject.SetActive(false);
        }
    }
}
