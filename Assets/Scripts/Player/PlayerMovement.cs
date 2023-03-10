using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

	public LayerMask groundLayer;
    public NavMeshAgent agent;
	public AudioClip[] steps;

	Animator animator;
	PlayerInteraction playerInteraction;
	AudioSource audioSource;
	
    
    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		playerInteraction = GetComponent<PlayerInteraction>();
		audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		bool run = agent.velocity.magnitude > 0.1f;
		animator.SetBool("run", run);
		if (playerInteraction.selection != null)
		{
			if (agent.remainingDistance < 0.1f && playerInteraction.selection.activeInHierarchy && !playerInteraction.walking)
			{
				Debug.Log("N?o estou correndo e o bagulho t? desativado");
				playerInteraction.selection.SetActive(false);
			}
		}
		if (UiManager.instance.inDialogue)
		{
			return;
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
        {

			/*
			 * Essa linha de c?digo est? verificando se a camada do objeto colidido (hit.collider.gameObject.layer) 
			 * est? inclu?da na m?scara de camadas armazenada na vari?vel groundLayer.
			A express?o 1 << hit.collider.gameObject.layer est? usando o operador "bit shift left" (<<)
			para criar uma m?scara de camada com apenas o bit correspondente ? camada do objeto colidido. 
			Por exemplo, se a camada do objeto colidido for a terceira camada (?ndice 2), essa express?o ser? 
			equivalente a 100 em bin?rio (1 na terceira posi??o, 0 em todas as outras).
			A express?o groundLayer & (1 << hit.collider.gameObject.layer) est? usando o operador "bitwise AND" (&) 
			para comparar cada bit dessa m?scara com o bit correspondente na m?scara armazenada em groundLayer. 
			Se qualquer bit for igual a 1 em ambas as m?scaras, o resultado ser? 1, caso contr?rio ser? 0.
			Por fim, a express?o != 0 verifica se o resultado da express?o anterior ? diferente de zero, 
			o que significa que a camada do objeto colidido est? inclu?da na m?scara armazenada em groundLayer.
			Ent?o, se voc? tem uma LayerMask chamada groundLayer e deseja verificar se essa LayerMask cont?m a 
			camada do objeto que colidiu com o ray, voc? pode usar essa express?o.
			 * */
			if (((1 << hit.collider.gameObject.layer) & groundLayer) != 0)
			{
				

				if (Input.GetButtonDown("Fire1"))
				{
					if (SoundManager.instance != null)
						SoundManager.PlaySound(SoundManager.instance.groundClick);

					playerInteraction.SetSelection(hit.point);
					agent.SetDestination(hit.point);
					UiManager.DisableInteraction();
					playerInteraction.CancelInteraction();
				}
					

			}
			

		}
		

		
        
	}

	public void Step()
	{
		audioSource.PlayOneShot(steps[Random.Range(0, steps.Length)]);
	}
}
