using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextInteractable : Interactable
{
	public string text;
	public string conditionalText;
	public AudioClip audioClip;
	public bool useItem;
	public Item newItem;
	public UnityEvent onUseItem;

	public override void Interact()
	{
		if (isInteracting)
			return;
		isInteracting = true;
		UiManager.SetText(this);

	}
}
