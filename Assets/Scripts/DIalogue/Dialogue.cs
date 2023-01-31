using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
	public string dialogueName;
	public string dialogueText;
	public string playerAnswer;
	public Sprite portrait;
	public bool isEnd;
	public Dialogue[] answers;

}
