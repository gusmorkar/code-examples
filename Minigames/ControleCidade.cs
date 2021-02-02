using UnityEngine;
using System.Collections;
/*******************************************************************************************
controla recursos no minigame da cidade
*******************************************************************************************/
public class ControleCidade : MonoBehaviour {

	private bool construida = false;

	public Material cidade;

	public GameObject goControle;
	private ControleRecursos controle;

	// Use this for initialization
	void Start ()
	{
		this.goControle = GameObject.FindGameObjectWithTag ("controlesocial");
		this.controle = goControle.GetComponent<ControleRecursos>() as ControleRecursos;
	}

	public void Constroi()
	{
		if (!construida && this.controle.RetornaRecurso() >=5 ) {
			this.gameObject.GetComponent<Renderer>().material = cidade;
			this.controle.AtualizaRecurso(-5);
			this.controle.AtualizaTrabalhador(2);
			this.construida = true;
			this.Destroy(this);
		}
	}
}
