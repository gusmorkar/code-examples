using UnityEngine;
using System.Collections;

/*fire rate control*/
public class GunControl : MonoBehaviour {

	private float powerShot_f = 0;
	
	public GameObject shot_go;

	public Transform aim_t;

	public float refreshShotSpeed_f = 0.1f;
	private float timeShot_f = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0)) && (timeShot_f > refreshShotSpeed_f))
		{
			mtInstantiateShot ();
			timeShot_f = 0;
		}
		timeShot_f += Time.deltaTime;
	}
	
	void mtInstantiateShot ()
	{
		Instantiate (shot_go, aim_t.transform.position, aim_t.transform.rotation);
	}

	public void UpdateRefreshShotSpeed ( int r )
	{
		refreshShotSpeed_f -= (r*0.025f); 
	}
}
