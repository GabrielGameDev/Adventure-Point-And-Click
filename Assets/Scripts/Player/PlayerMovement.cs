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
			 * Essa linha de c�digo est� verificando se a camada do objeto colidido (hit.collider.gameObject.layer) 
			 * est� inclu�da na m�scara de camadas armazenada na vari�vel groundLayer.
			A express�o 1 << hit.collider.gameObject.layer est� usando o operador "bit shift left" (<<)
			para criar uma m�scara de camada com apenas o bit correspondente � camada do objeto colidido. 
			Por exemplo, se a camada do objeto colidido for a terceira camada (�ndice 2), essa express�o ser� 
			equivalente a 100 em bin�rio (1 na terceira posi��o, 0 em todas as outras).
			A express�o groundLayer & (1 << hit.collider.gameObject.layer) est� usando o operador "bitwise AND" (&) 
			para comparar cada bit dessa m�scara com o bit correspondente na m�scara armazenada em groundLayer. 
			Se qualquer bit for igual a 1 em ambas as m�scaras, o resultado ser� 1, caso contr�rio ser� 0.
			Por fim, a express�o != 0 verifica se o resultado da express�o anterior � diferente de zero, 
			o que significa que a camada do objeto colidido est� inclu�da na m�scara armazenada em groundLayer.
			Ent�o, se voc� tem uma LayerMask chamada groundLayer e deseja verificar se essa LayerMask cont�m a 
			camada do objeto que colidiu com o ray, voc� pode usar essa express�o.
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
