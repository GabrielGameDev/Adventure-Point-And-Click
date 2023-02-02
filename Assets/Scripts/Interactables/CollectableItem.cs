using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : Interactable
{
	public Item item;
	public override void Interact()
	{
		if (conditionalItem)
		{
			if (Inventory.HasItem(conditionalItem))
			{
				Collect();
			}
			else
			{
				Debug.Log("Precisa de outro item pra pegar esse");
			}
			return;
		}
		Collect();
	}

	void Collect()
	{
		Inventory.SetItem(item);
		Destroy(gameObject);
	}
	
}
