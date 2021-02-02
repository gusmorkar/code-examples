using UnityEngine;
using System.Collections;

/**************************************************************************************************************
This script check if the grid is open or not
When the player click on the grid, if is not open yet, will open i

88888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
has to fix:
if destroy this script after reveal the grid, can not check again if is revealed or not
solution:
- try to control with tags
improve:
- one script, take the tile, updated, stop the script
- other tile, call the script again, stop the script
88888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
**************************************************************************************************************/

public class RevelaGrid : MonoBehaviour {
	
    //flag for the grid, revealed or not
	private bool bRevelado;
    //speed to turn around the grid
	private float fVelocidade;
	
	void Start ()
	{
        //set up the grid as not revealed
        //n the speed as 100
		bRevelado = false;
		fVelocidade = 100;
    }
	
    //returns if the grid is revealed or not
	public bool fnRevelado ()
	{
		return bRevelado;
	}

	//open the grid
	void Update ()
	{
        //if the grid is revealed
        if (bRevelado)
        {
            //set a new variable as a new angle as a small increase on the last angle
            float fNewAngle = Mathf.LerpAngle(this.transform.eulerAngles.x, 270.0f, fVelocidade * Time.deltaTime);
            //currency angle change for the new angle
            this.transform.eulerAngles = new Vector3 (fNewAngle, 0, 0);

            //when reach the angle 270 (terrain up)
            if (transform.eulerAngles.x == 270)
            {
                //set the exactly angle up
                //n destroy the script
                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
				transform.eulerAngles = new Vector3 ( 270, 0, 0 );
				Destroy ( this );
			}
		}
	}
	
    //change flag to reveal
	public void mtRevela ()
	{
		bRevelado = true;
	}
}
