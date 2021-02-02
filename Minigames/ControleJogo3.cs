using UnityEngine;
using System.Collections;
/*******************************************************************************************
controle geral do minigame da cidade
*******************************************************************************************/
public class ControleJogo3 : MonoBehaviour {

	public bool inicia = false;

	public GameObject goControle;
	private ControleRecursos controle;

	public GameObject goControleGeral;
	private GameControl controleGeral;

	// Use this for initialization
	void Start ()
	{
		this.goControle = GameObject.FindGameObjectWithTag ("controlesocial");
		this.controle = goControle.GetComponent<ControleRecursos>() as ControleRecursos;

		this.goControleGeral = GameObject.FindGameObjectWithTag ("GameControl");
		this.controleGeral = goControleGeral.GetComponent<GameControl>() as GameControl;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.inicia) {
			if (Input.GetMouseButtonUp (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 100)) {
					if (hit.transform.tag == "cidade") {
						hit.transform.GetComponent<ControleCidade> ().Constroi ();
					}
					if (hit.transform.tag == "plantacao") {
						hit.transform.GetComponent<ControlePlantacao> ().Plantar ();
					}
				}
			}

			if (this.controle.RetornaAlimento () >= 25) {
				this.controleGeral.estadoAtual++;

				Destroy (GameObject.Find("TesteLixo"));

				Destroy (this.gameObject);
			}
		}
	}

	void OnGUI()
	{
		if (inicia) {
			GUI.Box (new Rect (Screen.width / 2 - 300, 0, 100, 40),
			         "Recursos: " + this.controle.RetornaRecurso ().ToString ());
			GUI.Box (new Rect (Screen.width / 2 - 50, 0, 100, 40),
			         "Trab: " + this.controle.RetornaTrabLivre ().ToString ());
			GUI.Box (new Rect (Screen.width / 2 + 200, 0, 100, 40),
			         "Alimento: " + this.controle.RetornaAlimento ().ToString ());
	
		}
	}

	public void Comeca ()
	{
		this.controle.inicia = true;
		this.inicia = true;
	}
}
