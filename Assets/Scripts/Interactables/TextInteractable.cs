using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteractable : Interactable
{
	public string text;
	public string conditionalText;
	public AudioClip audioClip;

	public override void Interact()
	{
		if (isInteracting)
			return;
		isInteracting = true;
		UiManager.SetText(this);

	}
}
