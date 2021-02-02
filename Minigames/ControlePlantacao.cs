using UnityEngine;
using System.Collections;
/*******************************************************************************************
controla plantacao no minigame da cidade
*******************************************************************************************/
public class ControlePlantacao : MonoBehaviour {

	private bool livre = true;

	public Material plant_1;
	public Material plant_2;
	public Material plant_3;
	
	public GameObject goControle;
	private ControleRecursos controle;

	private int i = 0;
	// Use this for initialization
	void Start ()
	{
		this.goControle = GameObject.FindGameObjectWithTag ("controlesocial");
		this.controle = goControle.GetComponent<ControleRecursos>() as ControleRecursos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Plantar()
	{
		if (livre && this.controle.RetornaTrabLivre() >=1 ) {
			this.gameObject.GetComponent<Renderer>().material = this.plant_2;
			this.controle.AtualizaTrabalhador( -1);
			InvokeRepeating ("Desenvolve", 3, 3 );
			this.livre = false;
		}
	}

	void Desenvolve ()
	{
		this.i++;
		if (i % 2 == 0) {
			this.controle.AtualizaAlimento ();
			this.gameObject.GetComponent<Renderer> ().material = this.plant_2;
		}
		else
			this.gameObject.GetComponent<Renderer> ().material = this.plant_3;
	}

}
