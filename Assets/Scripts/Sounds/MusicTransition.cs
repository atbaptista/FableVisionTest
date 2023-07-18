using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    public AudioClip nextSong;
    public float fadeDuration = 1.35f;
    public bool isPlayedOnStart = false;
    [HideInInspector] public AudioSource musicSource;


    void Start() {
        musicSource = SoundManager.Instance.GetMusicSource();
        if(isPlayedOnStart){
            StartMusicTransition();
        }
    }

    public void StartMusicTransition()
    {
        StartCoroutine(SongTransition());
    }

    private System.Collections.IEnumerator SongTransition()
    {
        float originalVolume = musicSource.volume;
        float startVolume = musicSource.volume;
        float targetVolume = 0;
        float elapsedTime = 0f;

        //fade song out
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
            musicSource.volume = Mathf.Lerp(startVolume, targetVolume, normalizedTime);
            yield return null;
        }

        //swap songs
        musicSource.clip = nextSong;
        musicSource.Play();

        musicSource.volume = 0f;
        elapsedTime = 0f;
        startVolume = 0f;
        targetVolume = originalVolume;

        //fade in new song
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / fadeDuration);
            musicSource.volume = Mathf.Lerp(startVolume, targetVolume, normalizedTime);
            yield return null;
        }

        musicSource.volume = originalVolume;
    }
}
