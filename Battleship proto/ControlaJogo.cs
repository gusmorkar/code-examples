using UnityEngine;
using System.Collections;

/*******************************************************************************************
This script controls the player/IA TURNS
*******************************************************************************************/

public class ControlaJogo : MonoBehaviour {
	
	private GameObject[] goDrag = new GameObject[6];
	
	public bool bPodeJogar = false;
	
	// Use this for initialization
	void Start ()
	{
		goDrag = GameObject.FindGameObjectsWithTag( "GridPreenchido" );
		
		foreach ( GameObject goOvos in goDrag )
			goOvos.transform.GetComponent<ReveladorDragoes>().mtEscondePartes();

		this.transform.GetComponent<CameraController>().mtSwitchCameraPosition();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray rRay = Camera.main.ScreenPointToRay( Input.mousePosition );
		
		RaycastHit rcColisorRayCast;
		
		if ( Input.GetMouseButtonUp ( 0 ) && bPodeJogar )
		{
			if ( Physics.Raycast ( rRay, out rcColisorRayCast, 200 ) )
			{
				if ( ( rcColisorRayCast.transform.tag == "Grid" ) &&
					( !rcColisorRayCast.transform.GetComponent<RevelaGrid>().fnRevelado() ) )
					rcColisorRayCast.transform.GetComponent<RevelaGrid>().mtRevela();
				if ( ( rcColisorRayCast.transform.tag == "Dragao" ) && 
					( !rcColisorRayCast.transform.GetComponentInChildren<MeshRenderer>().enabled ) )
				{
						rcColisorRayCast.transform.GetComponentInChildren<MeshRenderer>().enabled = true;
						rcColisorRayCast.transform.parent.GetComponent<ReveladorDragoes>().mtIncrementaQuantidadePartes();
				}
				else
					mtPassaTurno();
			}
		}
	}
	
	public void mtAtivaTurno()
	{
		bPodeJogar = true;
	}
	
	void mtPassaTurno()
	{
		bPodeJogar = false;
		this.transform.GetComponent<TurnsControl>().mtUpdateTurn();
	}
}
