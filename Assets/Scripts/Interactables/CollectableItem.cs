using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : Interactable
{
	public override void Interact()
	{
		//Inventory.instance.Add(this);
		Destroy(gameObject);
	}
	
}
