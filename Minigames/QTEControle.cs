using UnityEngine;
using System.Collections;
/*******************************************************************************************
controla colisao do quick time event
*******************************************************************************************/
public class QTEControle : MonoBehaviour {

	public GameObject[] seqTeclas = new GameObject[10];

	private int combo = 0;

	public bool inicia = false;

	private float intervalo;

	public GameObject goControle;
	private GameControl controleGeral;

	public GameObject barra;

	void Start ()
	{
		this.goControle = GameObject.FindGameObjectWithTag ("GameControl");
		this.controleGeral = goControle.GetComponent<GameControl>() as GameControl;

		this.intervalo = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (this.inicia)
		{
			InvokeRepeating( "Instancia", 0.1f, this.intervalo);
			this.inicia = false;
		}

		if ( this.combo >= 20) {
			this.controleGeral.estadoAtual++;
			Destroy (this.barra);
			Destroy (this);
		}
	}

	public void Sucess()
	{
		this.combo++;
		if (this.combo > 8)
		{
			this.intervalo = 0.7f;
		}
	}

	public void Fail()
	{
		this.combo = 0;
		this.intervalo = 1;
	}

	void Instancia ()
	{
		if ( this.combo < 20 )
			Instantiate (this.seqTeclas [Random.Range (0, 9)], this.transform.position, Quaternion.identity);
		else
		{
			CancelInvoke();
		}
	}

	public void Comeca()
	{
		this.inicia = true;
		this.barra.SetActive (true);
	}

	void OnGUI()
	{
		if ( this.controleGeral.estadoAtual == GameState.JOGO_1 )
			GUI.Box ( new Rect ( Screen.width/2 - 40, Screen.height/2+100, 80, 20), "COMBO:"+this.combo.ToString());
	}
}
