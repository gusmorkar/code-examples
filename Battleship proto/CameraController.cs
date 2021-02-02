using UnityEngine;
using System.Collections;

/**************************************************************************************************************
This script control the Camera Position
When the game start, set a new position
**************************************************************************************************************/

public class CameraController : MonoBehaviour {

    //new position
	private Vector3 v3NewPos;

	void Start ()
	{
        //when start set a new value for the variable
		v3NewPos = new Vector3 ( 21, 44, -23 );
	}

    //when call the script - when the game start properly - update the position
	public void mtSwitchCameraPosition()
	{
        //main camera position is updated for the new position
		Camera.main.transform.position = v3NewPos;
	}
}
