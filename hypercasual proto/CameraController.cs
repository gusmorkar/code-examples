using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*sets camera up*/
public class CameraController : MonoBehaviour
{
    private GameObject go_Player;

    private Vector3 v_OffSet;

	void Awake ()
    {
        go_Player = GameObject.FindGameObjectWithTag("Player");

        v_OffSet = this.transform.position - go_Player.transform.position;
	}
	
	void LateUpdate ()
    {
        transform.position = go_Player.transform.position + v_OffSet;
	}
}
