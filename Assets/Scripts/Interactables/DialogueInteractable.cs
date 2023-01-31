using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
	public Dialogue dialogue;

	public override void Interact()
	{
		UiManager.SetDialogue(dialogue);
	}
}
