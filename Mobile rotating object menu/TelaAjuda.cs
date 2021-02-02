/***********************************************************************
 * Código: TelaAjuda.cs
 * Resumo: Controla a tela de Ajuda
 * 
 * Autor: Gustavo Moreira Silva
 * 
 * Copyright Gaz Games
 ***********************************************************************/

using UnityEngine;
using System.Collections;

public class TelaAjuda : MonoBehaviour
{
	//Facilita o controleao chamar as cenas, chamando por indice(generico) ao inves de chamar pelo nome
	private int ultimaCenaCarregada;
	
	//Tela atual de ajuda
	private int slideAtual;
	
	//Total de telas de ajuda
	public int totalSlide;
	
	//Vetor que armazena todas as telas de ajuda
	private GameObject[] slides;
	
	void Start ()
	{
		//Inicializa o vetor
		slides = new GameObject[totalSlide];
		
		//Retorna o index da propria cena
		this.ultimaCenaCarregada = Application.loadedLevel;
		
		//Inicializa a tela atual de ajuda
		this.slideAtual = 0;
		
		//Busca e armazena todas as telas de ajuda
		for ( int i = 1; i <= totalSlide; i++ )
			this.slides[i-1] = GameObject.Find ( "Slide" + i );
	}
	
	void Update ()
	{
		
		#if UNITY_EDITOR
			//Se clicou, troca os slides
			if ( Input.GetMouseButtonUp ( 0 ) )
				TrocaSlide();
		#endif
		
		#if UNITY_ANDROID || UNITY_IPHONE
			//Se tocou, troca os slides
			if ( Input.touchCount > 0 && Input.GetTouch( 0 ).phase == TouchPhase.Began )
				TrocaSlide();
		#endif
	}
	
	private void TrocaSlide()
	{
		//Proximo slide
		slideAtual++;
		
		//Se chegou ao fim, volta para o Menu Inicial
		if ( this.slideAtual >= this.totalSlide )
			Application.LoadLevel ( this.ultimaCenaCarregada - 2 );
		//Senao, troca de slide
		else
			Destroy ( this.slides[this.slideAtual-1] );
	}
}
