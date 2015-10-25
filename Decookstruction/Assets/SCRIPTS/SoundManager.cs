﻿using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
	public AudioSource musicMenu;                 //Drag a reference to the audio source which will play the music.
	public AudioSource musicGame;
	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
	
	
	void Awake ()
	{
		//Check if there is already an instance of SoundManager
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this)
			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
			Destroy (gameObject);
		
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}
	
	
	//Used to play single sound clips.
	public void PlaySingle(AudioClip clip)
	{
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSource.clip = clip;
		
		//Play the clip.
		efxSource.Play ();
	}

	public void PlaySingleDelay(AudioClip clip, float delay )
	{
		efxSource.clip = clip;
		efxSource.PlayDelayed(delay);
	}

	public void PlayMusicMenu()
	{
		musicMenu.Play ();
	}

	public void StopMusicMenu()
	{
		musicMenu.Stop ();
	}

	public void PlayMusicGame()
	{
		musicGame.PlayDelayed(3F);
	}
	
	public void StopMusicGame()
	{
		musicGame.Stop ();
	}
}
