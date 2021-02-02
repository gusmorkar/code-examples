using UnityEngine;
using System.Collections;
/*to remember to create enemy class*/

public class EnemyStatic : MonoBehaviour
{
	public float maxLeft_f = -53.0f;
	public float maxRight_f = 53.0f;

	public float speed_f;

	private Vector3 target_v;

	private bool canMove_b;

	public float timeForMove_f;

	void Start ()
	{
		canMove_b = false;
		Invoke("fnMove", timeForMove_f);
	}

	void Update ()
	{
		if (canMove_b)
		{
			float finalSpeed_f = speed_f * Time.deltaTime;

			transform.position = Vector3.Lerp(this.transform.position,
			                                  target_v, finalSpeed_f);

			if (Vector3.Distance (this.transform.position, target_v) < 0.1f)
			{
				canMove_b = false;
				Invoke("fnMove", timeForMove_f);
			}
		}
	}

	void fnMove ()
	{
		target_v = new Vector3 ();
		target_v = this.transform.position;
		target_v.x = Random.Range (maxLeft_f, maxRight_f);

		canMove_b = true;
	}
}