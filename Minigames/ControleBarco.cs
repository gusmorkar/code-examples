using UnityEngine;
using System.Collections;
/*******************************************************************************************
controla o player no endless runner
*******************************************************************************************/
public class ControleBarco : MonoBehaviour
{
	private float velocidade = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			if ( this.transform.position.z < -6 )
				this.transform.position = new Vector3 ( this.transform.position.x,
				                                       this.transform.position.y,
				                                       this.transform.position.z + velocidade);
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			if ( this.transform.position.x > -2.5f )
				this.transform.position = new Vector3 ( this.transform.position.x - velocidade,
				                                       this.transform.position.y,
				                                       this.transform.position.z );
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			if ( this.transform.position.z > -14 )
				this.transform.position = new Vector3 ( this.transform.position.x,
				                                       this.transform.position.y,
				                                       this.transform.position.z - velocidade);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			if ( this.transform.position.x < 3 )
				this.transform.position = new Vector3 ( this.transform.position.x + velocidade,
				                                       this.transform.position.y,
				                                       this.transform.position.z );
		}
	
	}

	void OnTriggerEnter ( Collider other )
	{
		if (other.gameObject.tag == "Obstaculo")
		{
			//inserir condicao de derrota
			print ("perdeu!!!!");
		}
	}
}
