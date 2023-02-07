using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

	public GameObject selection;

	public bool walking;

    PlayerMovement playerMovement;

	IEnumerator interactRoutine;

	bool cursorChanged;

	Interactable interactable;

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
			Interactable newInteractable;
            hit.collider.TryGetComponent(out newInteractable);
            if(newInteractable != null)
			{
				if (interactable != null && interactable != newInteractable)
				{
					interactable.outline.enabled = false;
				}
				interactable = newInteractable;
				ChangeCursor();
				interactable.outline.enabled = true;
				UiManager.SetCursor(interactable.objectType);
				if (Input.GetButtonDown("Fire1"))
				{
					interactRoutine = Interact(interactable);
					StartCoroutine(interactRoutine);
					if (SoundManager.instance != null)
						SoundManager.PlaySound(SoundManager.instance.groundClick);
					
				}
			}

			else if (((1 << hit.collider.gameObject.layer) & playerMovement.groundLayer) != 0)
			{
				DisableInteraction(ObjectType.ground);
			}
			else
			{
				DisableInteraction(ObjectType.none);
			}

		}
		else
		{
			DisableInteraction(ObjectType.none);
		}

	}

	private void DisableInteraction(ObjectType objectType)
	{
		cursorChanged = false;
		UiManager.SetCursor(objectType);
		if (interactable != null)
		{
			interactable.outline.enabled = false;
			interactable = null;
		}
	}

	private void ChangeCursor()
	{
		if (!cursorChanged)
		{
			if (SoundManager.instance != null)
				SoundManager.PlaySound(SoundManager.instance.cursorChange);

			cursorChanged = true;
		}
	}

	

	IEnumerator Interact(Interactable interactable)
	{
		SetSelection(interactable.transform.position);
		walking = true;
		playerMovement.agent.SetDestination(interactable.transform.position);
		yield return new WaitForSeconds(0.1f);
		while (walking)
		{
			if (playerMovement.agent.remainingDistance > 2)
			{
				yield return null;
			}
			else
			{
				walking = false;
				playerMovement.agent.SetDestination(transform.position);
				selection.SetActive(false);
			}
		}

		interactable.Interact();

	}

	public void SetSelection(Vector3 position)
	{
		selection.transform.position = position + new Vector3(0,0.25f,0);
		selection.SetActive(true);
	}

	public void CancelInteraction()
	{
		if (interactRoutine != null)
			StopCoroutine(interactRoutine);
	}
}
