using UnityEngine;
using System.Collections;
/*******************************************************************************************
controla o cenario no endless runner
*******************************************************************************************/
public class ControleRunner : MonoBehaviour {

	public GameObject[] obstaculos = new GameObject[3];

	public int quantObstaculo;

	public float intervalo;

	public bool inicia = false;

	private int i = 0;

	public GameObject barco;

	public GameObject goControle;
	private GameControl controleGeral;
	
	// Use this for initialization
	void Start ()
	{
		this.goControle = GameObject.FindGameObjectWithTag ("GameControl");
		this.controleGeral = goControle.GetComponent<GameControl>() as GameControl;
	}
	
	// Update is called once per frame
	void Update () {

		if (this.inicia)
		{
			InvokeRepeating( "Instancia", 0.1f, this.intervalo);
			this.inicia = false;
		}
	
	}

	void Instancia ()
	{
		if (this.i < this.quantObstaculo)
			Instantiate (this.obstaculos [Random.Range (0, 2)], this.transform.position, Quaternion.identity);
		else
		{
			this.controleGeral.estadoAtual++;
			Destroy(this.barco);
			CancelInvoke();
			Destroy(this.gameObject);
		}
		this.i++;
	}

	public void Comeca()
	{
		this.inicia = true;
		this.barco.SetActive (true);
	}
}
