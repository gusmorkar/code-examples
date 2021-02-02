using UnityEngine;
using System.Collections;

/*******************************************************************************************
This script controls revealing the part of the ships on the board
*******************************************************************************************/

public class ReveladorDragoes : MonoBehaviour {
	
	public int iTotalPartes;
	
	private int iPartesReveladas;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( iTotalPartes == iPartesReveladas )
		{
			print ( "Achou tudo!" );
		}
	}
	
	public void mtEscondePartes ()
	{
		for ( int i = 0; i < this.transform.childCount; i ++ )
		{
			Transform goChild;
			goChild = this.transform.GetChild(i);
			goChild.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	public void mtIncrementaQuantidadePartes ()
	{
		iPartesReveladas++;
	}
}
