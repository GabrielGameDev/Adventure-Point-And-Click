using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerMovement playerMovement;

	IEnumerator interactRoutine;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
		
    }

    // Update is called once per frame
    void Update()
    {

		if (UiManager.instance.inDialogue)
		{
			return;
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
        {
            Interactable interactable;
            hit.collider.TryGetComponent(out interactable);
            if(interactable != null)
			{
				UiManager.SetCursor(interactable.objectType);
				if (Input.GetButtonDown("Fire1"))
				{
					interactRoutine = Interact(interactable);
					StartCoroutine(interactRoutine);
				}
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

	IEnumerator Interact(Interactable interactable)
	{
		bool walking = true;
		playerMovement.agent.SetDestination(interactable.transform.position);
		yield return new WaitForSeconds(0.1f);
		while (walking)
		{
			if(playerMovement.agent.remainingDistance > 2)
			{
				yield return null;
			}
			else
			{
				walking = false;
				playerMovement.agent.SetDestination(transform.position);
			}
		}

		interactable.Interact();
		
	}

	public void CancelInteraction()
	{
		if (interactRoutine != null)
			StopCoroutine(interactRoutine);
	}
}
