using UnityEngine;
using System.Collections;
/*enemie bullets*/

public class EnemyShotControl : MonoBehaviour {

	public float shotSpeed_f;
	
	public float lifeTime_f;

	public int damage_i;

	public GameObject effect_go;

	void Start ()
	{
		Destroy (this.gameObject, lifeTime_f);
	}

	void Update () 
	{
		this.transform.position = new Vector3 (this.transform.position.x,
		                                      this.transform.position.y,
		                                      this.transform.position.z - shotSpeed_f);
	}

	void OnCollisionEnter ( Collision c )
	{
		if (c.transform.tag == "Player")
		{
			c.gameObject.GetComponent<SpaceShipControl> ().mtDamage (damage_i);

			Instantiate (effect_go,this.transform.position, this.transform.rotation);

			Destroy (this.gameObject);
		}
	}
}
