using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteraction : Interactable
{

	public string sceneName;

	public override void Interact()
	{
		if (conditionalItem)
		{
			if (Inventory.HasItem(conditionalItem))
			{
				SceneManager.LoadScene(sceneName);
			}
			else
			{
				Debug.Log("Precisa do item " + conditionalItem.itemName);
			}
			return;
		}
		SceneManager.LoadScene(sceneName);
	}

	
}
