using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
	ground, door, text, dialogue, collectable, none
}

public class UiManager : MonoBehaviour
{
    

    public Texture2D[] cursors;

    public static UiManager instance;

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

	
	public void SetCursor(ObjectType objectType)
    {
		if (instance == null)
			return;
		
		Cursor.SetCursor(cursors[(int)objectType], Vector2.zero, CursorMode.Auto);
		
	}

}
