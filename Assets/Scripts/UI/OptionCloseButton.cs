using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionCloseButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Invoke("UnPause", 0.3f);
    }

    private void UnPause()
    {
        PlayerManager.Instance.UnPause();
    }
}
