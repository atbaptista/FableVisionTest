using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // pause and unpause on enter and exit so the dialogue wont skip forward when clicking buttons
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayerManager.Instance.Pause();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerManager.Instance.UnPause();
    }
}
