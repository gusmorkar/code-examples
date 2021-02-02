using UnityEngine;
using System.Collections;

/* player control*/

public class Team {
	public int mechanical;
	public int copilot;
	public int gunsmith;
}

public class SpaceShipControl : MonoBehaviour {

	private GameObject goPosDown;
	private GameObject goPosUp;

	private float speed_f = 30.0f;
	private float horizontalSpeed_f = 20.0f;
	private float verticalSpeed_f= 20.0f;

	private float posDown_f;
	private float posUp_f;

	public Team teamOrder;

	private int attack;
	private int defense;
	public int hp_i;
	
	private bool moveDown_b = true;
	private bool canMove_b = true;
	private bool up_b = false;

	private Vector3 endPos_v;

	void Start ()
	{
		posDown_f = GameObject.Find ("PosBaixa").transform.position.y;
		posUp_f = GameObject.Find ("PosAlta").transform.position.y;

		fnCheckY ();
	}

	void Update ()
	{
		horizontalSpeed_f = verticalSpeed_f = speed_f;

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A))
			mtHorizontalAceleration (-1);
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
			mtHorizontalAceleration (1);
		else
			mtHorizontalAceleration (0);

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))
			mtVerticalAceleration (1);
		else if ((Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))
			&& (moveDown_b))
			mtVerticalAceleration (-1);
		else
			mtVerticalAceleration (0);

		if (Input.GetKeyDown (KeyCode.LeftShift) && canMove_b)
			fnSwitchHeight ();

		if (!canMove_b)
		{
			float finalSpeed_f = speed_f * Time.deltaTime;

			Vector3 transVec_v = new Vector3 (this.transform.position.x,
			                          endPos_v.y,
			                          this.transform.position.z);

			transform.position = Vector3.MoveTowards (this.transform.position,
			                                          transVec_v,
			                                          finalSpeed_f);

			if (Vector3.Distance ( this.transform.position, transVec_v ) < 0.1f )
				canMove_b = true;
		}

		if (this.hp_i <= 0)
			Application.LoadLevel (0);

		this.GetComponent<Rigidbody>().velocity = new Vector3 ( horizontalSpeed_f, 0, verticalSpeed_f);
	}

	void mtHorizontalAceleration ( int d )
	{
		horizontalSpeed_f *= d;
	}

	void mtVerticalAceleration ( int d2 )
	{
		verticalSpeed_f *= d2;
	}

	void fnSwitchHeight ()
	{
		if (fnCheckColisionOnY ())
		{
			if (up_b)
				endPos_v.y = posDown_f;
			else
				endPos_v.y = posUp_f;

			up_b = !up_b;

			canMove_b = false;
		}
	}

	bool fnCheckColisionOnY()
	{
		Vector3 dir;

		if (up_b)
			dir = transform.TransformDirection(Vector3.down);
		else
			dir = transform.TransformDirection(Vector3.up);

		float distanceToObstacle = 0;

		if (Physics.Raycast (this.transform.position, dir.normalized, 30))
			return false;
		else
			return true;
	}

	private void fnCheckY()
	{
		if (this.transform.position.y == posUp_f)
			up_b = true;
		else
			up_b = false;
	}

	public void UpdateTeamStats ( int m, int c, int g )
	{
		teamOrder = new Team ();
		teamOrder.mechanical = m;
		teamOrder.copilot = c;
		teamOrder.gunsmith = g;
		UpdateStats ();
	}

	void UpdateStats ()
	{
		speed_f += (2.5f * teamOrder.copilot);
		attack += 1 * teamOrder.gunsmith;
		defense += 1 * teamOrder.mechanical;
		this.hp_i += 15 * defense;
		this.SendMessage ("UpdateRefreshShotSpeed", attack);
	}

	//PASSAR ISSO PRA OUTRO SCRIPT
	void OnGUI()
	{
		GUI.Box(new Rect( Screen.width/2 -300, 0, 150, 30 ), "Poder de Ataque: " + attack.ToString());
		GUI.Box(new Rect( Screen.width/2 -75, 0, 150, 30 ), "Defesa: " + defense.ToString());
		GUI.Box(new Rect( Screen.width/2 +60, 0, 80, 30 ), "HP: " + hp_i.ToString());
		GUI.Box(new Rect( Screen.width/2 +150, 0, 150, 30 ), "Velocidade: " + speed_f.ToString());
	}

	void OnTriggerEnter (Collider c)
	{
		if (c.transform.CompareTag ("limit"))
			moveDown_b = false;
	}

	void OnTriggerExit (Collider c)
	{
		if (c.transform.CompareTag ("limit"))
			moveDown_b = true;
	}

	void OnCollisionEnter (Collision c)
	{
		if (c.transform.name == "KillCollider")
			Application.LoadLevel (0);

		if (c.transform.tag == "Enemy")
		{
			Destroy (c.transform.gameObject);
			mtDamage (40);
		}
	}

	public void mtDamage (int d)
	{
		this.hp_i -= d;
	}
}