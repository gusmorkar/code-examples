using UnityEngine;
using System.Collections;
/*******************************************************************************************
controla recursos no minigame da cidade
*******************************************************************************************/
public class ControleRecursos : MonoBehaviour {

	private int recurso = 5;
	
	private int trabLivre = 0;

	private int alimento;

	public bool inicia = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.inicia) {
			this.recurso = 5;
			InvokeRepeating ("GanhaRecurso", 0.5f, 4);
			this.inicia = false;
		}
	}

	void GanhaRecurso ()
	{
		this.recurso++;
	}

	public void AtualizaRecurso ( int r )
	{
		this.recurso += r;
	}

	public int RetornaRecurso ()
	{
		return this.recurso;
	}

	public void AtualizaTrabalhador ( int t)
	{
		this.trabLivre += t;
	}

	public int RetornaTrabLivre ()
	{
		return trabLivre;
	}

	public void AtualizaAlimento ()
	{
		this.alimento ++;
	}

	public int RetornaAlimento()
	{
		return this.alimento;
	}
}
