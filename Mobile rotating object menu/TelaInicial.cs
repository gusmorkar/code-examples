/***********************************************************************
 * Código: TelaInicial.cs
 * Resumo: Controla o Menu Inicial
 * 
 * Autor: Gustavo Moreira Silva
 * 
 * Copyright Gaz Games
 ***********************************************************************/

using UnityEngine;
using System.Collections;

public class TelaInicial : MonoBehaviour
{	
	//Facilita o controleao chamar as cenas, chamando por indice(generico) ao inves de chamar pelo nome
	private int ultimaCenaCarregada;
	
	private RaycastHit hit;
	
	private void Start ()
	{
		//Retorna o index da propria cena
		this.ultimaCenaCarregada = Application.loadedLevel;
	}
	
	private void Update ()
	{
		#if UNITY_EDITOR
			//Se clicar, dispara um raycast
			if ( Input.GetMouseButtonUp ( 0 ) )
			{
				Ray rayMouse = Camera.main.ScreenPointToRay ( Input.mousePosition );
				Raycast( rayMouse );
			}
		#endif
		
		#if UNITY_ANDROID || UNITY_IPHONE
			//Se tocar, dispara um raycast
			if ( Input.touchCount > 0 && Input.GetTouch( 0 ).phase == TouchPhase.Began )
			{
				Ray rayTouch = Camera.main.ScreenPointToRay ( Input.GetTouch(0).position );
				Raycast( rayTouch );
			}
		#endif
	}
	
	//Funcao pra checar se raycast pegou em algo
	private void Raycast ( Ray ray )
	{
		if ( Physics.Raycast ( ray, out hit, 100 ) )
		{
			//Se raycast pegou no botao ajuda, vai pra cena de ajuda
			if ( hit.collider.gameObject.name == "BtnAjuda" )
				Application.LoadLevel ( this.ultimaCenaCarregada + 2 );
			//Se raycast pegou no botao iniciar, vai pra cena principal
			else if ( hit.collider.gameObject.name == "BtnInicia" )
				Application.LoadLevel ( this.ultimaCenaCarregada + 1 );
		}
	}
}
