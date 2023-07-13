using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	public AudioSource UISource;
	public AudioClip nextUI;

	// Random pitch adjustment range.
	// public float LowPitchRange = .95f;
	// public float HighPitchRange = 1.05f;

	// Singleton instance.
	public static SoundManager Instance = null;
	
	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);

		EffectsSource.volume = 0.8f;
		UISource.volume = 0.8f;
	}

	// Play a single clip through the sound effects source.
	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

	public void PlayUI(AudioClip clip)
	{
		UISource.clip = clip;
		UISource.Play();
	}

	public void PlayNextUI(){
		UISource.clip = nextUI;
		UISource.Play();
	}

	public void SetMusicVolume(float vol){
		MusicSource.volume = vol;

	}

	public void SetSFXVolume(float vol){
		UISource.volume = vol;
        EffectsSource.volume = vol;
	}

	public AudioSource GetMusicSource(){
		return MusicSource;
	}

	// // Play a random clip from an array, and randomize the pitch slightly.
	// public void RandomSoundEffect(params AudioClip[] clips)
	// {
	// 	int randomIndex = Random.Range(0, clips.Length);
	// 	float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

	// 	EffectsSource.pitch = randomPitch;
	// 	EffectsSource.clip = clips[randomIndex];
	// 	EffectsSource.Play();
	// }
	
}