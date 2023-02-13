using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteraction : Interactable
{

	public string sceneName;
	public string conditionalText;

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
				UiManager.SetInfoText(conditionalText);
			}
			return;
		}
		SceneManager.LoadScene(sceneName);
	}

	
}
