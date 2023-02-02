using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
	public string dialogueName;
	public string playerAnswer;
	public string dialogueText;	
	public Sprite portrait;
	public bool isEnd;
	public Item conditionalItem;
	public Dialogue[] answers;

}
