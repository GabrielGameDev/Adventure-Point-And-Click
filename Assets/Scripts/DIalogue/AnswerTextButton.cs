using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTextButton : MonoBehaviour
{
	public Dialogue dialogue;

	public void SetDialogue()
	{
		UiManager.SetDialogue(dialogue);
	}
}
