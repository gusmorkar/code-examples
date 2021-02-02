using UnityEngine;
using System.Collections;

/*to remember to create enemy class with speed, target and canMove*/

public class EnemyFollower : MonoBehaviour
{
	public bool followX_b = false;
	public bool followY_b = false;

	private GameObject player_go;
	private Vector3 target_v;
	
	public float speed_f = 2.0f;

	public bool canMove_b;

	public float sphereRadius_f;

	void Start ()
	{
		player_go = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update ()
	{
		target_v = this.transform.position;

		if (followX_b)
			target_v.x = player_go.transform.position.x;

		if (followY_b)
			target_v.y = player_go.transform.position.y;

		mtCheckCollision ();

		if ((Vector3.Distance (this.transform.position, target_v) > 0.1f) && (canMove_b))
		{
			float finalSpeed_f = speed_f * Time.deltaTime;
			
			transform.position = Vector3.Lerp(this.transform.position,
			                                  target_v, finalSpeed_f);
		}
	}

	private void mtCheckCollision()
	{
		Vector3 focus_v = new Vector3 ();
		focus_v = this.transform.position;
		focus_v.x = target_v.x;

		Vector3 direction_v = new Vector3 ();

		if (focus_v.x < this.transform.position.x)
		{
			direction_v = this.transform.position - focus_v;
			direction_v = direction_v / (direction_v.magnitude * -1);
		}
		else
		{
			direction_v = focus_v - this.transform.position;
			direction_v = direction_v / direction_v.magnitude;
		}

		RaycastHit hit;

		if (Physics.SphereCast (this.transform.position, sphereRadius_f,
		                       direction_v, out hit, 10))
			canMove_b = false;
		else
			canMove_b = true;
	}
}