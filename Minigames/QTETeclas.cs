using UnityEngine;
using System.Collections;
/*******************************************************************************************
seta teclado pro quick time event
*******************************************************************************************/
public class QTETeclas : MonoBehaviour {

	public KeyCode tecla;

	public GameObject goControle;
	private QTEControle controle;

	public Transform sucesso;
	public Transform erro;

	// Use this for initialization
	void Start () {
		goControle = GameObject.FindGameObjectWithTag ("qtecontrole");
		controle = goControle.GetComponent<QTEControle>() as QTEControle;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.position = new Vector3 ( this.transform.position.x,
		                                       this.transform.position.y,
		                                       this.transform.position.z - 0.1f );


		if (this.transform.position.z < -10)
			if (Input.GetKey (tecla))
				Acerto ();

		if (this.transform.position.z < -11)
			Erro();

	}

	void Acerto()
	{
		Instantiate ( sucesso, this.transform.position, Quaternion.identity);
		controle.Sucess ();
		Destroy (this.gameObject);
	}

	void Erro ()
	{
		Instantiate ( erro, this.transform.position, Quaternion.identity);
		controle.Fail ();
		Destroy (this.gameObject);
	}
}
