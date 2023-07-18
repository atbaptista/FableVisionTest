using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class YakReviews : MonoBehaviour
{
    [Header("Components")]
    public Image icon;
    public Image stars;
    public TextMeshProUGUI reviewTextComponent;
    
    [Header("Character")]
    public int character; //percy -> 1, serena -> 2, bella -> 3

    [Header("Icons")]
    public Sprite goodIcon;
    public Sprite neutralIcon;
    public Sprite badIcon;

    [Header("Stars")]
    public Sprite goodStars;
    public Sprite neutralStars;
    public Sprite badStars;

    [Header("Text")]
    public string goodText;
    public string neutralText;
    public string badText;

    // Start is called before the first frame update
    void Update()
    {
        //Debug.Log(PlayerManager.Instance.optionOne + " " + PlayerManager.Instance.optionTwo + " " + PlayerManager.Instance.optionThree);
        if(character > 3 || character < 1){
            Debug.LogError("wrong character number input");
            return;
        }

        switch (character){
            case 1:
                ChangeUI(PlayerManager.Instance.optionOne);
                break;
            case 2:
                ChangeUI(PlayerManager.Instance.optionTwo);
                break;
            case 3:
                ChangeUI(PlayerManager.Instance.optionThree);
                break;      
            default:
                Debug.LogError("wrong character number input");  
                break;
        }
    }

    public void ChangeUI(int score){
        switch (score){
            case -1:
                reviewTextComponent.text = badText;
                icon.sprite = badIcon;
                stars.sprite = badStars;
                break;
            case 0:
                reviewTextComponent.text = neutralText;
                icon.sprite = neutralIcon;
                stars.sprite = neutralStars;
                break;
            case 1:
                reviewTextComponent.text = goodText;
                icon.sprite = goodIcon;
                stars.sprite = goodStars;
                break; 
            default:
                Debug.LogError("score is wrong value: " + score);  
                break;       
        }       
    }
}
