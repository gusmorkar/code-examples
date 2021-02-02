/***********************************************************************
 * Código: Rotaciona.cs
 * Resumo: Controla a rotacao do objeto, baseado no input do usuario
 * 
 * Autor: Gustavo Moreira Silva
 * 
 * Histórico de autalizacoes:
 * Controle de rotacao modificado
 * Controle de touch finalizado
 * 
 * Copyright Gaz Games
 ***********************************************************************/

using UnityEngine;
using System.Collections;

public class Rotaciona : MonoBehaviour
{
	//Posicao do mouse no click e no deslocamento
	private float posicaoInicial, posicao;
	
	//Item atual sendo visualizado no polígono
	private int itemAtual;
	
	//Velocidade de rotacao - public apenas para facilitar no editor
	public float velocidade;
	
	//Eixo de rotacao - public apenas para facilitar no editor
	public Vector3 eixo;
	
	//Quantidade de lados do polígono base - public apenas para facilitar no editor
	public int nLados;
	
	//Angulo a ser rotacionado - varia conforme o numero de lados
	private float angulo;
	
	//Controle de entrada do usuário - trava até completar a acao
	private bool input;
	
	//Armazena o angulo final a ser rotacionado
	private Quaternion rotFinal;
	
	void Start ()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep; 
		//Eixo, nLados e velocidade sao alterados no editor
		
		//Inicializando as variáveis
		this.itemAtual = 0;
		this.input = true;
		
		//Calcula o angulo
		this.angulo = 360.0f / nLados;
		
		//Inicializa a posicao inicial para controle
		this.posicaoInicial = 0;
	}

	void Update ()
	{
		#if UNITY_EDITOR
			//Se usuário clicou
			if ( Input.GetMouseButton ( 0 ) && this.input )
				this.PrimeiroToque ( Input.mousePosition.x );
			
			//Quando o usuário deixar de clicar calcula o deslocamento
			if ( Input.GetMouseButtonUp ( 0 ) )
				this.CalculaDeslocamento ( Input.mousePosition.x );
		#endif
	
		#if UNITY_ANDROID
			//Quando usuario tocar na tela
			if ( Input.touchCount > 0 && Input.GetTouch( 0 ).phase == TouchPhase.Began )
				this.PrimeiroToque ( Input.GetTouch ( 0 ).position.x );
		
			//Quando mover
			if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended )
				this.CalculaDeslocamento ( Input.GetTouch ( 0 ).position.x );
		#endif
		
		this.Rotacionando ();
	}
	
	//Funcao armazena a posicao X do primeiro toque/click
	private void PrimeiroToque ( float posX )
	{	
		if ( this.posicaoInicial == 0 )
			this.posicaoInicial = posX;
	}
	
	//Funcao calcula se houve algum deslocamento do toque/mouse
	private void CalculaDeslocamento ( float pX )
	{	
		//Armazena a ultima posicao X no momento final do toque/click
		this.posicao = pX;
	
		/* Debug --------
		Debug.Log ( "Posicao inicial: " + posicaoInicial );
		Debug.Log ( "Posicao: " + posicao );*/
		
		//Compara as posicoes e checa se houve algum deslocamento
		if ( this.posicaoInicial - this.posicao > 0 )
			this.itemAtual += 1;
		else if ( this.posicaoInicial - this.posicao < 0 )
			this.itemAtual -= 1;
		
		//Trava o input até chegar na posicao final
		this.input = false;
	
		//Calculando o angulo a ser deslocado
		this.rotFinal = Quaternion.Euler ( 0, this.angulo * this.itemAtual, 0 );
		
		this.posicaoInicial = 0;
	}
	
	//Funcao que rotaciona o objeto em questao
	private void Rotacionando ()
	{
		//Rotaciona
		if ( this.transform.rotation != this.rotFinal )
			this.transform.rotation = Quaternion.Lerp ( this.transform.rotation, this.rotFinal, Time.deltaTime * this.velocidade );
		//Libera próxima rotacao
		else
			this.input = true;
	}
}
