using UnityEngine;
using System.Collections;

/*******************************************************************************************
This script controls the main menu wihtout GUI. Menu with 3d objects
*******************************************************************************************/

public class ControleMenuPrincipal : MonoBehaviour {
	
	private string sMenu;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		Ray rRay = Camera.main.ScreenPointToRay( Input.mousePosition );
		
		RaycastHit rcColisorRayCast;
		
		if ( Input.GetMouseButtonUp ( 0 ) )
		{
			if ( Physics.Raycast ( rRay, out rcColisorRayCast, 200 ) )
			{
				sMenu = rcColisorRayCast.transform.name;
			}
		}
		
		switch ( sMenu )
		{
			
			case "Iniciar":
				Application.LoadLevel( "Cenario" );
			break;
			
			case "Ajuda":
			
			break;
			
			case "Config":
			
			break;
		
			case "Sair":
			
			break;
			
			default:
			
			break;
		}
	}
}
