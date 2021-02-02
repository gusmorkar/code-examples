/***********************************************************************
 * Código: TelaEspera.cs
 * Resumo: Controla a tela de Espera
 * 
 * Autor: Gustavo Moreira Silva
 * 
 * Copyright Gaz Games
 ***********************************************************************/

using UnityEngine;
using System.Collections;

public class TelaEspera : MonoBehaviour
{
	//Facilita o controleao chamar as cenas, chamando por indice(generico) ao inves de chamar pelo nome
	private int ultimaCenaCarregada;
	
	void Start ()
	{	
		//Retorna o index da propria cena
		this.ultimaCenaCarregada = Application.loadedLevel;
		
		Application.LoadLevel ( this.ultimaCenaCarregada + 2 );
	}
}
