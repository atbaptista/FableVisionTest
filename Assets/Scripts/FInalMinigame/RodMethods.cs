using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodMethods : MonoBehaviour
{
    public PlayerInput playerInput;

    public AudioClip ropeStretch;

    public void Cast(){
        playerInput.CastLine();
    }

    public void PullBackEmpty(){
        playerInput.PullBackEmpty();
    }

    public void PullBackFish(){
        playerInput.PullBackFish();
        SoundManager.Instance.PlayUI(ropeStretch);
    }
}
