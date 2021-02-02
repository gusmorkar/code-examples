using UnityEngine;
using System.Collections;

/*control obstacle*/

public class GateControl : MonoBehaviour {

	public float speed_f;

	public GameObject gate_go;

	void Start ()
	{
		gate_go = GameObject.Find ("Gate");
		Destroy (this.gameObject, 3);
	}

	// Update is called once per frame
	void Update ()
	{
		mtDown ();
	}

	private void mtDown()
	{
		gate_go.transform.position = new Vector3 (gate_go.transform.position.x,
		                                          gate_go.transform.position.y - speed_f,
		                                          gate_go.transform.position.z);
	}
}
