using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

	public LayerMask groundLayer;
    NavMeshAgent agent;
	Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
        {

			/*
			 * Essa linha de código está verificando se a camada do objeto colidido (hit.collider.gameObject.layer) 
			 * está incluída na máscara de camadas armazenada na variável groundLayer.
			A expressão 1 << hit.collider.gameObject.layer está usando o operador "bit shift left" (<<)
			para criar uma máscara de camada com apenas o bit correspondente à camada do objeto colidido. 
			Por exemplo, se a camada do objeto colidido for a terceira camada (índice 2), essa expressão será 
			equivalente a 100 em binário (1 na terceira posição, 0 em todas as outras).
			A expressão groundLayer & (1 << hit.collider.gameObject.layer) está usando o operador "bitwise AND" (&) 
			para comparar cada bit dessa máscara com o bit correspondente na máscara armazenada em groundLayer. 
			Se qualquer bit for igual a 1 em ambas as máscaras, o resultado será 1, caso contrário será 0.
			Por fim, a expressão != 0 verifica se o resultado da expressão anterior é diferente de zero, 
			o que significa que a camada do objeto colidido está incluída na máscara armazenada em groundLayer.
			Então, se você tem uma LayerMask chamada groundLayer e deseja verificar se essa LayerMask contém a 
			camada do objeto que colidiu com o ray, você pode usar essa expressão.
			 * */
			if (((1 << hit.collider.gameObject.layer) & groundLayer) != 0)
			{
				

				if (Input.GetButtonDown("Fire1"))
				{
					agent.SetDestination(hit.point);
					UiManager.DisableInteraction();
				}
					

			}
			

		}
		

		animator.SetBool("run", agent.velocity.magnitude > 0.1f);
        
	}
}
