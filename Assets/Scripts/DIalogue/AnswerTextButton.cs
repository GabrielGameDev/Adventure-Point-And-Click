using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerTextButton : MonoBehaviour
{
	public Dialogue dialogue;
	bool canSelect;

	public void SetDialogue()
	{
		UiManager.SetDialogue(dialogue);
		EventSystem.current.SetSelectedGameObject(null);
		if (SoundManager.instance != null)
			SoundManager.PlaySound(SoundManager.instance.mouseClick);
	}

	public void OnHover()
	{
		if (!canSelect)
			return;
		
		if (SoundManager.instance != null)
			SoundManager.PlaySound(SoundManager.instance.mouseOver);
	}

	public void SetButton(Dialogue newDialogue)
	{
		dialogue = newDialogue;
		Invoke("EnableSelection", 1f);
	}

	void EnableSelection()
	{
		canSelect = true;
	}

	
}
