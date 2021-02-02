using UnityEngine;
using System.Collections;

/*enemy fire rate*/

public class EnemyGunControl : MonoBehaviour
{
	public GameObject shot_go;
	
	public Transform aim_t;

	public float ammunition_f = 3;
	public float shotSpeed_f = 0.1f;
	public float shot_f = 0;
	public float reloadTime_f = 2;

	public float timeShot_f = 0;
	public float refreshTime_f = 0;

	public bool reloadGun_b = false;

	void Update ()
	{
		if (timeShot_f > shotSpeed_f && !reloadGun_b)
		{
			mtInstantiateShot ();
			
			timeShot_f = 0;
			shot_f += 1;
		}
		timeShot_f += Time.deltaTime;

		if (shot_f >= ammunition_f)
		{
			reloadGun_b = true;
			shot_f = 0;
		}

		if (reloadGun_b)
		{
			refreshTime_f += Time.deltaTime;

			if (refreshTime_f >= reloadTime_f)
			{
				reloadGun_b = false;
				refreshTime_f = 0;
			}
		}
	}
	
	void mtInstantiateShot ()
	{
		Instantiate (shot_go, aim_t.transform.position, aim_t.transform.rotation);
	}
}