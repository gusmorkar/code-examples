using UnityEngine;
using System.Collections;
/*******************************************************************************************
controla estado do jogo
*******************************************************************************************/
public enum GameState
{
	INICIO,
	JOGO_1,
	TRANSICAO_1,
	JOGO_2,
	TRANSICAO_2,
	JOGO_3,
	FIM
};

public class GameControl : MonoBehaviour
{
	public GameState estadoAtual;
	public GUISkin guiCustomizada;
	private Rect caixaDialogo;

	private bool instrucoes = false;

	public GameObject goControle1;
	private QTEControle jogo1;

	public GameObject goControle2;
	private ControleJogo3 jogo2;

	public GameObject goControle3;
	private ControleRunner jogo3;

	void Start ()
	{
		this.goControle1 = GameObject.FindGameObjectWithTag ("qtecontrole");
		this.jogo1 = goControle1.GetComponent<QTEControle>() as QTEControle;

		this.goControle2 = GameObject.FindGameObjectWithTag ("controlesocial");
		this.jogo2 = goControle2.GetComponent<ControleJogo3>() as ControleJogo3;

		this.goControle3 = GameObject.FindGameObjectWithTag ("runnercontrole");
		this.jogo3 = goControle3.GetComponent<ControleRunner>() as ControleRunner;

		this.estadoAtual = GameState.INICIO;
		this.caixaDialogo = new Rect ( Screen.width/2 - 300, Screen.height/2 - 200, 600, 400 );
	}

	void Update ()
	{
		switch (this.estadoAtual)
		{
			case GameState.INICIO:
				if ( Input.GetKeyUp(KeyCode.Space) )
				{
					this.estadoAtual ++;
					this.instrucoes = true;
				}
			break;
			case GameState.JOGO_1:
				Jogo_1();
			break;
			case GameState.TRANSICAO_1:
				if ( Input.GetKeyUp(KeyCode.Space) )
				{
					this.estadoAtual ++;
					this.instrucoes = true;
				}
			break;
			case GameState.JOGO_2:
				Jogo_2();
			break;
			case GameState.TRANSICAO_2:
				if ( Input.GetKeyUp(KeyCode.Space) )
				{
					this.estadoAtual ++;
					this.instrucoes = true;
				}
			break;
			case GameState.JOGO_3:
				Jogo_3();
			break;
			case GameState.FIM:
			break;
		}
	}

	//-----------------------------------------------------------
	//controle jogo 1
	void Jogo_1 ()
	{
		if (Input.GetKeyUp (KeyCode.Space))
		{
			this.instrucoes = false;
			this.jogo1.Comeca();
		}
	}

	//-----------------------------------------------------------
	//controle jogo 1
	void Jogo_2 ()
	{
		if (Input.GetKeyUp (KeyCode.Space))
		{
			this.instrucoes = false;
			this.jogo2.Comeca();
		}
	}

	//-----------------------------------------------------------
	//controle jogo 1
	void Jogo_3 ()
	{
		if (Input.GetKeyUp (KeyCode.Space))
		{
			this.instrucoes = false;
			this.jogo3.Comeca();
		}
	}


	//-----------------------------------------------------------
	void OnGUI ()
	{
		GUI.skin = this.guiCustomizada;

		if (this.estadoAtual == GameState.INICIO)
		{
			GUI.Box (this.caixaDialogo, "");
			GUI.Label (this.caixaDialogo, "bla bla bla bla bla Pressione Espaço para continuar");
		}
		if (this.estadoAtual == GameState.JOGO_1 && this.instrucoes)
		{
			GUI.Box (this.caixaDialogo, "");
			GUI.Label (this.caixaDialogo, "Faça um combo de 20 teclas para avançar a proxima fase");
		}
		if (this.estadoAtual == GameState.TRANSICAO_1)
		{
			GUI.Box (this.caixaDialogo, "");
			GUI.Label (this.caixaDialogo, "bla bla bla bla bla Pressione Espaço para continuar");
		}
		if (this.estadoAtual == GameState.JOGO_2 && this.instrucoes)
		{
			GUI.Box (this.caixaDialogo, "");
			GUI.Label (this.caixaDialogo, "Construa cidades e plantacoes para conseguir 20 de alimento");
		}
		if (this.estadoAtual == GameState.TRANSICAO_2)
		{
			GUI.Box (this.caixaDialogo, "");
			GUI.Label (this.caixaDialogo, "bla bla bla bla bla bla");
		}
		if (this.estadoAtual == GameState.JOGO_3 && this.instrucoes)
		{
			GUI.Box (this.caixaDialogo, "");
			GUI.Label (this.caixaDialogo, "Desvie de 5 ondas de obstaculos para chegar ao seu objetivo");
		}
		if (this.estadoAtual == GameState.INICIO)
		{
			GUI.Box (this.caixaDialogo, "");
			GUI.Label (this.caixaDialogo, "bla bla bla bla bla FIM");
		}
	}
}
