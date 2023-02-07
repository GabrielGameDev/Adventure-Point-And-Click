using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public static SoundManager instance;

	public AudioClip itemCollect;
	public AudioClip cursorChange;
	public AudioClip mouseClick;
	public AudioClip mouseOver;
	public AudioClip groundClick;
	public AudioClip introDialogue, finishDialogue;
	
	AudioSource audioSource;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			audioSource = GetComponent<AudioSource>();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public static void PlaySound(AudioClip audioClip)
	{
		if (instance == null)
			return;

		instance.audioSource.PlayOneShot(audioClip);
	}
}
