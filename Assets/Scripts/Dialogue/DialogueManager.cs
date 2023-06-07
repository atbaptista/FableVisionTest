using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialoguePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginDialogue(){
        DialoguePanel.SetActive(true);
        Dialogue panel = DialoguePanel.GetComponent<Dialogue>();
        panel.textComponent.text = string.Empty;
        panel.StartDialogue();
    }
}
