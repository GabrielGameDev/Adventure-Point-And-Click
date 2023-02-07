using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
	public ObjectType objectType;

	public bool isInteracting;
	public Item conditionalItem;

	public Outline outline;

	private void Awake()
	{
		try
		{
			outline = GetComponent<Outline>();
			outline.enabled = false;
		}
		catch
		{
			Debug.LogError("Objeto " + gameObject.name + " precisa de um Outline");
		}
		
	}

	public abstract void Interact();
}
