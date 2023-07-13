using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOptions : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;

    // public AudioClip musicTest;
    // public AudioClip SFXTest;

    // Update is called once per frame
    void Start(){
        musicSlider.value = SoundManager.Instance.MusicSource.volume;
        SFXSlider.value = SoundManager.Instance.EffectsSource.volume;
    }

    void Update()
    {
        SoundManager.Instance.SetMusicVolume(musicSlider.value);
        SoundManager.Instance.SetSFXVolume(SFXSlider.value);
    }
}
