using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ObjectType
{
	ground, door, text, dialogue, collectable, none
}

public class UiManager : MonoBehaviour
{

	[Tooltip("The order of the cursors must be the same as the ObjectType enum\n" +
		"0. ground\n" +
		"1. door\n" +
		"2. text\n" +
		"3. dialogue\n" +
		"4. collectable\n" +
		"5. none\n")]

	public Texture2D[] cursors;

	[Tooltip("Interactions")]
	public GameObject interactionPanel;
	public TMP_Text interactionText;
	public Image portrait;
	public TMP_Text[] answersTexts;

	[Tooltip("Inventory")]
	public Image[] inventoryImages;

    public static UiManager instance;

	TextInteractable textInteractable;

	private void Awake()
	{
		if(instance == null)
        {
            instance = this;
        }
		else
		{
			Destroy(gameObject);
		}
	}

	
	public static void SetCursor(ObjectType objectType)
    {
		if (instance == null)
			return;

		Cursor.SetCursor(instance.cursors[(int)objectType], Vector2.zero, CursorMode.Auto);

	}

	public static void SetText(TextInteractable interactable)
	{
		if (instance == null)
			return;

		if (interactable.conditionalItem != null)
		{
			Debug.Log("Tem conditional item");
			if (Inventory.HasItem(interactable.conditionalItem))
			{
				Debug.Log("Tem item");
				instance.interactionText.text = interactable.conditionalText;
			}
			else
			{
				Debug.Log("Não tem item");
				instance.interactionText.text = interactable.text;
			}
		}
		else
		{
			Debug.Log("Não tem conditional item");
			instance.interactionText.text = interactable.text;
		}
		
		instance.interactionPanel.SetActive(true);
		instance.textInteractable = interactable;
	}

	public static void DisableInteraction()
	{
		if (instance == null)
			return;

		instance.interactionPanel.SetActive(false);
		if (instance.textInteractable != null)
			instance.textInteractable.isInteracting = false;
	}

	public static void SetInventoryImage(Item item)
	{
		if (instance == null)
			return;

		DisableInteraction();
		for (int i = 0; i < instance.inventoryImages.Length; i++)
		{
			if (!instance.inventoryImages[i].gameObject.activeInHierarchy)
			{
				instance.inventoryImages[i].sprite = item.itemImage;
				instance.inventoryImages[i].gameObject.SetActive(true);
				break;
			}
		}
	}

}
