using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueV2 : MonoBehaviour
{
    [Header("PLAYER COMPONENTS")]
    public TextMeshProUGUI playerTextComponent;
    public GameObject playerDialogueBackground;

    [Header("NPC COMPONENTS")]
    public TextMeshProUGUI charTextComponent;
    public GameObject charDialogueBackground;

    [Header("DIALOGUE")]
    public string[] lines;
    public bool[] playerSpeaking;
    public float textSpeed = 0.025f;

    [Header("LOGISTIC STUFF")]
    public bool deactivateSelfAfterText = false;
    public GameObject[] activateAfterText;
    public GameObject[] deactivateAfterText;

    [Header("SOUNDS AND POSES")]
    public GameObject character;
    public AudioClip click;
    // all poses and dialogue sounds will play on the index of the dialogue line that is currently running
    // if there is no change or sound, leave it empty in the inspector
    public Sprite[] characterPoses;
    public AudioClip[] dialogueSound;

    private TextMeshProUGUI _currentTextComponent;
    private int _index;
    private bool _isFinished;

    private void OnEnable()
    {
        // this overrides the inspector value
        textSpeed = 0.025f;

        // set current speaker
        SetCurrentSpeaker();

        _currentTextComponent.text = string.Empty;
        playerTextComponent.text = string.Empty;
        charTextComponent.text = string.Empty;
        _isFinished = false;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerManager.Instance.isPaused);
        bool isPaused = false;
        isPaused = PlayerManager.Instance.isPaused;

        // button clicked while game isn't paused
        if (!isPaused && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            Debug.Log("click");
            SoundManager.Instance.PlayNextUI();
            if (_currentTextComponent.text == lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                _currentTextComponent.text = lines[_index];
            }
        }

        // for debugging
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void StartDialogue()
    {
        _index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        // change pose
        if (characterPoses.Length > _index && characterPoses != null)
        {
            if (characterPoses[_index] != null)
            {
                if (character.GetComponent<Image>() == null)
                {
                    character.GetComponent<SpriteRenderer>().sprite = characterPoses[_index];
                }
                else
                {
                    character.GetComponent<Image>().sprite = characterPoses[_index];
                    character.GetComponent<Image>().SetNativeSize();
                }
            }
        }

        // play audio
        if (dialogueSound.Length > _index && dialogueSound != null)
        {
            if (dialogueSound[_index] != null)
            {
                Debug.Log("playing " + dialogueSound[_index].name);
                SoundManager.Instance.Play(dialogueSound[_index]);
            }
        }

        //display text
        char[] sentence = lines[_index].ToCharArray();
        for (int i = 0; i < sentence.Length; i++)
        {
            // check for rich text tags and print them out all at once to prevent the tags from showing
            if (sentence[i] == '<')
            {
                while (sentence[i] != '>')
                {
                    _currentTextComponent.text += sentence[i];
                    i++;
                }
                _currentTextComponent.text += sentence[i];
            }
            else
            {
                _currentTextComponent.text += sentence[i];
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    private void NextLine()
    {
        if (_index < lines.Length - 1)
        {
            _index++;
            SetCurrentSpeaker();
            _currentTextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        { // dialogue finished, runs this every time next button is clicked when dialogue is done
            if (!_isFinished)
            {
                foreach (GameObject i in activateAfterText)
                {
                    i.SetActive(true);
                }
                foreach (GameObject i in deactivateAfterText)
                {
                    i.SetActive(false);
                }
                _isFinished = true;
                if (deactivateSelfAfterText)
                {
                    this.gameObject.SetActive(false);
                }
                // Debug.Log(this.gameObject.name + " dialogue finished");
            }

            // use button to hide the dialogue box
            // gameObject.SetActive(false);
        }
    }

    private void SetCurrentSpeaker()
    {
        if (playerSpeaking[_index])
        {
            _currentTextComponent = playerTextComponent;
            playerDialogueBackground.SetActive(true);
            charDialogueBackground.SetActive(false);
        }
        else
        {
            _currentTextComponent = charTextComponent;
            playerDialogueBackground.SetActive(false);
            charDialogueBackground.SetActive(true);
        }
    }
}
