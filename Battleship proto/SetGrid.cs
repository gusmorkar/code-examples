using UnityEngine;
using System.Collections;

/*******************************************************************************************
This script creates the boards (10x10 grid) for player and AI
*******************************************************************************************/

public class SetGrid : MonoBehaviour
{
    //gameObject to be father of the enemy grids
    public GameObject goEnemyGrid;
    //gameObject to be father of the players grids
    private GameObject goPlayerGrid;

    //Vector with all the grid prefabs what could be instantiate to get one random
    public Transform[] v_tRandomTiles = new Transform[10];	
	
    //matrix for the grids, for the Player Grid n for the Enemy Grid
	public GameObject[,] m_goPlayerGrid = new GameObject[10,10];
    private GameObject[,] m_goEnemyGrid = new GameObject[10, 10];

    void Awake ()
	{
        //inicialize goCenario n put a name in the game object
        goPlayerGrid = new GameObject ();
        goPlayerGrid.name = "PlayerGrid";

        //inicialize goCenarioInimigo n put a name in the game object
        goEnemyGrid = new GameObject();
        goEnemyGrid.name = "EnemyGrid";

        //Call a method to instantiate the grids
        mtSetGrids();
    }

    //Create the grids - 2 grids 10x10, one for the player, another one for the enemy
    void mtSetGrids()
    {
        //define a names to set the tiles
        string sTilePlayer = "TilePlayer";
        string sTileEnemy = "TileEnemy";

        //line 0 until 9, 10 lines
        for (int x = 0; x < 10; x++)
        {
            //rows 0 until 9, 10 rows
            for (int y = 0; y < 10; y++)
            {
                //Vector 3 with the position to instantiate - X n Y change with the FOR| Z is always 0
                Vector3 vPos = new Vector3(5.0f * x,
                                            0,
                                            -5.0f * y);

                //instantiate the player grid first
                //call fnCenario to set the tile before instantiate
                //instantiate in the position defined with POS n upside down with the angle
                Instantiate(fnSelectTile(sTilePlayer), vPos, Quaternion.Euler(-270, 0, 0));

                //put the players tile in a matrix
                mtSetMatrixGrid(sTilePlayer, x, y);

                //X is increased to instantiate the enemy grid
                vPos.x += 60;

                //call fnCenario to set the tile before instantiate
                Instantiate(fnSelectTile(sTileEnemy), vPos, Quaternion.Euler(-270, 0, 0));

                //put the enemys tile in a matrix
                mtSetMatrixGrid(sTileEnemy, x, y);

            }//end FOR Y

        }//end FOR X

        //after create the grids, change the phase n destroy this script
        this.transform.GetComponent<MainController>().mtSwitchPhase(0);
        Destroy(this);
    }

    //set a tile to be instantiated
    Transform fnSelectTile( string nm )
	{
        //get a random tile in tileCenario
		Transform tSelectedTile = v_tRandomTiles[ Random.Range ( 0, 8 ) ];

        //define a new name for the tile, what will be CE+XnY
        tSelectedTile.name = nm;

        //return the tile to be instantiate
		return tSelectedTile;
    }

    //set the tile in a matrix
    void mtSetMatrixGrid(string sTempName, int iTempX, int iTempY)
    {
        GameObject goTempTile;

        //define a name to search
        string sName = sTempName + "(Clone)";
        //search/find a Gameobjet with the name defined N put the found Game Object in the matrix
        goTempTile = GameObject.Find(sName);
        //set the name of the GO again
        goTempTile.name = sTempName + iTempX.ToString() + iTempY.ToString();
        //set a father for the GO
        if (sTempName == "sTilePlayer")
        {
            m_goPlayerGrid[iTempX, iTempY] = goTempTile;
            m_goPlayerGrid[iTempX, iTempY].transform.parent = goPlayerGrid.transform;
        }
        else
        {
            m_goEnemyGrid[iTempX, iTempY] = goTempTile;
            m_goEnemyGrid[iTempX, iTempY].transform.parent = goEnemyGrid.transform;
        }
    }
}