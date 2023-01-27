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
    

    public Texture2D[] cursors;
	public GameObject interactionPanel;
	public TMP_Text interactionText;
	public Image portrait;
	public TMP_Text[] answersTexts;

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

		instance.interactionText.text = interactable.text;
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

}
