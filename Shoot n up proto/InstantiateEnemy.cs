using UnityEngine;
using System.Collections;


/*instantiate enemies*/

public class InstantiateEnemy : MonoBehaviour {

	public GameObject[] seqEnemy = new GameObject[9];

	private bool inicia = false;
	private int controle = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.inicia)
		{
			InvokeRepeating( "Instancia", 0.1f, 1f);
			this.inicia = false;
		}
	}

	public void Comeca (){
		inicia = true;
	}

	void Instancia(){
		if (controle < 50) {
			Instantiate (this.seqEnemy [Random.Range (0, 9)], this.transform.position, Quaternion.identity);
			controle ++;
		}
		else {
			Destroy ( this.gameObject );
		}
	}
}
