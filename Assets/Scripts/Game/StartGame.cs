using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public AudioClip menuSong;
    public Slider musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(menuSong);
        SoundManager.Instance.SetMusicVolume(musicVolume.value);

    }
}
