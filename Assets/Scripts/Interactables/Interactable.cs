using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public ObjectType objectType;

	public bool isInteracting;
	public Item conditionalItem;

	public abstract void Interact();
}
