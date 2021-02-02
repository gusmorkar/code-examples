using UnityEngine;
using System.Collections;

/*obstacle control*/
public class RockControl : MonoBehaviour
{
	void Start ()
	{
		Destroy (this.gameObject, 7.0f);
	}
	
	void OnCollisionEnter ( Collision c )
	{
		if (c.transform.CompareTag("Enemy"))
			c.gameObject.GetComponent<EnemyHPControl> ().mtDamage (500);
		
		Destroy (this.gameObject, 5.0f);
	}
}