using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteractable : Interactable
{
	public string text;

	public override void Interact()
	{
		Debug.Log(text);
	}
}
