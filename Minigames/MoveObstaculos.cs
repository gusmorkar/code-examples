using UnityEngine;
using System.Collections;
/*******************************************************************************************
controla os obstaculos no endless runner
*******************************************************************************************/
public class MoveObstaculos : MonoBehaviour {

	private float velocidade;

	// Use this for initialization
	void Start () {
		velocidade = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.position = new Vector3 (this.transform.position.x,
		                                      this.transform.position.y,
		                                      this.transform.position.z - velocidade);
	
		if (this.transform.position.z <= -19)
			Destroy (this.gameObject);
	}
}
