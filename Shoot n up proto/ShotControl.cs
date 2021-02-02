using UnityEngine;
using System.Collections;

/* shooting control*/

public class ShotControl : MonoBehaviour {

	public float shotSpeed_f;

	public float lifeTime_f;

	// Use this for initialization
	void Start ()
	{
		Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), this.GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, shotSpeed_f);

		Destroy (this.gameObject, lifeTime_f);
	}

	void OnCollisionEnter ( Collision c )
	{
		if (c.transform.CompareTag("Enemy") || c.transform.CompareTag("Barrier"))
			c.gameObject.GetComponent<EnemyHPControl> ().mtDamage (5);

		Destroy (this.gameObject);
	}
}
