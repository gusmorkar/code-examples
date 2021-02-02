using UnityEngine;
using System.Collections;

/*control crew setup*/

public class TeamControl : MonoBehaviour {

	private int team = 6;

	private int mec = 0;
	private int cop = 0;
	private int gun = 0;

	public GameObject goPlayer;
	private SpaceShipControl script;

	void OnGUI()
	{
		GUI.BeginGroup(new Rect( 0, 0, Screen.width, Screen.height ));
			GUI.Box(new Rect( Screen.width/2 -75, 0, 150, 30 ), "Organize sua equipe");
			GUI.Box(new Rect( Screen.width/2-75, 40, 150, 30 ), "Total disponivel: "+team.ToString());

		    GUI.Box(new Rect( Screen.width/2-50, 80, 100, 30 ), "Mecanico: " + mec.ToString());
				if (GUI.Button (new Rect (Screen.width / 2 + 50, 95, 15, 15), "+"))
					if ( team > 0 )
						UpdateTeam(1, 1);

				if ( GUI.Button (new Rect( Screen.width/2+70, 95, 15, 15 ), "-" ))
					if ( mec > 0 )
						UpdateTeam(1, -1);
		  		 	

			GUI.Box(new Rect( Screen.width/2-50, 120, 100, 30 ), "CoPiloto: " + cop.ToString());
				if ( GUI.Button (new Rect( Screen.width/2+50, 135, 15, 15 ), "+" ))
		    		if ( team > 0 )
						UpdateTeam(2, 1);

				if ( GUI.Button (new Rect( Screen.width/2+70, 135, 15, 15 ), "-" ))
		    		if ( cop > 0 )
						UpdateTeam(2, -1);

			GUI.Box(new Rect( Screen.width/2-50, 160, 100, 30 ), "Armeiros: " + gun.ToString());
				if ( GUI.Button (new Rect( Screen.width/2+50, 175, 15, 15 ), "+" ))
		   			if ( team > 0 )
						UpdateTeam(3, 1);

				if ( GUI.Button (new Rect( Screen.width/2+70, 175, 15, 15 ), "-" ))
		   			if ( gun > 0 )
						UpdateTeam(3, -1);

		GUI.EndGroup();

		if (GUI.Button (new Rect (Screen.width / 2 - 50, 200, 100, 30), "INICIAR")) {
			if (team == 0) {
				goPlayer.gameObject.SetActive (true);
				script = goPlayer.GetComponent<SpaceShipControl>() as SpaceShipControl;
				script.UpdateTeamStats (mec, cop, gun);
				goPlayer.gameObject.GetComponent<GameControl>().Begin();
				Destroy(this);
			}
		}
	}

	void UpdateTeam ( int stats, int sinal )
	{
		switch (stats){
			case 1: mec += sinal; break;

			case 2: cop += sinal; break;

			case 3: gun += sinal; break;
		}
		team -= sinal;
	}
}
