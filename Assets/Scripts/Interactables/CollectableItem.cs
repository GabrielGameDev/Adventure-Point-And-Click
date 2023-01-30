using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : Interactable
{
	public Item item;
	public override void Interact()
	{
		Inventory.SetItem(item);
		Destroy(gameObject);
	}
	
}
