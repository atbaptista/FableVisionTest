using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public AudioClip mouseEnter;
    public AudioClip mouseClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundManager.Instance.Play(mouseClick);
    }

    // pause and unpause on enter and exit so the dialogue wont skip forward when clicking buttons
    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.Instance.Play(mouseEnter);
    }
}
