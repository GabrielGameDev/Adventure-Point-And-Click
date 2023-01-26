using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
        {
            Interactable interactable;
            hit.collider.TryGetComponent<Interactable>(out interactable);
            if(interactable != null)
            {
                UiManager.SetCursor(interactable.objectType);
            }
			else if (((1 << hit.collider.gameObject.layer) & playerMovement.groundLayer) != 0)
			{
				UiManager.SetCursor(ObjectType.ground);
			}
			else
			{
				UiManager.SetCursor(ObjectType.none);
			}

		}
		else
		{
			UiManager.SetCursor(ObjectType.none);
		}

	}
}