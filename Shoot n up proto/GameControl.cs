using UnityEngine;
using System.Collections;
/*overall game controller*/

public class GameControl : MonoBehaviour {

	private bool bStart = false;
	private GameObject goCamera;

	public Transform go1_t;
	public Transform go2_t;
	public Transform go3_t;
	public Transform go4_t;

	public float fSpeed = 0.5f;

	// Use this for initialization
	void Start ()
	{
		goCamera = GameObject.Find ("CameraJogo");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (bStart)
		{
			goCamera.transform.position = new Vector3 (goCamera.transform.position.x,
		                                           goCamera.transform.position.y,
		                                           goCamera.transform.position.z + fSpeed);
	
			this.transform.position = new Vector3 (this.transform.position.x,
			                                       this.transform.position.y,
			                                       this.transform.position.z + fSpeed);
		}
	}


	public void Begin ()
	{
		bStart = true;
	}

	void OnTriggerEnter (Collider c)
	{
		if ( c.transform.name == "Trigger1" )
		{
			print ("AQUI O");
			go1_t.gameObject.SetActive (true);
		}
		if (c.transform.name == "Trigger2")
		{
			Destroy ( go1_t.gameObject );
			go2_t.gameObject.SetActive (true);
		}
		if (c.transform.name == "Trigger3")
		{
			Destroy ( go2_t.gameObject );
			go3_t.gameObject.SetActive (true);
		}
		if (c.transform.name == "Trigger4")
		{
			Destroy ( go3_t.gameObject );
			go4_t.gameObject.SetActive (true);
		}
		if (c.transform.name == "Trigger5")
		{
			Destroy ( go4_t.gameObject );
			Destroy (this, 1.0f );
		}
	}
}
