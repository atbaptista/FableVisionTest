using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TrackNumberCatches : MonoBehaviour
{
    [Header("Components")]
    public Image itemImage;
    public TextMeshProUGUI itemDescription;
    public GameObject[] miniIcons;

    [Header("Situationals")]
    public string[] itemText;
    public Sprite[] itemSprites;

    [Header("Buttons")]
    public GameObject continueButton;
    public GameObject nextSceneButton;
    

    private int numCatches = 0;


    private void OnEnable() {
        itemImage.sprite = itemSprites[numCatches];
        itemImage.SetNativeSize();

        itemDescription.text = itemText[numCatches];

        miniIcons[numCatches].SetActive(true);
        miniIcons[numCatches].GetComponent<Image>().SetNativeSize();

        if(numCatches >= 2){
            continueButton.SetActive(false);
            nextSceneButton.SetActive(true);
        }
        numCatches++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void Catch(){
    //     numCatches++;
    // }
}
