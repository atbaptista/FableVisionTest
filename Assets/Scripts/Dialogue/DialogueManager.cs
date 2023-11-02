using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialoguePanel;

    public void BeginDialogue()
    {
        DialoguePanel.SetActive(true);
        Dialogue panel = DialoguePanel.GetComponent<Dialogue>();
        panel.textComponent.text = string.Empty;
        panel.StartDialogue();
    }
}
